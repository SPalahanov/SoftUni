using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.ForU.Core.Exceptions
{
    public class EmptyCreatedTimeException : Exception
    {
        private const string DefaultMessage = "Created time of message cannot be null or whitespace";
        
        public EmptyCreatedTimeException() 
            : base(DefaultMessage)
        {
            
        }
        
        public EmptyCreatedTimeException(string message)
            : base(message)
        {
            
        }
    }
}
