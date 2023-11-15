using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingStrategy.SortingStrategies.Interfaces;

namespace SortingStrategy.SortingStrategies
{
    public class BubbleStrategy : ISortingStrategy
    {
        public List<int> Sort(List<int> list)
        {
            Console.WriteLine("Bubble sort used!");
            return list;
        }
    }
}
