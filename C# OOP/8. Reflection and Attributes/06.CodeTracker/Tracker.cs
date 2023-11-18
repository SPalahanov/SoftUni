using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);

            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var methodInfo in methods)
            {
                if (methodInfo.CustomAttributes.Any(m =>m.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = methodInfo.GetCustomAttributes(false);

                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{methodInfo.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}
