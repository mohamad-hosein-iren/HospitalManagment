using System.Collections;
using System.Collections.Generic;

namespace HospitalManagementSystem.CustomCollections
{
    public class CustomList<T> : IEnumerable<T>
    {
        private T[] _items;              //آرایه داخلی لیست
        private int _count;              //تعداد عناصر
        private int _capacity;           //ظرفیت لیست
        private const int DefaultCapacity = 4;  //ظرفیت پیشفرض
        
        //متد برای برگرداندن تعداد عناصر
        public int Count => _count;       
        public int Capacity
        {
            get => _capacity;
            set
            {
                if (value < _count)   // ظرفیت نباید کمتر از تعداد عناصر باشد
                    throw new ArgumentOutOfRangeException("ظرفیت نمی‌تواند کمتر از تعداد باشد");

                if (value != _capacity)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (_count > 0)
                        {
                            Array.Copy(_items, newItems, _count);
                        }
                        _items = newItems;
                        _capacity = value;
                    }
                    else   // درغیر اینصورت ها ظرفیت صفر است
                    {
                        _items = new T[0];
                        _capacity = 0;
                    }
                }
            }
        }
        public bool IsEmpty => _count == 0;  //بررسی خالی بودن لیست

        public CustomList()
        {
            _items = new T[DefaultCapacity];
            _capacity = DefaultCapacity;
            _count = 0;
        }

        public CustomList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("ظرفیت نمی‌تواند منفی باشد");

            if (capacity == 0)
                _items = new T[0];
            else
                _items = new T[capacity];   // ساخت کالکشن با ظرفیت غیر صفر

            _capacity = capacity;
            _count = 0;
        }
        
        //متد برای اضافه کردن عنصر به لیست
        public void Add(T item)
        {
            if (_count == _capacity)
            {
                EnsureCapacity(_count + 1);  //افزاسش ظرفیت آرایه داخلی
            }

            _items[_count] = item;
            _count++;
        }
        //متد برای پاک کردن یک عنصر در اندیس مشخص
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException("اندیس خارج از محدوده است");

            _count--;
            if (index < _count)
            {
                Array.Copy(_items, index + 1, _items, index, _count - index);
            }
            _items[_count] = default(T);  // برابر قرار دادن اندیس مورد نظر با مقدار پیشفرض نوع داده
        }
        //متد برای حذف یک عنصر
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }
        //برگرداندن اندیس یک عنصر
        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)  //جستجو در عناصر برای پیدا کردن عنصر مورد نظر
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], item))
                {
                    return i;
                }
            }
            return -1;
        }
        //بررسی اینکه آیا یک عنصر در لیست وجود دارد یا نه
        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }
        //حذف کردن تمام عناصر لیست
        public void Clear()
        {
            if (_count > 0)
            {
                Array.Clear(_items, 0, _count);
                _count = 0;
            }
        }
        //تبدیل لیست به آرایه
        public T[] ToArray()
        {
            T[] array = new T[_count];
            Array.Copy(_items, array, _count);
            return array;
        }
        //درج یک عنصر در یک اندیس مشخص
        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException("اندیس خارج از محدوده است");

            if (_count == _capacity)
            {
                EnsureCapacity(_count + 1);  //درصورت برابری ظرفیت وتعداد عناصر به  ظرفیت افزوده میشود
            }

            if (index < _count)
            {
                Array.Copy(_items, index, _items, index + 1, _count - index);//خالی کردن اندیس مورد نظر برای افزودن عنصر موزد نظر
            }

            _items[index] = item;
            _count++;
        }
        //متدی که با افزایش ظرفیت آرایه داخلی تغییر اندازه های مکرر را کاهش میدهد
        private void EnsureCapacity(int min)
        {
            if (_capacity < min)
            {
                int newCapacity = _capacity == 0 ? DefaultCapacity : _capacity * 2;
                if (newCapacity < min)
                    newCapacity = min;

                Capacity = newCapacity;// ظرفیت جدید
            }
        }
        //پیمایش روی عناصر لیست
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //(indexer) دسترسی به عناصر با کمک اندیسشان
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException("اندیس خارج از محدوده است");
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException("اندیس خارج از محدوده است");
                _items[index] = value;
            }
        }
        //برگداندن عناصر موجود درلیست بدر قالب یک رشته
        public override string ToString()
        {
            if (IsEmpty)
                return "لیست خالی است";

            string result = "لیست: ";
            for (int i = 0; i < _count; i++)
            {
                result += _items[i];
                if (i < _count - 1)
                    result += ", ";
            }
            return result;
        }
    }
}