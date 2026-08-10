using HospitalManagementSystem.Models.Hospital;

namespace HospitalManagementSystem.Models.People
{
    public class Doctor : Person
    {        
        private string _medicalCouncilNumber;  // شماره نظام پزشکی
        private int _experienceYears;          // سال‌های تجربه                                      
        private decimal _baseSalary;           // حقوق پایه
       
        // شماره نظام پزشکی => منحصر به فرد
        public string MedicalCouncilNumber
        {
            get { return _medicalCouncilNumber; }
            set
            {
                bool _isset = false;
                if (_isset)               
                    throw new ArgumentException("فقط یکبار میتوان مقدار دهی کرد");
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("شماره نظام پزشکی نمی‌تواند خالی باشد");

                _medicalCouncilNumber = value;
                _isset = true;
            }
        }
        public int ExperienceYears
        {
            get { return _experienceYears; }
            set
            {
                if (value >= 0)
                    _experienceYears = value;
                else
                    throw new ArgumentException("سال تجربه نمی‌تواند منفی باشد");
            }
        }
        public decimal BaseSalary
        {
            get { return _baseSalary; }
            set
            {
                if (value >= 0)
                    _baseSalary = value;
                else
                    throw new ArgumentException("حقوق نمی‌تواند منفی باشد");
            }
        }

        public MedicalSpecialty Specialty { get; set; }    // تخصص پزشکی
        public WorkShift WorkShift { get; set; }           // شیفت کاری        
        public bool IsResident { get; set; }                // آیا پزشک مقیم است؟        
        public HospitalDepartment Department { get; set; }  // بخش مربوطه در بیمارستان        
        public List<Patient> Patients { get; private set; } //لیست بیماران تحت درمان

        public Doctor()
        {
            Patients = new List<Patient>();
        }
        
        public Doctor(string nationalCode, string firstName, string lastName,
                     string medicalCouncilNumber, MedicalSpecialty specialty)
            : base(nationalCode, firstName, lastName) 
        {
            MedicalCouncilNumber = medicalCouncilNumber;
            Specialty = specialty;
            Patients = new List<Patient>();
        }

        // محاسبه حقوق نهایی با احتساب تجربه
        public decimal CalculateSalary()
        {
            decimal finalSalary = BaseSalary;

            // افزودن پاداش براساس سال تجربه
            if (ExperienceYears > 5)
                finalSalary += BaseSalary * 0.1m;  // 10% اضافه برای تجربه بالا
            else if (ExperienceYears > 2)
                finalSalary += BaseSalary * 0.05m; // 5% اضافه

            // افزودن پاداش برای پزشکان مقیم
            if (IsResident)
                finalSalary += 500000;  // اضافه حقوق برای مقیم بودن

            return finalSalary;
        }

        // اضافه کردن بیمار به لیست بیماران پزشک
        public void AddPatient(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException("بیمار نمی‌تواند null باشد");

            if (!Patients.Contains(patient))
            {
                Patients.Add(patient);
            }
        }

        
        // حذف بیمار از لیست بیماران پزشک
        public bool RemovePatient(Patient patient)
        {
            return Patients.Remove(patient);
        }
        
        // گرفتن تعداد بیماران تحت درمان
        public int GetPatientCount()
        {
            return Patients.Count;
        }

        // (Override) برای اضافه کردن عنوان دکتر GetFullName متد 
        public override string GetFullName()
        {
            return $"دکتر {base.GetFullName()}";
        }

        // (Override)برای نمایش اطلاعات پزشکGetInfo متد  
        public override string GetInfo()
        {
            string residentInfo = IsResident ? "| مقیم" : "| غیرمقیم";
            return $"{GetFullName()} | تخصص: {Specialty} | تجربه: {ExperienceYears} سال {residentInfo}";
        }

        // (Overload) متد برای گرفتن اطلاعات با جزئیات بیشتر
        public string GetInfo(bool includeSalary)
        {
            string info = GetInfo();

            if (includeSalary)
            {
                info += $" | حقوق: {CalculateSalary():N0} تومان";
            }

            return info;
        }

        // اضافه کردن دو پزشک برای ایجاد یک تیم
        public static string operator +(Doctor doc1, Doctor doc2)
        {
            return $"تیم {doc1.Specialty}: {doc1.FirstName} و {doc2.FirstName}";
        }
        public override string GetPrintableFormat()
        {
            return $"Doctor: {GetFullName()} | License: {_medicalCouncilNumber} | Department: {Department}";
        }
    }
}