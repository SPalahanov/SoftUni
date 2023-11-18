using System.Security.Cryptography.X509Certificates;

namespace Reflection
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Type studentType = typeof(Student);

            //PrintTypeMetaData(studentType);
            //Console.WriteLine();

            //PrintTypeMetaData(typeof(DateTime));
            Console.WriteLine("Which class data do you want to see?");

            Type dynamicType = Type.GetType(Console.ReadLine());
            Console.WriteLine();
            PrintTypeMetaData(dynamicType);

        }
        static void PrintTypeMetaData(Type type)
        {
            Console.WriteLine($"FullName: {type.FullName}");
            Console.WriteLine($"Name: {type.Name}");
            Console.WriteLine($"Assembly: {type.Assembly}");
            Console.WriteLine($"BaseType: {type.BaseType.Name}");
            Console.WriteLine($"IsArray: {type.IsArray}");
            Console.WriteLine($"IsClass: {type.IsClass}");
            Console.WriteLine($"IsPublic: {type.IsPublic}");
            Console.WriteLine($"IsAbstract: {type.IsAbstract}");
        }

    }
}