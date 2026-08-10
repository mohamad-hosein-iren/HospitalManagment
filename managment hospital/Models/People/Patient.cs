namespace HospitalManagementSystem.Models.People
{
    public class Patient : Person
    {
        private int _patientId;          // شماره بیمار (منحصر به فرد
        private string _insuranceNumber; // شماره بیمه

        // شماره بیمار=> منحصر به فرد
        public int PatientId
        {
            get { return _patientId; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("شماره بیمار باید بزرگتر از صفر باشد");

                _patientId = value;
            }
        }
        // شماره بیمه
        public string InsuranceNumber
        {
            get { return _insuranceNumber; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _insuranceNumber = value;
            }
        }
        public PatientType PatientType { get; set; } // نوع بیمار => بستری یا سرپایی        
        public PatientStatus Status { get; set; }   // وضعیت فعلی بیمار        
        public Doctor AttendingDoctor { get; set; } // پزشک معالج       
        public DateTime AdmissionDate { get; set; } // تاریخ پذیرش        
        public DateTime? DischargeDate { get; set; }       //تاریخ ترخیص (در صورت وجود)        
        public int? RoomNumber { get; set; }         //(شماره اتاق (برای بیماران بستری        
        public int? BedNumber { get; set; }         // (شماره تخت (برای بیماران بستری       
        public List<string> Diseases { get; private set; } // لیست بیماری‌ها        
        public List<string> Medications { get; private set; }// لیست داروها

        public Patient()
        {
            Diseases = new List<string>();
            Medications = new List<string>();
            Status = PatientStatus.Stable;
            AdmissionDate = DateTime.Now;
        }
        public Patient(int patientId, string nationalCode, string firstName,
                      string lastName, PatientType patientType)
            : base(nationalCode, firstName, lastName)  
        {
            PatientId = patientId;
            PatientType = patientType;
            Diseases = new List<string>();
            Medications = new List<string>();
            Status = PatientStatus.Stable;
            AdmissionDate = DateTime.Now;
        }
        // متد محاسبه مدت اقامت در بیمارستان
        public int CalculateStayDuration()
        {
            DateTime endDate = DischargeDate ?? DateTime.Now;
            TimeSpan duration = endDate - AdmissionDate;
            return duration.Days;
        }

        // متد اضافه کردن بیماری 
        public void AddDisease(string disease)
        {
            if (!string.IsNullOrWhiteSpace(disease) && !Diseases.Contains(disease))
            {
                Diseases.Add(disease);
            }
        }

        // متد اضافه کردن دارو
        public void AddMedication(string medication)
        {
            if (!string.IsNullOrWhiteSpace(medication) && !Medications.Contains(medication))
            {
                Medications.Add(medication);
            }
        }

        // ترخیص بیمار
        public void Discharge()
        {
            if (Status != PatientStatus.Discharged)
            {
                Status = PatientStatus.Discharged;
                DischargeDate = DateTime.Now;
            }
        }

        // متد بررسی آیا بیمار بستری است
        public bool IsInpatient()
        {
            return PatientType == PatientType.Inpatient;
        }

        // متد بررسی آیا بیمار ترخیص شده است
        public bool IsDischarged()
        {
            return Status == PatientStatus.Discharged;
        }

        // (Override)  برای نمایش اطلاعات بیمار GetInfoمتد
        public override string GetInfo()
        {
            string patientType = IsInpatient() ? "بستری" : "سرپایی";
            string statusText = GetStatusText();
            string doctorName = AttendingDoctor != null ? AttendingDoctor.FirstName : "تعیین نشده";

            return $"بیمار: {GetFullName()} | نوع: {patientType} | وضعیت: {statusText} | پزشک: {doctorName}";
        }

        // متد گرفتن متن وضعیت بیمار
        private string GetStatusText()
        {
            switch (Status)
            {
                case PatientStatus.Stable: return "پایدار";
                case PatientStatus.Critical: return "بحرانی";
                case PatientStatus.Recovering: return "در حال بهبود";
                case PatientStatus.Discharged: return "ترخیص شده";
                default: return "نامشخص";
            }
        }
        // رویداد تغییر وضعیت بیمار
        public event EventHandler<PatientStatusChangedEventArgs> StatusChanged;

        // متد برای تغییر وضعیت بیمار و فعال کردن رویداد
        public void ChangeStatus(PatientStatus newStatus, string reason)
        {
            PatientStatus oldStatus = Status;
            Status = newStatus;

            // فعال کردن رویداد اگر کسی به آن گوش داده باشد
            OnStatusChanged(new PatientStatusChangedEventArgs(oldStatus, newStatus, reason));
        }

        // متد برای فعال کردن رویداد
        protected virtual void OnStatusChanged(PatientStatusChangedEventArgs e)
        {
            StatusChanged?.Invoke(this, e);
        }
        public override string GetPrintableFormat()
        {
            return $"Patient: {GetFullName()} | Patient #: {_patientId} | Type: {PatientType}";
        }
    }

     //کلاس مربوط به ایونت
    public class PatientStatusChangedEventArgs : EventArgs
    {
        public PatientStatus OldStatus { get; }
        public PatientStatus NewStatus { get; }
        public string Reason { get; }
        public DateTime ChangeTime { get; }

        public PatientStatusChangedEventArgs(PatientStatus oldStatus, PatientStatus newStatus, string reason)
        {
            OldStatus = oldStatus;
            NewStatus = newStatus;
            Reason = reason;
            ChangeTime = DateTime.Now;
        }
    }
}