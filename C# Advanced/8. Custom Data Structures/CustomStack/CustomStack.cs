﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    internal class CustomStack
    {
        private const int Initialcapacity = 4;

        private int[] items;

        public CustomStack()
        {
            items = new int[Initialcapacity];
        }

        public int Count { get; private set; }

        public void Push(int item)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = item;

            Count++;
        }

        public int Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }

            int removedItem = items[Count - 1];

            items[Count - 1] = default;

            Count--;

            if (Count == items.Length / 4)
            {
                Shrink();
            }

            return removedItem;
        }

        public int Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }

            return items[Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                int currentItem = items[i];
                ;
                action(currentItem);
            }
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
