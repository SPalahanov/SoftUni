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
        public string StealFieldInfo(string investigatedClass, params string[] fields)
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] fieldInfo = classType.GetFields((BindingFlags)60);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType);

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in fieldInfo.Where(f => fields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString();
        }
    }
}
