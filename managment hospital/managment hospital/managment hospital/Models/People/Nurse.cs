using HospitalManagementSystem.Models.Hospital;

namespace HospitalManagementSystem.Models.People
{
    public class Nurse : Person
    {
        
        private string _nursingLicenseNumber;  // شماره پروانه پرستاری
        private int _experienceYears;         // سال‌های تجربه  
        private decimal _baseSalary;          // حقوق پایه
         

        // شماره پروانه پرستاری => منحصر به فرد
        public string NursingLicenseNumber
        {
            get { return _nursingLicenseNumber; }
            set
            {
                bool _isset = false;
                if (_isset)
                    throw new ArgumentException("فقط یکبار میتوان مقدار دهی کرد");
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("شماره پروانه پرستاری نمی‌تواند خالی باشد");

                _nursingLicenseNumber = value;
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


        public HospitalDepartment Department { get; set; } // بخش محل کار        
        public WorkShift Shift { get; set; }               // شیفت کاری                
        public bool IsHeadNurse { get; set; }              // آیا سرپرست است؟
        public List<string> Specializations { get; private set; }    // تخصص‌های ویژه: ICU، اتاق عمل، اطفال
        public List<Patient> AssignedPatients { get; private set; }  // بیماران تحت مراقبت

        public Nurse()
        {
            Specializations = new List<string>();
            AssignedPatients = new List<Patient>();
        }
        public Nurse(string nationalCode, string firstName, string lastName,
                    string nursingLicenseNumber, HospitalDepartment department)
            : base(nationalCode, firstName, lastName)  
        {
            NursingLicenseNumber = nursingLicenseNumber;
            Department = department;
            Specializations = new List<string>();
            AssignedPatients = new List<Patient>();
        }

        // متد محاسبه حقوق نهایی 
        public decimal CalculateSalary()
        {
            decimal finalSalary = BaseSalary;

            // اضافه حقوق برای تجربه
            if (ExperienceYears > 10)
                finalSalary += 800000;
            else if (ExperienceYears > 5)
                finalSalary += 400000;
            else if (ExperienceYears > 2)
                finalSalary += 200000;

            // اضافه حقوق برای سرپرست بودن
            if (IsHeadNurse)
                finalSalary += 1000000;

            // اضافه حقوق برای شیفت شب
            if (Shift == WorkShift.Night)
                finalSalary += 300000;

            return finalSalary;
        }

        // متد اضافه کردن تخصص
        public void AddSpecialization(string specialization)
        {
            if (!string.IsNullOrWhiteSpace(specialization) && !Specializations.Contains(specialization))
            {
                Specializations.Add(specialization);
            }
        }

        // متد اضافه کردن بیمار به لیست بیماران تحت مراقبت
        public void AssignPatient(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException("بیمار نمیتواند خالی باشد");

            if (!AssignedPatients.Contains(patient))
            {
                AssignedPatients.Add(patient);
            }
        }

        // متد حذف بیمار از لیست
        public bool RemovePatient(Patient patient)
        {
            return AssignedPatients.Remove(patient);
        }

        // متد گرفتن تعداد بیماران تحت مراقبت
        public int GetPatientCount()
        {
            return AssignedPatients.Count;
        }

        // (بررسی آیا پرستار می‌تواند بیمار را بپذیرد (براساس ظرفیت
        public bool CanAcceptMorePatients(int maxPatientsPerNurse = 5)
        {
            return AssignedPatients.Count < maxPatientsPerNurse;
        }

        // (Override) متد دریافت نام کامل
        public override string GetFullName()
        {
            string title = IsHeadNurse ? "سرپرستار " : "پرستار ";
            return $"{title}{base.GetFullName()}";
        }

        // (Override) GetInfoمتد  
        public override string GetInfo()
        {
            string headInfo = IsHeadNurse ? "| سرپرست" : "";
            return $"{GetFullName()} | بخش: {Department} | شیفت: {Shift} {headInfo}";
        }

        // (Overload) متد برای نمایش اطلاعات کامل‌تر
        public string GetInfo(bool includeDetails)
        {
            string info = GetInfo();

            if (includeDetails)
            {
                info += $" | تجربه: {ExperienceYears} سال";
                info += $" | حقوق: {CalculateSalary():N0} تومان";

                if (Specializations.Count > 0)
                {
                    info += $" | تخصص‌ها: {string.Join(", ", Specializations)}";
                }
            }

            return info;
        }
        

        // تعریف گزارش پرستاری Delegate
        public delegate void NursingReportDelegate(string reportContent, DateTime reportTime);

        //  برای گزارش‌های پرستاریEvent
        public event NursingReportDelegate NursingReportSubmitted;

        // متد برای ثبت گزارش پرستاری
        public void SubmitNursingReport(string patientName, string reportDetails)
        {
            string reportContent = $"گزارش پرستاری برای بیمار {patientName}: {reportDetails}";
            DateTime reportTime = DateTime.Now;

            // (ذخیره گزارش در سیستم (اینجا فقط چاپ می‌کنیم
            Console.WriteLine($"گزارش ثبت شد: {reportContent}");

            //  (اگر کسی به آن گوش داده باشد(فعال کردنEvent
            OnNursingReportSubmitted(reportContent, reportTime);
        }

        //Event متد برای فعال کردن 
        protected virtual void OnNursingReportSubmitted(string reportContent, DateTime reportTime)
        {
            NursingReportSubmitted?.Invoke(reportContent, reportTime);
        }
        public override string GetPrintableFormat()
        {
            return $"Nurse: {GetFullName()} | Registration: {_nursingLicenseNumber} | Department: {Department}";
        }
    }
}