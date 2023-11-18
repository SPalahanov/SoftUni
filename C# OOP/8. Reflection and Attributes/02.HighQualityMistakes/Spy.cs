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
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            FieldInfo[] fieldInfos = classType.GetFields((BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public));
            MethodInfo[] publicMethodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            //sb.AppendLine("Fields:");
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                sb.AppendLine($"{fieldInfo.Name} must be private!");
            }

            //sb.AppendLine("Getters:");
            foreach (MethodInfo nonPublicMethodInfo in nonPublicMethodsInfo.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{nonPublicMethodInfo.Name} have to be public!");
            }

            //sb.AppendLine("Setters:");
            foreach (MethodInfo publicMethodInfo in publicMethodsInfo.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{publicMethodInfo.Name} have to be private!");
            }

            return sb.ToString();
        }
    }
}
