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
        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);

            MethodInfo[] methodInfos = classType.GetMethods((BindingFlags)60);

            foreach (var methodInfo in methodInfos.Where(m =>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{methodInfo.Name} will return {methodInfo.ReturnType}");
            }

            foreach (var methodInfo in methodInfos.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{methodInfo.Name} will set field of {methodInfo.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
    }
}
