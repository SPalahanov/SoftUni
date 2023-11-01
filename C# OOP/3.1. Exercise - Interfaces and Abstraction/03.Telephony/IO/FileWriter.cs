using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.IO.Interfaces;

namespace Telephony.IO
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string line)
        {
            string filePath = "../../../test.txt";
            using StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine(line);
        }
    }
}
