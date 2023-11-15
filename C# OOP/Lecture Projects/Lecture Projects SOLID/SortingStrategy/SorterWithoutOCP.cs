using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingStrategy
{
    internal class SorterWithoutOCP
    {
        private List<int> list;

        public List<int> SelectionSort()
        {
            Console.WriteLine("Selection sort used!");
            return list;
        }

        public List<int> BubbleSort()
        {
            Console.WriteLine("bubble sort used");
            return list;
        }
    }
}
