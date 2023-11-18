using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.ForU.Core.Exceptions
{
    public class EmptyFileExtensionException : Exception
    {
        private const string DefaultMessage = "File name cannot be null or whitespace";

        public EmptyFileExtensionException()
            : base(DefaultMessage)
        {

        }

        public EmptyFileExtensionException(string message)
            : base(message)
        {

        }
    }
}
