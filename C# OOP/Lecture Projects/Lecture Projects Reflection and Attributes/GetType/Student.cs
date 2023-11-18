using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetType
{
    public class Student : ICloneable
    {
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
