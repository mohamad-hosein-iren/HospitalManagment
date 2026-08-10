using managment_hospital.Interface;

namespace HospitalManagementSystem.Models.People
{
    public abstract class  Person : IComparable<Person> , IIdentifiable, IPrintable
    {
        private string _nationalCode;    // کد ملی
        private string _firstName;       // نام
        private string _lastName;        // نام خانوادگی
        private DateTime _birthDate;     // تاریخ تولد

        // کد ملی با اعتبارسنجی
        public string NationalCode
        {
            get { return _nationalCode; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 10)
                    throw new ArgumentException("کد ملی باید ۱۰ رقمی باشد");

                _nationalCode = value;
            }
        }

        // نام
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("نام نمی‌تواند خالی باشد");

                _firstName = value.Trim();
            }
        }

        // نام خانوادگی
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("نام خانوادگی نمی‌تواند خالی باشد");

                _lastName = value.Trim();
            }
        }

        // تاریخ تولد
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                // تاریخ تولد نمی‌تواند در آینده باشد
                if (value > DateTime.Now)
                    throw new ArgumentException("تاریخ تولد نمی‌تواند در آینده باشد");

                _birthDate = value;
            }
        }

        public Gender Gender { get; set; }                 // جنسیت
        public string PhoneNumber { get; set; }           // شماره تلفن
        public string Address { get; set; }               // آدرس
        public DateTime RegistrationDate { get; set; }    // تاریخ ثبت در سیستم

        
        public object this[string index]
        {
            get
            {
                switch (index.ToLower())
                {
                    case "name": return GetFullName();
                    case "age": return CalculateAge();
                    case "nationalcode": return NationalCode;
                    case "phone": return PhoneNumber;
                    default: throw new ArgumentException("کلید نامعتبر");
                }
            }
        }

        public Person()
        {
            RegistrationDate = DateTime.Now;
        }

        // سازنده با پارامتر
        public Person(string nationalCode, string firstName, string lastName)
        {
            NationalCode = nationalCode;
            FirstName = firstName;
            LastName = lastName;
            RegistrationDate = DateTime.Now;
        }

        // متد محاسبه سن 
        public int CalculateAge()
        {
            int age = DateTime.Now.Year - BirthDate.Year;

            // اگر هنوز روز تولد در امسال نرسیده باشد
            if (DateTime.Now.DayOfYear < BirthDate.DayOfYear) 
                age--;

            return age;
        }

        // گرفتن نام کامل
        public virtual string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        // نمایش اطلاعات شخص
        public virtual string GetInfo()
        {
            return $"نام: {GetFullName()} | کد ملی: {NationalCode} | سن: {CalculateAge()}";
        }
        public int CompareTo(Person other)
        {
            if (other == null) return 1;                                           //بی توجهی به بزرگ وکوچک بودن حروف
            int lastNameComparison = string.Compare(this._lastName, other._lastName, StringComparison.OrdinalIgnoreCase);
            if (lastNameComparison != 0) return lastNameComparison;
            return string.Compare(this._firstName, other._firstName, StringComparison.OrdinalIgnoreCase);
        }

        public abstract string GetPrintableFormat();
        public string GetId() => _nationalCode;

        public bool ValidateId()
        {
            return !string.IsNullOrWhiteSpace(_nationalCode) && _nationalCode.Length == 10;
        }
    }
}