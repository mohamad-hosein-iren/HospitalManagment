using HospitalManagementSystem.Models.People;

namespace HospitalManagementSystem.Models.Hospital
{
    // کلاس اتاق بیمارستان => می‌تواند اتاق بیمار، اتاق عمل، یا اتاق معاینه باشد
    public class Room
    {
        private string _roomNumber;    //   (ICU-1 شماره اتاق (مثلاً ۲۰۴ یا   
        private int _floorNumber;      //   شماره طبقه

        public string RoomNumber
        {
            get { return _roomNumber; }          
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // بررسی خالی نبودن
                    throw new ArgumentException("شماره اتاق نمی‌تواند خالی باشد");
                _roomNumber = value;             
            }
        }
        public int FloorNumber
        {
            get { return _floorNumber; }         
            set
            {
                if (value < 0 || value > 20)     // (اعتبارسنجی (فرض: حداکثر ۲۰ طبقه
                    throw new ArgumentException("شماره طبقه باید بین ۰ تا ۲۰ باشد");
                _floorNumber = value;           
            }
        }
        public RoomType Type { get; set; }                    // (نوع اتاق (عمومی، خصوصی، ویژه، اتاق عمل
        public Department Department { get; set; }            // (بخش مربوطه (ارتباط با کلاس Department
        public int Capacity { get; set; }                     // (ظرفیت اتاق (تعداد تخت‌ها
        public RoomStatus Status { get; set; }                //( وضعیت اتاق (خالی، اشغال شده، در حال تعمیر
        public List<string> Facilities { get; private set; }  // (امکانات اتاق (مثلاً تلویزیون، یخچال، اینترنت
        public List<Bed> Beds { get; private set; }           // لیست تخت‌های این اتاق
        public List<Patient> Patients { get; private set; }   // لیست بیماران حاضر در این اتاق
        public decimal DailyRate { get; set; }                //( هزینه روزانه اتاق (برای اتاق‌های خصوصی

        public Room()
        {
            Status = RoomStatus.Available;       // وضعیت اولیه: خالی
            Facilities = new List<string>();     // ایجاد لیست خالی امکانات
            Beds = new List<Bed>();              // ایجاد لیست خالی تخت‌ها
            Patients = new List<Patient>();      // ایجاد لیست خالی بیماران
        }

    
        public Room(string roomNumber, RoomType type, int floor, int capacity)
        {
            RoomNumber = roomNumber;          
            Type = type;                      
            FloorNumber = floor;               
            Capacity = capacity;               

            Status = RoomStatus.Available;       // وضعیت اولیه
            Facilities = new List<string>();     // ایجاد لیست امکانات
            Beds = new List<Bed>();              // ایجاد لیست تخت‌ها
            Patients = new List<Patient>();      // ایجاد لیست بیماران
        }

        // اضافه کردن تخت به اتاق
        public void AddBed(Bed bed)
        {
            if (bed == null)                     // بررسی نال نبودن تخت
                throw new ArgumentNullException("تخت نمی‌تواند null باشد");

            if (Beds.Count >= Capacity)          // بررسی ظرفیت اتاق
                throw new InvalidOperationException("اتاق ظرفیت بیشتری ندارد"); if (!Beds.Contains(bed))  // اگر تخت قبلاً اضافه نشده
            {
                Beds.Add(bed);                   // اضافه کردن تخت به لیست
                bed.Room = this;                 // تنظیم اتاق برای تخت
            }
        }

        // پذیرش بیمار در اتاق
        public bool AdmitPatient(Patient patient, Bed bed = null)
        {
            if (patient == null)                 // بررسی نال نبودن بیمار
                throw new ArgumentNullException("بیمار نمی‌تواند null باشد");

            if (Status != RoomStatus.Available)  // بررسی وضعیت اتاق
                throw new InvalidOperationException("اتاق قابل استفاده نیست");

            if (Patients.Count >= Capacity)      // بررسی ظرفیت
                throw new InvalidOperationException("اتاق ظرفیت ندارد");

            if (Patients.Contains(patient))      // اگر بیمار قبلاً پذیرش شده
                return false;

            Patients.Add(patient);               // اضافه کردن بیمار به لیست

            // اگر تخت مشخص شده، بیمار را به آن تخت اختصاص بده
            if (bed != null && Beds.Contains(bed) && bed.Status == BedStatus.Available)
            {
                bed.AssignPatient(patient);      
            }

            // اگر اتاق پر شد، وضعیت را تغییر بده
            if (Patients.Count >= Capacity)
            {
                Status = RoomStatus.Occupied;    // تغییر وضعیت به اشغال شده
            }

            return true;                         // عملیات موفق
        }

        // ترخیص بیمار از اتاق
        public bool DischargePatient(Patient patient)
        {
            bool removed = Patients.Remove(patient); // حذف بیمار از لیست

            if (removed)                         
            {
                // آزاد کردن تخت بیمار
                foreach (var bed in Beds)
                {
                    if (bed.AssignedPatient == patient)
                    {
                        bed.Free();              // آزاد کردن تخت
                        break;
                    }
                }

                // اگر اتاق خالی شد
                if (Patients.Count == 0)
                {
                    Status = RoomStatus.Available; // تغییر وضعیت به خالی
                }
            }

            return removed;                       // برگرداندن نتیجه
        }

        // اضافه کردن امکانات به اتاق
        public void AddFacility(string facility)
        {
            if (!string.IsNullOrWhiteSpace(facility) && !Facilities.Contains(facility))
            {
                Facilities.Add(facility);        // اضافه کردن امکان جدید
            }
        }

        // بررسی آیا اتاق امکانات خاصی دارد
        public bool HasFacility(string facility)
        {
            return Facilities.Contains(facility); // جستجو در لیست امکانات
        }

        // محاسبه درصد اشغال اتاق
        public double CalculateOccupancyRate()
        {
            if (Capacity == 0)                   // اگر ظرفیت صفر باشد
                return 0;

            return (Patients.Count * 100.0) / Capacity; // درصد اشغال
        }

        // پیدا کردن تخت خالی
        public Bed FindAvailableBed()
        {
            foreach (var bed in Beds)           
            {
                if (bed.Status == BedStatus.Available)
                {
                    return bed;                  // برگرداندن تخت خالی
                }
            }
            return null;                         // اگر تخت خالی پیدا نشد
        }
        // گرفتن اطلاعات اتاق
        public string GetRoomInfo()
        {
            double occupancy = CalculateOccupancyRate();
            return $"اتاق {RoomNumber} (طبقه {FloorNumber}) | " +
                   $"نوع: {GetRoomTypeText()} | " +
                   $"ظرفیت: {Patients.Count}/{Capacity} | " +
                   $"وضعیت: {GetStatusText()}";
        }

        // تبدیل نوع اتاق به متن فارسی
        private string GetRoomTypeText()
        {
            switch (Type)
            {
                case RoomType.General: return "عمومی";
                case RoomType.Private: return "خصوصی";
                case RoomType.VIP: return "ویژه";
                case RoomType.Operating: return "اتاق عمل";
                case RoomType.ICU: return "مراقبت ویژه";
                default: return "نامشخص";
            }
        }

        // تبدیل وضعیت اتاق به متن فارسی
        private string GetStatusText()
        {
            switch (Status)
            {
                case RoomStatus.Available: return "خالی";
                case RoomStatus.Occupied: return "اشغال شده";
                case RoomStatus.Maintenance: return "در تعمیر";
                case RoomStatus.Reserved: return "رزرو شده";
                default: return "نامشخص";
            }
        }

        // (indexer)دسترسی به اطلاعات اتاق با کلید
        public object this[string key]
        {
            get
            {
                switch (key.ToLower())
                {
                    case "number": return RoomNumber;                  // شماره اتاق
                    case "floor": return FloorNumber;                  // شماره طبقه
                    case "type": return GetRoomTypeText();             // (نوع اتاق (فارسی
                    case "status": return GetStatusText();             // (وضعیت (فارسی
                    case "capacity": return $"{Patients.Count}/{Capacity}"; // ظرفیت
                    case "occupancy": return CalculateOccupancyRate(); // درصد اشغال
                    case "facilities": return Facilities.Count;        // تعداد امکانات
                    case "beds": return Beds.Count;                    // تعداد تخت‌ها
                    default: throw new ArgumentException("کلید نامعتبر");
                }
            }
        }
    }
}