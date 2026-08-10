# سیستم مدیریت بیمارستان پیشرفته (Hospital Management System)

 -#C و Windows Forms  پیاده‌سازی شده با 

---

## معرفی پروژه

این سیستم یک پلتفرم جامع برای مدیریت فرآیندهای بیمارستانی است که با هدف رعایت دقیق مفاهیم شی‌گرایی (OOP)، پیاده‌سازی ساختارهای داده دست‌ساز و مدیریت متمرکز داده‌ها طراحی و توسعه یافته است.

---

## ویژگی‌ها 
### 1. مفاهیم پیشرفته شی‌گرایی (OOP)
* درخت ارث‌بری 4 سطحی: IIdentifiable / IPrintable -> Person (Abstract) -> Employee (Abstract) -> Doctor / Nurse
* انتزاع (Abstraction): تعریف کلاس‌های انتزاعی پایه مانند Person و Employee.
* اینترفیس‌ها (Interfaces): بهره‌گیری از اینترفیس‌های استاندارد و سفارشی (IIdentifiable, IPrintable, IComparable, IEnumerable).
* چندریختی (Polymorphism): پیاده‌سازی Method Overloading، Method Overriding و پیاده‌سازی رفتارهای متفاوت در کلاس‌های مشتق‌شده.
* کپسوله‌سازی کامل (Encapsulation): private‌سازی تمامی فیلدها و کنترل دسترسی از طریق Propertyها.
* ایندکسرها (Indexers) و بیش‌بارگذاری عملگرها: پیاده‌سازی ایندکسر در کلاس‌های بیمارستان و بخش‌ها.

### 2. ساختارهای داده اختصاصی (Custom Generic Collections)
بدون استفاده از کالکشن‌های آماده، ساختارهای داده زیر به‌صورت دستی و جنریک پیاده‌سازی شده‌اند:
* CustomList<T>: لیست پویا با قابلیت پیمایش (IEnumerable) و مدیریت خطای خطوط مرزی.
* CustomQueue<T>: ساختار صف جنریک جهت مدیریت نوبت‌دهی بیماران.
* CustomStack<T>: ساختار پشته جنریک جهت نگهداری تاریخچه عملیات و سوابق.

### 3. رویدادها، دلیگیت‌ها و انوم‌ها (Events, Delegates & Enums)
* رویدادها و دلیگیت‌های سفارشی: جهت مدیریت تغییر وضعیت تخت‌ها، ثبت پرونده‌ها و هشدارهای بیماران.
* تنوع Enumها: بیش از 10 انوم مختلف برای کنترل نقش‌ها، وضعیت‌های پذیرش، تخصص‌های پزشکی و شیفت‌ها.

---

## ساختار معماری پروژه

پروژه در دو بخش منطقی و لایه‌ای پیاده‌سازی شده است:

### 1. لایه منطق و مدل‌ها (managment hospital)
* CustomCollections: شامل ساختارهای داده دست‌ساز (CustomList, CustomQueue, CustomStack).
* Interface: اینترفیس‌های پایه پروژه.
* Models:
  * Enum: انوم‌های مدیریت وضعیت‌ها.
  * Hospital: کلاس‌های ساختاری بیمارستان (Department, Room, Bed).
  * Medical: کلاس‌های عملیات پزشکی (MedicalRecord, Appointment, Treatment).
  * People: ساختار پرسنل و بیماران (Person, Patient, Employee, Doctor, Nurse).

### 2. لایه رابط کاربری (WinFormsApp1)
* MainForm: داشبورد اصلی برنامه.
* PatientsForm: مدیریت و ثبت اطلاعات بیماران.
* DoctorsForm: مدیریت پزشکان و تخصص‌ها.
* NursesForm: مدیریت کادر پرستاری.
* EmployeeForm: مدیریت پرسنل اداری.
* AppointmentsForm: سیستم نوبت‌دهی و زمان‌بندی.

---

## ابزارها و تکنولوژی‌های مورد استفاده

* زبان برنامه نویسی: C# (.NET)
* رابط کاربری: Windows Forms (WinForms)
* محیط توسعه: Visual Studio 2022
* کنترل نسخه: Git & GitHub

---

## نحوه اجرا و راه‌اندازی

1. ریپازیتوری را کلون کنید:
   git clone https://github.com/mohamad-hosein-iren/HospitalManagment.git

2. فایل managment hospital.sln را با استفاده از Visual Studio  باز کنید.
3. پروژه را اجرا (F5) کنید.

![Main Form](images/main-form.png)