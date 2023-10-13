using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;

        public CustomStack()
        {
            items = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = item;

            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T removedItem = items[Count - 1];

            items[Count - 1] = default;

            Count--;

            return removedItem;
        }

        //public T Peek()
        //{
        //    if (Count == 0)
        //    {
        //        throw new InvalidOperationException("CustomStack is empty");
        //    }

        //    return items[Count - 1];
        //}

        //public void ForEach(Action<int> action)
        //{
        //    for (int i = 0; i < Count; i++)
        //    {
        //        int currentItem = items[i];

        //        action(currentItem);
        //    }
        //}

        private void Resize()
        {
            T[] copy = new T[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
