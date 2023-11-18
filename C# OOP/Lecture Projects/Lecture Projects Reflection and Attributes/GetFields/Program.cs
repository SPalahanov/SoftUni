using System.Reflection;

namespace GetFields
{
    public class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Cat);

            Cat cat = new Cat();

            //FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            FieldInfo[] fields = type.GetFields((BindingFlags)(60));

            foreach (FieldInfo field in fields)
            {
                Console.WriteLine($"Name of field: {field.Name}");
                Console.WriteLine($"Name of field type: {field.FieldType.Name}");
                Console.WriteLine($"Static: {field.IsStatic}");
                Console.WriteLine($"Private: {field.IsPrivate}");
                Console.WriteLine($"Protected: {field.IsFamily}");
                Console.WriteLine($"Internal: {field.IsAssembly}");
                Console.WriteLine($"Public: {field.IsPublic}");

                field.SetValue(cat, "add " + (string)field.GetValue(cat));

                Console.WriteLine($"Field value {field.GetValue(cat)}");
                Console.WriteLine("-------------------------------\n-------------------------------");
            }
        }
    }

    public class Cat
    {
        //private int privateField;
        protected string protectedField = "vtoro";
        internal string internalField = "treto";
        public string publicField = "chetvurto";
        public static string staticField;
    }

}