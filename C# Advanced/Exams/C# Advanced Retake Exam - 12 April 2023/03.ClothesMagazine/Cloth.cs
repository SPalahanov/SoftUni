using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesMagazine
{
    public class Cloth
    {
        public Cloth(string color, int size, string type)
        {
            Color = color;
            Size = size;
            Type = type;
        }

        public string Color { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"Product: {Type} with size {Size}, color {Color}";
        }
    }
}
