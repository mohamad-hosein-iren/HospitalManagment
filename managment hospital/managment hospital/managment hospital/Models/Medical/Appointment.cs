using HospitalManagementSystem.Models.People;

namespace HospitalManagementSystem.Models.Medical
{
    public class Appointment
    {
        private int _appointmentId;        //شناسه نوبت
        private DateTime _appointmentTime; //زمان نوبت

        public int AppointmentId
        {
            get { return _appointmentId; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("شماره قرار باید بزرگتر از صفر باشد");
                _appointmentId = value;
            }
        }
        public DateTime AppointmentTime
        {
            get { return _appointmentTime; }
            set
            {
                if (value < DateTime.Now.AddMinutes(-30))
                    throw new ArgumentException("زمان قرار نمی‌تواند در گذشته دور باشد");
                _appointmentTime = value;
            }
        }
        public Patient Patient { get; set; }          // بیمار
        public Doctor Doctor { get; set; }            // پزشک
        public AppointmentType Type { get; set; }     // نوع نوبت
        public int DurationMinutes { get; set; }      // مدت نوبت به دقیقه
        public AppointmentStatus Status { get; set; } // وضعیت
        public string Description { get; set; }       // توضیحات
        public decimal VisitFee { get; set; }         // هزینه ویزیت
        public bool IsInsuranceAccepted { get; set; } // بیمه پذیرفته می‌شود؟
        public string ExaminationRoom { get; set; }   // اتاق معاینه

        public Appointment()
        {
            Status = AppointmentStatus.Scheduled;     // وضعیت اولیه: برنامه‌ریزی شده
            AppointmentTime = DateTime.Now.AddDays(1); // فردا همین وقت
            DurationMinutes = 30;                     // ۳۰ دقیقه
        }
        public Appointment(int id, Patient patient, Doctor doctor, DateTime time, AppointmentType type)
        {
            AppointmentId = id;
            Patient = patient;
            Doctor = doctor;
            AppointmentTime = time;
            Type = type;
            Status = AppointmentStatus.Scheduled;
            DurationMinutes = 30;
        }

        // متد محاسبه زمان پایان نوبت
        public DateTime GetEndTime()
        {
            return AppointmentTime.AddMinutes(DurationMinutes);
        }

        // (بررسی آیا نوبت فعال است(در حال انجام
        public bool IsActiveNow()
        {
            DateTime now = DateTime.Now;
            return Status == AppointmentStatus.Scheduled &&
                   now >= AppointmentTime.AddMinutes(-15) &&
                   now <= GetEndTime();
        }

        // بررسی آیا قابل لغو است
        public bool CanBeCancelled()
        {
            return Status == AppointmentStatus.Scheduled &&
                   (AppointmentTime - DateTime.Now).TotalHours >= 2;
        }

        // لغو نوبت
        public void Cancel(string reason)
        {
            if (!CanBeCancelled())
                throw new InvalidOperationException("این قرار قابل لغو نیست");

            Status = AppointmentStatus.Cancelled;
            Description += $"\nلغو شده: {reason} ({DateTime.Now})";
        }

        // تکمیل نوبت
        public void Complete(string diagnosis, string prescription)
        {
            if (Status != AppointmentStatus.Scheduled)
                throw new InvalidOperationException("فقط قرارهای برنامه‌ریزی شده قابل تکمیل هستند");

            Status = AppointmentStatus.Completed;
            Description += $"\nتشخیص: {diagnosis}\nنسخه: {prescription} ({DateTime.Now})";
        }

        // محاسبه هزینه نهایی با بیمه
        public decimal CalculateFinalFee()
        {
            decimal finalFee = VisitFee;

            if (IsInsuranceAccepted && Patient != null)
            {
                finalFee *= 0.3m; // بیمه ۷۰٪ می‌پردازد
            }

            return finalFee;
        }

        // اطلاعات نوبت
        public string GetAppointmentInfo()
        {
            return $"قرار #{AppointmentId}: {Patient?.GetFullName()} با دکتر {Doctor?.GetFullName()} " +
                   $"در {AppointmentTime:yyyy/MM/dd HH:mm}";
        }

        // ایندکسر
        public object this[string key]
        {
            get
            {
                switch (key.ToLower())
                {
                    case "id": return AppointmentId;
                    case "time": return AppointmentTime;
                    case "patient": return Patient?.GetFullName();
                    case "doctor": return Doctor?.GetFullName();
                    case "status": return Status.ToString();
                    case "fee": return CalculateFinalFee();
                    default: throw new ArgumentException("کلید نامعتبر");
                }
            }
        }
    }
}