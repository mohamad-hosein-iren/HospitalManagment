namespace HospitalManagementSystem.Models
{
    // انواع جنسیت برای افراد
    public enum Gender
    {
        Male = 1,       // مرد
        Female = 2,     // زن
    }

    // نوع پرسنل بیمارستان
    public enum PersonnelType
    {
        Doctor = 1,     // پزشک
        Nurse = 2,      // پرستار
        Employee = 3,   // کارمند اداری
        Technician = 4  // تکنسین
    }

    // وضعیت تأهل
    public enum MaritalStatus
    {
        Single = 1,     // مجرد
        Married = 2,    // متأهل
        Divorced = 3    // مطلقه
    }

    // نوع بیمار (بستری یا سرپایی)
    public enum PatientType
    {
        Outpatient = 1, // سرپایی
        Inpatient = 2   // بستری
    }

    // وضعیت فعلی بیمار
    public enum PatientStatus
    {
        Stable = 1,     // وضعیت پایدار
        Critical = 2,   // وضعیت بحرانی
        Recovering = 3, // در حال بهبود
        Discharged = 4  // ترخیص شده
    }

    // تخصص‌های پزشکی
    public enum MedicalSpecialty
    {
        General = 1,    // عمومی
        Cardiology = 2, // قلب و عروق
        Neurology = 3,  // مغز و اعصاب
        Orthopedics = 4,// ارتوپدی
        Pediatrics = 5, // اطفال
        Surgery = 6     // جراحی
    }

    // شیفت‌های کاری
    public enum WorkShift
    {
        Morning = 1,    // شیفت صبح
        Evening = 2,    // شیفت عصر
        Night = 3,      // شیفت شب
        Rotating = 4    // شیفت چرخشی
    }

    // بخش‌های بیمارستان
    public enum HospitalDepartment
    {
        Emergency = 1,  // اورژانس
        ICU = 2,        // مراقبت‌های ویژه
        Surgery = 3,    // جراحی
        Maternity = 4,  // زایمان
        Radiology = 5,  // رادیولوژی
        Laboratory = 6  // آزمایشگاه
    }

    // وضعیت اتاق‌ها
    public enum RoomStatus
    {
        Available = 1,  // خالی و قابل استفاده
        Occupied = 2,   // اشغال شده
        Maintenance = 3,// در دست تعمیر
        Reserved = 4    // رزرو شده
    }

    // انواع قرارها
    public enum AppointmentType
    {
        Consultation = 1,   // مشاوره
        Examination = 2,    // معاینه
        Surgery = 3,        // جراحی
        FollowUp = 4        // پیگیری
    }

    // وضعیت قرار ملاقات
    public enum AppointmentStatus
    {
        Scheduled = 1,  // برنامه‌ریزی شده
        Completed = 2,  // تکمیل شده
        Cancelled = 3,  // لغو شده
        NoShow = 4      // بیمار حاضر نشد
    }

    // وضعیت عملیات سیستم
    public enum OperationStatus
    {
        Success = 1,    // موفقیت‌آمیز
        Failed = 2,     // ناموفق
        Warning = 3,    // هشدار
        Info = 4        // اطلاعات
    }

    // نوع گزارش
    public enum ReportType
    {
        Daily = 1,      // گزارش روزانه
        Weekly = 2,     // گزارش هفتگی
        Monthly = 3,    // گزارش ماهانه
        Yearly = 4      // گزارش سالانه
    }
    //سطح دسترسی
    public enum AccessLevel
    {
        Basic = 1,        // دسترسی پایه
        Intermediate = 2, // دسترسی متوسط
        Advanced = 3,     // دسترسی پیشرفته
        Admin = 4         // دسترسی ادمین
    }
    //نوع تخت
    public enum BedType
    {
        Regular = 1,     // تخت معمولی
        ICU = 2,         // تخت مراقبت‌های ویژه
        Pediatric = 3,   // تخت کودکان
        Maternity = 4,   // تخت زایمان
        Isolation = 5    // تخت ایزوله
    }
    public enum BedStatus
    {
        Available = 1,   // خالی و آماده استفاده
        Occupied = 2,    // اشغال شده توسط بیمار
        Reserved = 3,    // رزرو شده برای آینده
        Cleaning = 4,    // در حال نظافت
        Maintenance = 5  // در حال تعمیر
    }
    public enum RoomType
    {
        General = 1,      // اتاق عمومی (چند تخته)
        Private = 2,      // اتاق خصوصی (تک تخته)
        VIP = 3,          // اتاق ویژه (امکانات خاص)
        Operating = 4,    // اتاق عمل
        ICU = 5           // اتاق مراقبت‌های ویژه
    }
}