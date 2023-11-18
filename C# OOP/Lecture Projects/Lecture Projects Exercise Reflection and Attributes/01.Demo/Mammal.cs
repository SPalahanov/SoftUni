using _02.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01.Demo
{
    public class Mammal
    {
        public Mammal()
        {
            string executing = Assembly.GetExecutingAssembly().FullName;
            string calling = Assembly.GetCallingAssembly().FullName;
            string entry = Assembly.GetEntryAssembly().FullName;

            Human human = new Human();
        }

    }
}
