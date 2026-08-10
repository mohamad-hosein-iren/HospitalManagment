using System;
using System.Collections.Generic;
using HospitalManagementSystem.Models.People;

namespace HospitalManagementSystem.Models.Hospital
{
    public class Department
    {
        private string _departmentCode;  // مثلا برای اورژانس:ER <=کد بخش  
        private string _departmentName;  // ("نام بخش (مثلاً "اورژانس
        public string DepartmentCode
        {
            get { return _departmentCode; }       
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // بررسی خالی نبودن
                    throw new ArgumentException("کد بخش نمی‌تواند خالی باشد");
                _departmentCode = value.ToUpper();    // تبدیل به حروف بزرگ و ذخیره
            }
        }
        public string DepartmentName
        {
            get { return _departmentName; }          
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // بررسی خالی نبودن
                    throw new ArgumentException("نام بخش نمی‌تواند خالی باشد");
                _departmentName = value;              
            }
        }

        public HospitalDepartment DepartmentType { get; set; }   // نوع بخش (enum) 
        public Doctor HeadDoctor { get; set; }                   // پزشک مسئول بخش
        public Nurse HeadNurse { get; set; }                     // پرستار سرپرست بخش
        public int TotalBeds { get; set; }                       // تعداد کل تخت‌های بخش
        public int AvailableBeds { get; set; }                   // تعداد تخت‌های خالی
        public string PhoneNumber { get; set; }                  // شماره تلفن داخلی بخش        
        public string Location { get; set; }                     //("محل بخش در بیمارستان (مثلاً "طبقه ۲، جنب آسانسور
        public List<Doctor> Doctors { get; set; }                // لیست پزشکان شاغل در این بخش         
        public List<Nurse> Nurses { get;set; }                   // لیست پرستاران این بخش        
        public List<Patient> Patients { get; set; }              // لیست بیماران حاضر در این بخش
        
        public Department()
        {
            Doctors = new List<Doctor>();      // ایجاد لیست خالی برای پزشکان
            Nurses = new List<Nurse>();        // ایجاد لیست خالی برای پرستاران
            Patients = new List<Patient>();    // ایجاد لیست خالی برای بیماران
        }
        public Department(string code, string name, HospitalDepartment type)
        {
            DepartmentCode = code;            
            DepartmentName = name;            
            DepartmentType = type;            

            Doctors = new List<Doctor>();      // ایجاد لیست پزشکان
            Nurses = new List<Nurse>();        // ایجاد لیست پرستاران
            Patients = new List<Patient>();    // ایجاد لیست بیماران
        }

        // متد اضافه کردن پزشک به بخش
        public void AddDoctor(Doctor doctor)
        {
            if (doctor == null)                // بررسی نال نبودن پزشک
                throw new ArgumentNullException("پزشک نمی‌تواند null باشد");

            if (!Doctors.Contains(doctor))     // بررس اینکه پزشک قبلاً اضافه نشده
            {
                Doctors.Add(doctor);           
            }
        }
        // اضافه کردن پرستار به بخش
        public void AddNurse(Nurse nurse)
        {
            if (nurse == null)                 // بررسی نال نبودن پرستار
                throw new ArgumentNullException("پرستار نمی‌تواند null باشد");

            if (!Nurses.Contains(nurse))       // بررسی اینکه پرستار قبلاً اضافه نشده
            {
                Nurses.Add(nurse);             
            }
        }
        // پذیرش بیمار در بخش
        public void AdmitPatient(Patient patient)
        {
            if (patient == null)               // بررسی نال نبودن بیمار
                throw new ArgumentNullException("بیمار نمی‌تواند null باشد");

            if (AvailableBeds <= 0)            // بررسی ظرفیت خالی
                throw new InvalidOperationException("ظرفیت بخش تکمیل است");

            if (!Patients.Contains(patient))   // اگر بیمار قبلاً پذیرش نشده
            {
                Patients.Add(patient);         
                AvailableBeds--;               // کاهش تخت‌های خالی
            }
        }

        // ترخیص بیمار از بخش
        public void DischargePatient(Patient patient)
        {
            if (Patients.Remove(patient))      // اگر بیمار در لیست بود و حذف شد
            {
                AvailableBeds++;               // افزایش تخت‌های خالی
            }
        }

        // محاسبه درصد اشغال تخت‌ها
        public double CalculateOccupancyRate()
        {
            if (TotalBeds == 0)                // اگر هیچ تختی وجود ندارد
                return 0;

            int occupiedBeds = TotalBeds - AvailableBeds; // تخت‌های اشغال شده
            return (occupiedBeds * 100.0) / TotalBeds;    // درصد اشغال
        }

        // گرفتن تعداد پرسنل بخش
        public int GetStaffCount()
        {
            return Doctors.Count + Nurses.Count; // جمع پزشکان و پرستاران
        }

        // بررسی آیا بخش ظرفیت خالی دارد
        public bool HasAvailableBeds()
        {
            return AvailableBeds > 0;          // اگر حداقل یک تخت خالی باشد
        }

        // گرفتن اطلاعات خلاصه بخش
        public string GetDepartmentInfo()
        {
            double occupancy = CalculateOccupancyRate(); // محاسبه درصد اشغال
            return $"{DepartmentName} ({DepartmentCode}) | " +
                   $"تخت‌ها: {AvailableBeds}/{TotalBeds} | " +
                   $"اشغال: {occupancy:F1}% | پرسنل: {GetStaffCount()} نفر";
        }

    
        //(indexer) امکان دسترسی به اطلاعات بخش با کلیدهای مختلف
        public object this[string key]
        {
            get
            {
                switch (key.ToLower())              // بررسی کلید وارد شده
                {
                    case "code": return DepartmentCode;                  // کد بخش
                    case "name": return DepartmentName;                  // نام بخش
                    case "type": return DepartmentType.ToString();       // نوع بخش
                    case "beds": return $"{AvailableBeds}/{TotalBeds}";  // وضعیت تخت‌ها
                    case "occupancy": return CalculateOccupancyRate();   // درصد اشغال
                    case "staff": return GetStaffCount();                // تعداد پرسنل
                    case "patients": return Patients.Count;              // تعداد بیماران
                    default: throw new ArgumentException("کلید نامعتبر");
                }
            }
        }

        //  امکان مقایسه دو بخش از نظر ظرفیت باتحریف عملگر
        public static bool operator >(Department d1, Department d2)
        {
            return d1.TotalBeds > d2.TotalBeds; // مقایسه تعداد کل تخت‌ها
        }

        public static bool operator <(Department d1, Department d2)
        {
            return d1.TotalBeds < d2.TotalBeds; // مقایسه تعداد کل تخت‌ها
        }
    }
}