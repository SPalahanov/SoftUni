using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingStrategy.SortingStrategies.Interfaces;

namespace SortingStrategy.SortingStrategies
{
    public class SelectionStrategy : ISortingStrategy
    {
        public List<int> Sort(List<int> list)
        {

            Console.WriteLine("Selection sort used!");
            return list;
        }
    }
}
