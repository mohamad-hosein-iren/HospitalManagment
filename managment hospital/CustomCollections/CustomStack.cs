using System.Collections;

namespace HospitalManagementSystem.CustomCollections
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> _items = new List<T>();  //لیست داخل پشته

        //برگرداندن تعدا عناصر پشته
        public int Count => _items.Count;
        //بررسی خال بودن پشته
        public bool IsEmpty => _items.Count == 0;
        //(برگرداندن آخرین عنصر پشته(بدون حذف آن  
        public T Peek
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("پشته خالی است");
                return _items[_items.Count - 1];
            }
        }
        //سازنده ها
        public CustomStack() { }

        public CustomStack(int capacity)
        {
            _items = new List<T>(capacity);
        }
        //اضافه کردن یک عنصر به پشته
        public void Push(T item)
        {
            if (item == null)
                throw new ArgumentNullException("عنصر نمی‌تواند null باشد");

            _items.Add(item);
        }
        //برگرداندن آخرین عنصر پشته همراه با حذف آن
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("پشته خالی است");

            T item = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);
            return item;
        }
        //حذف تمام عناصر پشته
        public void Clear()
        {
            _items.Clear();
        }
        //بررسی وجود یک عنصر در پشته
        public bool Contains(T item)
        {
            return _items.Contains(item);
        }
        //تبدیل پشاه به آرایه
        public T[] ToArray()
        {
            return _items.ToArray();
        }
        //پیمایش روی عناصر پشته
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //برگرداندن عناصر پشته در قالب یک رشته
        public override string ToString()
        {
            if (IsEmpty)
                return "پشته خالی است";

            string result = "پشته (از بالا): ";
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                result += _items[i];
                if (i > 0)
                    result += " | ";
            }
            return result;
        }
    }
}