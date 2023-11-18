
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = System.Type;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            return obj != null;
        }
    }
}
