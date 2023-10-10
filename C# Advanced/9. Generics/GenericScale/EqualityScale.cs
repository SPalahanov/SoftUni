using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    public class EqualityScale<T>/* where T : IEquatable<T>*/
    {
        private T left;
        private T right;
        
        public EqualityScale(T left, T right)
        {
             this.left = left;
             this.right = right;
        }

        public bool AreEqual()
        {
            return left.Equals(right);
        }
    }
}
