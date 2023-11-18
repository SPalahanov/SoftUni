using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.ForU.Core.Exceptions
{
    public class InvalidPathException : Exception
    {
        private const string DefaultMessage = "Path is invalid or empty";

        public InvalidPathException() 
            : base(DefaultMessage)
        {

        }

        public InvalidPathException(string message) 
            : base(message)
        {

        }


    }
}
