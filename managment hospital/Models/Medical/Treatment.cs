using System;
using System.Collections.Generic;
using HospitalManagementSystem.Models.People;

namespace HospitalManagementSystem.Models.Medical
{
    public class Treatment
    {
        public int TreatmentId { get; set; }               // شماره درمان
        public string TreatmentName { get; set; }          // نام درمان
        public Patient Patient { get; set; }               // بیمار
        public Doctor Doctor { get; set; }                 // پزشک
        public DateTime StartDate { get; set; }            // تاریخ شروع
        public DateTime? EndDate { get; set; }             // تاریخ پایان
        public string Description { get; set; }            // توضیحات
        public decimal Cost { get; set; }                  // هزینه
        public bool IsCompleted { get; set; }              // تکمیل شده؟        
        public List<TreatmentSession> Sessions { get; private set; }// لیست جلسات درمانی         
        
        public Treatment()
        {
            StartDate = DateTime.Now;
            Sessions = new List<TreatmentSession>();
        }

        // اضافه کردن جلسه 
        public void AddSession(TreatmentSession session)
        {
            Sessions.Add(session);
        }

        // تکمیل درمان
        public void Complete()
        {
            IsCompleted = true;
            EndDate = DateTime.Now;
        }

        // اطلاعات درمان
        public string GetTreatmentInfo()
        {
            return $"درمان #{TreatmentId}: {TreatmentName} برای {Patient?.GetFullName()}";
        }
    }


    //کلاس کمکی
    // کلاس جلسه درمانی
    public class TreatmentSession
    {
        public int SessionNumber { get; set; }      // شماره جلسه
        public DateTime SessionDate { get; set; }   // تاریخ جلسه
        public string Notes { get; set; }           // یادداشت‌ها
        public bool IsCompleted { get; set; }       // انجام شده؟
    }
}