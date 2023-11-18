using _03.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _02.Demo
{
    public class Human
    {
        string executing = Assembly.GetExecutingAssembly().FullName;
        string calling = Assembly.GetCallingAssembly().FullName;
        string entry = Assembly.GetEntryAssembly().FullName;

        Person person = new Person();
    }
}
