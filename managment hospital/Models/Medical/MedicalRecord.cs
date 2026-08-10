using HospitalManagementSystem.Models.People;

namespace HospitalManagementSystem.Models.Medical
{
    // نگهداری تاریخچه پزشکی بیمار
    public class MedicalRecord
    {
        private int _recordId;                   // شماره منحصر به فرد سابقه
        private DateTime _recordDate;            // تاریخ ثبت سابقه

        // شماره سابقه پزشکی
        public int RecordId
        {
            get { return _recordId; }              
            set
            {
                if (value <= 0)                   
                    throw new ArgumentException("شماره سابقه باید بزرگتر از صفر باشد");
                _recordId = value;                 
            }
        }
        public DateTime RecordDate
        {
            get { return _recordDate; }            // برگرداندن تاریخ
            set
            {
                if (value > DateTime.Now)          // تاریخ نمی‌تواند در آینده باشد
                    throw new ArgumentException("تاریخ سابقه نمی‌تواند در آینده باشد");
                _recordDate = value;               // ذخیره تاریخ معتبر
            }
        }
        public Patient Patient { get; set; }  // بیمار مربوط به این سابقه
        public Doctor Doctor { get; set; }   // پزشک ثبت‌کننده سابقه
        public string RecordType { get; set; }// (... نوع سابقه (معاینه اولیه، پیگیری       
        public string Diagnosis { get; set; } // تشخیص بیماری (Diagnosis)
        public string Prescription { get; set; }  // نسخه تجویزی       
        public string DoctorOrders { get; set; } // دستورات پزشک        
        public string TestResults { get; set; } // نتایج آزمایش‌ها
        public string Notes { get; set; }       // توضیحات اضافی
        public bool WasHospitalized { get; set; }    // آیا بیمار بستری شده؟
        public int? HospitalizationDays { get; set; }    // (مدت بستری (اگر بستری شده
        public List<MedicalProcedure> Procedures { get; private set; } // لیست اقدامات پزشکی انجام شده
        public List<Medication> Medications { get; private set; }     // لیست داروهای تجویز شده
        
        public MedicalRecord()
        {
            RecordDate = DateTime.Now;              
            Procedures = new List<MedicalProcedure>(); 
            Medications = new List<Medication>();   
        }
        public MedicalRecord(int recordId, Patient patient, Doctor doctor, string diagnosis)
        {
            RecordId = recordId;                    
            Patient = patient;                      
            Doctor = doctor;                        
            Diagnosis = diagnosis;              
            RecordDate = DateTime.Now;             
            Procedures = new List<MedicalProcedure>(); 
            Medications = new List<Medication>();  
        }
        // متداضافه کردن یک اقدام پزشکی به سابقه
        public void AddProcedure(MedicalProcedure procedure)
        {
            if (procedure == null)       
                Procedures.Add(procedure);              
        }

        // اضافه کردن یک دارو به سابقه
        public void AddMedication(Medication medication)
        {
            if (medication == null)
                throw new ArgumentNullException("دارو نمی‌تواند null باشد");


            Medications.Add(medication);           
        }

        // محاسبه هزینه کل سابقه پزشکی
        public decimal CalculateTotalCost()
        {
            decimal totalCost = 0;                  

            // جمع هزینه اقدامات پزشکی
            foreach (var procedure in Procedures)
            {
                totalCost += procedure.Cost;        // اضافه کردن هزینه هر اقدام
            }

            // جمع هزینه داروها
            foreach (var medication in Medications)
            {
                totalCost += medication.TotalCost;  // اضافه کردن هزینه هر دارو
            }

            return totalCost;                       // برگرداندن جمع کل
        }

        // گرفتن خلاصه سابقه پزشکی
        public string GetSummary()
        {
            string summary = $"سابقه #{RecordId} - بیمار: {Patient?.GetFullName()}\n";
            summary += $"تاریخ: {RecordDate:yyyy/MM/dd} - پزشک: {Doctor?.GetFullName()}\n";
            summary += $"تشخیص: {Diagnosis}\n";

            if (Procedures.Count > 0)
                summary += $"تعداد اقدامات: {Procedures.Count}\n";

            if (Medications.Count > 0)
                summary += $"تعداد داروها: {Medications.Count}\n";

            return summary;                        
        }

        // بررسی آیا سابقه کامل است (تشخیص دارد)و
        public bool IsComplete()
        {
            return !string.IsNullOrWhiteSpace(Diagnosis); // اگر تشخیص خالی نباشد
        }

        // ایجاد یک کپی از سابقه برای ارجاع
        public MedicalRecord CreateCopy()
        {
            // ایجاد یک سابقه جدید با اطلاعات اصلی
            MedicalRecord copy = new MedicalRecord
            {
                RecordId = this.RecordId + 1000,    // شماره متفاوت برای کپی
                Patient = this.Patient,
                Doctor = this.Doctor,
                RecordDate = DateTime.Now,          // تاریخ جدید
                Diagnosis = this.Diagnosis,
                Prescription = this.Prescription,
                Notes = $"کپی از سابقه #{this.RecordId} - {DateTime.Now}"
            };

            return copy;                      
        }

        // متد جنریک برای جستجو در لیست‌ها
        public List<T> SearchInList<T>(List<T> list, Func<T, bool> condition)
        {
            List<T> result = new List<T>();         // ایجاد لیست نتیجه

            foreach (T item in list)                // بررسی هر آیتم در لیست
            {
                if (condition(item))  
                {
                    result.Add(item);               // اضافه کردن به نتیجه
                }
            }

            return result;                          // برگرداندن لیست نتیجه
        }

        // استفاده از متد جنریک برای جستجوی داروها
        public List<Medication> FindMedicationsByType(string medicationType)
        {
            // استفاده از متد جنریک برای جستجو
            return SearchInList(Medications, m => m.Type == medicationType);
        }

        // رویداد به‌روزرسانی سابقه پزشکی
        public event EventHandler<MedicalRecordUpdatedEventArgs> RecordUpdated;

        // متد برای به‌روزرسانی تشخیص
        public void UpdateDiagnosis(string newDiagnosis, string reason)
        {
            string oldDiagnosis = Diagnosis;        // ذخیره تشخیص قدیمی
            Diagnosis = newDiagnosis;               // تنظیم تشخیص جدید
            Notes += $"\nتشخیص تغییر کرد از '{oldDiagnosis}' به '{newDiagnosis}'. دلیل: {reason}";

            // فعال کردن رویداد به‌روزرسانی
            OnRecordUpdated(new MedicalRecordUpdatedEventArgs(this, "Diagnosis", oldDiagnosis, newDiagnosis));
        }

        // متد فعال‌کننده رویداد
        protected virtual void OnRecordUpdated(MedicalRecordUpdatedEventArgs e)
        {
            RecordUpdated?.Invoke(this, e);         // اگر کسی گوش داده، فراخوانی کن
        }

        
        // ایندکسر => دسترسی به بخش‌های مختلف سابقه با کلید
        public object this[string key]
        {
            get
            {
                switch (key.ToLower())        
                {
                    case "id": return RecordId;   
                    case "date": return RecordDate; 
                    case "patient": return Patient?.GetFullName(); 
                    case "doctor": return Doctor?.GetFullName(); 
                    case "diagnosis": return Diagnosis; 
                    case "cost": return CalculateTotalCost(); 
                    case "complete": return IsComplete(); 
                    default: throw new ArgumentException("کلید نامعتبر");
                }
            }
        }
    }

  
    // کلاس اقدام پزشکی
    public class MedicalProcedure
    {
        public string Name { get; set; }           // (نام اقدام (مثل عکسبرداری، آزمایش خون
        public DateTime ProcedureDate { get; set; } // تاریخ اقدام
        public string Description { get; set; }    // توضیحات
        public decimal Cost { get; set; }          // هزینه اقدام
        public string Result { get; set; }         // نتیجه اقدام
    }

    // کلاس دارو
    public class Medication
    {
        public string Name { get; set; }           // نام دارو
        public string Type { get; set; }           // (نوع دارو (قرص، شربت، آمپول
        public string Dosage { get; set; }         // (دوز مصرف (مثل روزی دو بار
        public int DurationDays { get; set; }      // (مدت مصرف (تعداد روزها
        public decimal UnitPrice { get; set; }     // قیمت واحد
        public int Quantity { get; set; }          // تعداد
        public decimal TotalCost                   // هزینه کل این دارو
        {
            get { return UnitPrice * Quantity; }   // محاسبه خودکار
        }
    }

    // آرگومان رویداد به‌روزرسانی سابقه پزشکی
    public class MedicalRecordUpdatedEventArgs : EventArgs
    {
        public MedicalRecord Record { get; }       // سابقه به‌روز شده
        public string FieldName { get; }           // نام فیلد تغییر کرده
        public object OldValue { get; }            // مقدار قدیمی
        public object NewValue { get; }            // مقدار جدید
        public DateTime UpdateTime { get; }        // زمان به‌روزرسانی

        public MedicalRecordUpdatedEventArgs(MedicalRecord record, string fieldName,
                                           object oldValue, object newValue)
        {
            Record = record;                       
            FieldName = fieldName;                 
            OldValue = oldValue;                   
            NewValue = newValue;                   
            UpdateTime = DateTime.Now;             
        }
    }
}