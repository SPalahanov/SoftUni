using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private const int AddIndex = 0;
        private const int RemoveIndex = 0;

        private readonly List<string> data;

        public MyList()
        {
            data = new List<string>();
        }

        public int Used { get; private set; }

        public int Add(string item)
        {
            data.Insert(AddIndex, item);

            return AddIndex;
        }

        public string Remove()
        {
            string item = data[RemoveIndex];

            data.RemoveAt(RemoveIndex);

            return item;
        }
    }
}
