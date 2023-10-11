using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodString
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public void Add(T element)
        {
            list.Add(element);
        }

        public int Count(T itemComparable)
        {
            int count = 0;

            foreach (T item in list)
            {
                if (item.CompareTo(itemComparable) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
