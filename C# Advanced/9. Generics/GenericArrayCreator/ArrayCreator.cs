using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int lenght, T elements)
        {
            T[] array = new T[lenght];

            for (int i = 0; i < lenght; i++)
            {
                array[i] = elements;
            }

            return array;
        }
    }
}
