using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    { 
        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);

            MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {className.GetType().BaseType.Name}");

            foreach (MethodInfo methodInfo in methodInfos)
            {
                sb.AppendLine(methodInfo.Name);
            }

            return sb.ToString();
        }
    }
}
