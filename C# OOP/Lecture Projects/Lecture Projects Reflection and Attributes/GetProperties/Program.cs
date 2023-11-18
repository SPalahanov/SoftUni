using System.Reflection;

namespace GetProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Cat);

            Cat cat = new Cat();

            PropertyInfo[] properties = type.GetProperties((BindingFlags)(60));

            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine($"Name of property: {property.Name}");
                Console.WriteLine($"Name of property type: {property.PropertyType.Name}");
                
                Console.WriteLine($"Property value {property.GetValue(cat)}");
                Console.WriteLine("-------------------------------\n-------------------------------");
            }
        }
    }

    public class Cat
    {
        public int Age { get; set; }
    }
}