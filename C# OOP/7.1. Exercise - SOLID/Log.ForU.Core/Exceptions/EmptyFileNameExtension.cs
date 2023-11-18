using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.ForU.Core.Exceptions
{
    public class EmptyFileNameExtension : Exception
    {
        private const string DefaultMessage = "File name cannot be null or whitespace";

        public EmptyFileNameExtension()
            : base(DefaultMessage)
        {

        }

        public EmptyFileNameExtension(string message)
            : base(message)
        {

        }
    }
}
