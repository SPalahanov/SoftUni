using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriticalMethods
{
    public class HTTPRequester
    {
        [Critical(Severity = 3, Message = "If this doesn't work we go out of business")]
        public void Post()
        {

        }
    }
}
