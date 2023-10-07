using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    internal class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                TrowExceptionIfIndexOutOfRange(index);

                return items[index];
            }
            set
            {
                TrowExceptionIfIndexOutOfRange(index);

                items[index] = value;
            }
        }

        public void Add(int item)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = item;

            Count++;
        }

        public void AddRange(int[] items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public int RemoveAt(int index)
        {
            TrowExceptionIfIndexOutOfRange(index);

            int removedItem = items[index];

            ShiftLeft(index);

            Count--;

            if (Count == items.Length / 4)
            {
                Shrink();
            }

            return removedItem;
        }

        public void InsertAt(int index, int item)
        {
            TrowExceptionIfIndexOutOfRange(index);

            if (items.Length == Count)
            {
                Resize();
            }

            ShiftRight(index);

            items[index] = item;

            Count++;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == item)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            TrowExceptionIfIndexOutOfRange(firstIndex);
            TrowExceptionIfIndexOutOfRange(secondIndex);

            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        private void TrowExceptionIfIndexOutOfRange(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Invalid index value");
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count - 1] = default;
        }

        private void ShiftRight(int index)
        {
            for (int i = Count - 1; i >= index; i--)
            {
                items[i + 1] = items[i];
            }
        }

        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;

        }
    }
}
