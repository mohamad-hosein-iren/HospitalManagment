namespace HospitalManagementSystem.Models.People
{
    public class Employee : Person
    {
        private string _employeeId;      // شماره پرسنلی
        private decimal _salary;         // حقوق

        // شماره پرسنلی=> منحصر به فرد
        public string EmployeeId
        {
            get { return _employeeId; }
            set
            {
                bool _isset = false;
                if (_isset)
                    throw new ArgumentException("فقط یکبار میتوان مقدار دهی کرد");
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("شماره پرسنلی نمی‌تواند خالی باشد");

                _employeeId = value;
                _isset = true;
            }
        }
        public decimal Salary                    // حقوق
        {
            get { return _salary; }
            set
            {
                if (value >= 0)
                    _salary = value;
                else
                    throw new ArgumentException("حقوق نمی‌تواند منفی باشد");
            }
        }
        public string Position { get; set; }     // پست سازمانی
        public string Department { get; set; }   // بخش محل کار              
        public DateTime HireDate { get; set; }  // تاریخ شروع به کار        
        public bool IsActive { get; set; }            // وضعیت استخدام       
        public AccessLevel AccessLevel { get; set; }  // سطح دسترسی در سیستم

        public Employee()
        {
            IsActive = true;
            HireDate = DateTime.Now;
            AccessLevel = AccessLevel.Basic;
        }
        public Employee(string nationalCode, string firstName, string lastName,
                       string employeeId, string position, string department)
            : base(nationalCode, firstName, lastName)  
        {
            EmployeeId = employeeId;
            Position = position;
            Department = department;
            IsActive = true;
            HireDate = DateTime.Now;
            AccessLevel = AccessLevel.Basic;
        }

        // متد محاسبه سنوات خدمت
        public int CalculateServiceYears()
        {
            TimeSpan serviceTime = DateTime.Now - HireDate;
            return (int)(serviceTime.TotalDays / 365.25);
        }

        // متد محاسبه حقوق با احتساب سنوات
        public decimal CalculateFinalSalary()
        {
            int serviceYears = CalculateServiceYears();
            decimal finalSalary = Salary;

            // اضافه حقوق براساس سنوات خدمت
            if (serviceYears > 10)
                finalSalary += Salary * 0.15m;  // 15% اضافه
            else if (serviceYears > 5)
                finalSalary += Salary * 0.10m;  // 10% اضافه
            else if (serviceYears > 2)
                finalSalary += Salary * 0.05m;  // 5% اضافه

            return finalSalary;
        }

        // متد ترفیع پست
        public void Promote(string newPosition, decimal salaryIncrease)
        {
            Position = newPosition;
            Salary += salaryIncrease;

            // فعال کردن رویداد ترفیع
            OnPromoted(new EmployeePromotedEventArgs(newPosition, salaryIncrease));
        }

        // تغییر وضعیت فعال/غیرفعال
        public void ChangeEmploymentStatus(bool isActive)
        {
            bool oldStatus = IsActive;
            IsActive = isActive;

        //فعال کردن رویداد تغییر وضعیت
            OnEmploymentStatusChanged(new EmploymentStatusChangedEventArgs(oldStatus, isActive));
        }

        // Override متد GetInfo
        public override string GetInfo()
        {
            string status = IsActive ? "فعال" : "غیرفعال";
            return $"{GetFullName()} | پست: {Position} | بخش: {Department} | وضعیت: {status}";
        }

        // Overload متد برای نمایش اطلاعات مالی
        public string GetInfo(bool includeFinancial)
        {
            string info = GetInfo();

            if (includeFinancial)
            {
                info += $" | حقوق پایه: {Salary:N0} تومان";
                info += $" | حقوق نهایی: {CalculateFinalSalary():N0} تومان";
                info += $" | سنوات: {CalculateServiceYears()} سال";
            }

            return info;
        }

        // رویداد ترفیع کارمند
        public event EventHandler<EmployeePromotedEventArgs> Promoted;

        // رویداد تغییر وضعیت استخدام
        public event EventHandler<EmploymentStatusChangedEventArgs> EmploymentStatusChanged;

        // متدهای فعال‌کننده رویدادها
        protected virtual void OnPromoted(EmployeePromotedEventArgs e)
        {
            Promoted?.Invoke(this, e);
        }

        protected virtual void OnEmploymentStatusChanged(EmploymentStatusChangedEventArgs e)
        {
            EmploymentStatusChanged?.Invoke(this, e);
        }
        public override string GetPrintableFormat()
        {
            return $"Staff: {GetFullName()} | Position: {Position} | ID: {_employeeId}";
        }
    }
 
    // کلاس آرگومان رویداد ترفیع کارمند
    public class EmployeePromotedEventArgs : EventArgs
    {
        public string NewPosition { get; }
        public decimal SalaryIncrease { get; }
        public DateTime PromotionDate { get; }

        public EmployeePromotedEventArgs(string newPosition, decimal salaryIncrease)
        {
            NewPosition = newPosition;
            SalaryIncrease = salaryIncrease;
            PromotionDate = DateTime.Now;
        }
    }


    // کلاس آرگومان رویداد تغییر وضعیت استخدام

    public class EmploymentStatusChangedEventArgs : EventArgs
    {
        public bool OldStatus { get; }
        public bool NewStatus { get; }
        public DateTime ChangeDate { get; }

        public EmploymentStatusChangedEventArgs(bool oldStatus, bool newStatus)
        {
            OldStatus = oldStatus;
            NewStatus = newStatus;
            ChangeDate = DateTime.Now;
        }
    }
}