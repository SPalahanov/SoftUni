using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ListyIteratorType
{
    public class ListyIterator<T>
    {
        private List<T> items;

        private int index = 0;

        public ListyIterator(List<T> items)
        {
            this.items = items;
        }

        public bool Move()
        {
            if (index < items.Count - 1)
            {
                index++;

                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return index < items.Count;
        }

        public void Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            
            Console.WriteLine(items[index]);
        }
    }
}
