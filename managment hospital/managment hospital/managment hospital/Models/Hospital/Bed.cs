using HospitalManagementSystem.Models.People;
using static HospitalManagementSystem.Models.Hospital.BedAssignedEventArgs;

namespace HospitalManagementSystem.Models.Hospital
{
    public class Bed
    {
        private string _bedNumber;      //(A1) شماره تخت مثل 
        private decimal _dailyRate;     // هزینه روزانه تخت

        public string BedNumber
        {
            get { return _bedNumber; }          
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // بررسی خالی نبودن
                    throw new ArgumentException("شماره تخت نمی‌تواند خالی باشد");
                _bedNumber = value;             
            }
        }
        public decimal DailyRate
        {
            get { return _dailyRate; }         
            set
            {
                if (value < 0)                  // بررسی منفی نبودن
                    throw new ArgumentException("هزینه روزانه نمی‌تواند منفی باشد");
                _dailyRate = value;             
            }
        }
        public Room Room { get; set; }             // اتاقی که این تخت در آن قرار دارد             
        public BedType Type { get; set; }          //نوع تخت       
        public BedStatus Status { get; set; }       //(وضعیت تخت (خالی، اشغال، در حال نظافت        
        public Patient AssignedPatient { get; private set; }// بیمار اختصاص‌یافته به این تخت        
        public DateTime? AssignmentDate { get; private set; }// تاریخ اختصاص بیمار به این تخت        
        public string Specifications { get; set; }// (...,مشخصات فیزیکی تخت (مثلاً الکتریکی، دستی
        public DateTime? LastMaintenanceDate { get; set; }// تاریخ آخرین سرویس و نگهداری

        public Bed()
        {
            Status = BedStatus.Available;       // وضعیت اولیه: خالی
            Type = BedType.Regular;             // نوع پیشفرض: معمولی
        }
        public Bed(string bedNumber, Room room, BedType type)
        {
            BedNumber = bedNumber;              
            Room = room;                        
            Type = type;                        
            Status = BedStatus.Available;       
        }

        // متد اختصاص بیمار به این تخت
        public void AssignPatient(Patient patient)
        {
            if (patient == null)                // بررسی نال نبودن بیمار
                throw new ArgumentNullException("بیمار نمی‌تواند null باشد");

            if (Status != BedStatus.Available)  // بررسی خالی بودن تخت
                throw new InvalidOperationException("تخت در دسترس نیست");

            if (AssignedPatient != null)        // اگر تخت قبلاً بیمار دارد
                throw new InvalidOperationException("تخت قبلاً اختصاص داده شده");

            AssignedPatient = patient;          // اختصاص بیمار
            Status = BedStatus.Occupied;        // تغییر وضعیت به اشغال شده
            AssignmentDate = DateTime.Now;      // ثبت تاریخ اختصاص

            // فعال کردن رویداد اختصاص تخت
            OnBedAssigned(new BedAssignedEventArgs(this, patient));
        }

        // آزاد کردن تخت (ترخیص بیمار)ر
        public void Free()
        {
            if (Status != BedStatus.Occupied)   // اگر تخت اشغال نیست
                throw new InvalidOperationException("تخت اشغال نیست");
            Patient previousPatient = AssignedPatient;
            AssignedPatient = null;             // حذف بیمار
            Status = BedStatus.Cleaning;        // تغییر وضعیت به در حال نظافت
            AssignmentDate = null;              // پاک کردن تاریخ اختصاص

            // فعال کردن رویداد آزادسازی تخت
            OnBedFreed(new BedFreedEventArgs(this, previousPatient));
        }

        // (تکمیل نظافت تخت (آماده برای استفاده مجدد
        public void CompleteCleaning()
        {
            if (Status != BedStatus.Cleaning)   // اگر تخت در حال نظافت نیست
                throw new InvalidOperationException("تخت در حال نظافت نیست");

            Status = BedStatus.Available;       // تغییر وضعیت به خالی
            LastMaintenanceDate = DateTime.Now; // ثبت تاریخ آخرین سرویس
        }

        // (رزرو تخت برای بیمار خاص (بدون اختصاص فوری
        public void ReserveForPatient(Patient patient)
        {
            if (patient == null)                // بررسی نال نبودن بیمار
                throw new ArgumentNullException("بیمار نمی‌تواند null باشد");

            if (Status != BedStatus.Available)  // بررسی خالی بودن تخت
                throw new InvalidOperationException("تخت در دسترس نیست");

            AssignedPatient = patient;          // (اختصاص بیمار (موقت
            Status = BedStatus.Reserved;        // تغییر وضعیت به رزرو شده
            AssignmentDate = DateTime.Now;      // ثبت تاریخ رزرو
        }

        // لغو رزرو تخت
        public void CancelReservation()
        {
            if (Status != BedStatus.Reserved)   // اگر تخت رزرو نیست
                throw new InvalidOperationException("تخت رزرو نشده است");

            AssignedPatient = null;             // حذف بیمار
            Status = BedStatus.Available;       // تغییر وضعیت به خالی
            AssignmentDate = null;              // پاک کردن تاریخ
        }

        // (محاسبه مدت استفاده از تخت (روز
        public int CalculateUsageDays()
        {
            if (!AssignmentDate.HasValue || Status != BedStatus.Occupied)
                return 0;                       // اگر تخت اختصاص ندارد

            TimeSpan duration = DateTime.Now - AssignmentDate.Value; // مدت زمان
            return duration.Days;               // برگرداندن تعداد روزها
        }

        // محاسبه هزینه کل استفاده از تخت
        public decimal CalculateTotalCost()
        {
            int usageDays = CalculateUsageDays(); // محاسبه روزهای استفاده
            return usageDays * DailyRate;       // ضرب در نرخ روزانه
        }

        // بررسی آیا تخت نیاز به سرویس دارد (بیشتر از ۳۰ روز گذشته
        public bool NeedsMaintenance()
        {
            if (!LastMaintenanceDate.HasValue)  // اگر تاریخ سرویس ثبت نشده
                return true;                    // نیاز به سرویس دارد

            TimeSpan sinceLastMaintenance = DateTime.Now - LastMaintenanceDate.Value;
            return sinceLastMaintenance.Days > 30; // اگر بیش از ۳۰ روز گذشته
        }

        // گرفتن اطلاعات تخت
        public string GetBedInfo()
        {
            string patientInfo = AssignedPatient != null ?AssignedPatient.GetFullName() : "بدون بیمار"; // نام بیمار یا "بدون بیمار
                

            return $"تخت {BedNumber} | اتاق: {Room?.RoomNumber} | " +
                   $"وضعیت: {GetStatusText()} | بیمار: {patientInfo}";
        }

        // تبدیل وضعیت تخت به متن فارسی
        private string GetStatusText()
        {
            switch (Status)
            {
                case BedStatus.Available: return "خالی";
                case BedStatus.Occupied: return "اشغال شده";
                case BedStatus.Reserved: return "رزرو شده";
                case BedStatus.Cleaning: return "در حال نظافت";
                case BedStatus.Maintenance: return "در تعمیر";
                default: return "نامشخص";
            }
        }

        // تبدیل نوع تخت به متن فارسی
        private string GetTypeText()
        {
            switch (Type)
            {
                case BedType.Regular: return "معمولی";
                case BedType.ICU: return "مراقبت ویژه";
                case BedType.Pediatric: return "کودکان";
                case BedType.Maternity: return "زایمان";
                case BedType.Isolation: return "ایزوله";
                default: return "نامشخص";
            }
        }

        // رویداد اختصاص تخت به بیمار
        public event EventHandler<BedAssignedEventArgs> BedAssigned;

        // رویداد آزادسازی تخت
        public event EventHandler<BedFreedEventArgs> BedFreed;

        // متد فعال‌کننده رویداد اختصاص
        protected virtual void OnBedAssigned(BedAssignedEventArgs e)
        {
            BedAssigned?.Invoke(this, e);       // اگر کسی گوش داده، فراخوانی کن
        }

        // متد فعال‌کننده رویداد آزادسازی
        protected virtual void OnBedFreed(BedFreedEventArgs e)
        {
            BedFreed?.Invoke(this, e);          // اگر کسی گوش داده، فراخوانی کن
        }

        // دسترسی به اطلاعات تخت با کلید
        public object this[string key]
        {
            get
            {
                switch (key.ToLower())
                {
                    case "number": return BedNumber;               // شماره تخت
                    case "type": return GetTypeText();             // (نوع تخت (فارسی
                    case "status": return GetStatusText();         // (وضعیت (فارسی
                    case "patient": return AssignedPatient?.GetFullName(); // نام بیمار
                    case "room": return Room?.RoomNumber;          // شماره اتاق
                    case "rate": return DailyRate;                 // نرخ روزانه
                    case "usage": return CalculateUsageDays();     // روزهای استفاده
                    case "cost": return CalculateTotalCost();      // هزینه کل
                    case "maintenance": return NeedsMaintenance(); // نیاز به سرویس؟
                    default: throw new ArgumentException("کلید نامعتبر");
                }
            }
        }
    }
   

    //کلاس آرگومان رویداد اختصاص تخت
    public class BedAssignedEventArgs : EventArgs
    {
        public Bed Bed { get; }                  // تخت اختصاص‌یافته
        public Patient Patient { get; }          // بیمار
        public DateTime AssignmentTime { get; }  // زمان اختصاص

        public BedAssignedEventArgs(Bed bed, Patient patient)
        {
            Bed = bed;                          // ذخیره تخت
            Patient = patient;                  // ذخیره بیمار
            AssignmentTime = DateTime.Now;      // زمان فعلی}
        }

        //کلاس آرگومان رویداد آزادسازی تخت
        public class BedFreedEventArgs : EventArgs
        {
            public Bed Bed { get; }                  // تخت آزاد شده
            public Patient PreviousPatient { get; }  // بیمار قبلی
            public DateTime FreeTime { get; }        // زمان آزادسازی

            public BedFreedEventArgs(Bed bed, Patient previousPatient)
            {
                Bed = bed;                          // ذخیره تخت
                PreviousPatient = previousPatient;  // ذخیره بیمار قبلی
                FreeTime = DateTime.Now;            // زمان فعلی
            }
        }
    }
}