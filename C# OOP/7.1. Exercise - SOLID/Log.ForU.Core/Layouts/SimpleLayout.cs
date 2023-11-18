using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.ForU.Core.Layout.Interfaces;

namespace Log.ForU.Core.Layout
{
    public class SimpleLayout : ILayout
    {
        private const string SimpleFormat = "{0} - {1} - {2}";
        
        public string Format => SimpleFormat;
    }
}
