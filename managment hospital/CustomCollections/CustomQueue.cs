using System.Collections;

namespace HospitalManagementSystem.CustomCollections
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private List<T> _items = new List<T>();   //لیست داخلی صف

        //برگرداندن تعداد عناصر صف
        public int Count => _items.Count;
        //بررسی خالی بودن صف
        public bool IsEmpty => _items.Count == 0;

        //(برگرداندن اولین عنصر صف(بدون حذف    
        public T Peek
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("صف خالی است");
                return _items[0];
            }
        }
        //سازنده ها
        public CustomQueue() { }

        public CustomQueue(int capacity)
        {
            _items = new List<T>(capacity);
        }
        //اضافه کردن یک عنصر به صف
        public void Enqueue(T item)
        {
            if (item == null)
                throw new ArgumentNullException("عنصر نمی‌تواند null باشد");

            _items.Add(item);
        }
        //برگرداندن اولین عنصر صف همراه با حذف آن
        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("صف خالی است");

            T item = _items[0];
            _items.RemoveAt(0);
            return item;
        }
        //حذف تمام عناصر صف
        public void Clear()
        {
            _items.Clear();
        }
        //بررسی وجود یک عنصر در صف
        public bool Contains(T item)
        {
            return _items.Contains(item);
        }
        //تبدیل صف به آرایه
        public T[] ToArray()
        {
            return _items.ToArray();
        }
        //پیمایش روی عناصر صف
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //برگرداندن عناصر صف در قالب یک رشته همراه با نشان دادن ترتیب اضافه شدن آنها
        public override string ToString()
        {
            if (IsEmpty)
                return "صف خالی است";

            string result = "صف: ";
            for (int i = 0; i < _items.Count; i++)
            {
                result += _items[i];
                if (i < _items.Count - 1)
                    result += " ← ";
            }
            return result;
        }
    }
}