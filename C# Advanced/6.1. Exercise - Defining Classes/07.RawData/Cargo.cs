using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
