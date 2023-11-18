using System.Reflection;

namespace CriticalMethods
{
    public class Program
    {
        static void Main(string[] args)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in types)
            {
                MethodInfo[] methods = type.GetMethods();

                foreach (MethodInfo method in methods)
                {
                    CriticalAttribute attribute = method.GetCustomAttribute<CriticalAttribute>();

                    if (attribute != null)
                    {
                        Console.WriteLine($"{type.Name} - {method.Name} Severity: {attribute.Severity} --- {attribute.Message}");
                    }
                }
                
                
            }
        }
    }
}