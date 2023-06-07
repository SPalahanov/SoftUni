using System.Dynamic;

namespace _09._Greater_Of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var type = Console.ReadLine();
            IfTypeIsInt(type);
            
            IfTypeIsString(type);
            
            IfTypeIsChar(type);
        }

        private static void IfTypeIsChar(string? type)
        {
            if (type == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());

                Console.WriteLine(GetMaxChar(a, b));
            }
        }

        private static void IfTypeIsString(string? type)
        {
            if (type == "string")
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();

                Console.WriteLine(GetMaxString(a, b));
            }
        }

        private static void IfTypeIsInt(string? type)
        {
            if (type == "int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());

                Console.WriteLine(GetMaxInt(a, b));
            }
        }

        static int GetMaxInt(int a, int b)
        {
            if (a <= b)
            {
                a = b;
            }

            return a;
        }

        static string GetMaxString(string a, string b)
        {
            if (a.CompareTo(b) <= 0)
            {
                a = b;
            }
            return a;
        }

        static char GetMaxChar(char a, char b)
        {
            if (a <= b)
            {
                a = (char)b;
            }
            return a;
        }


    }
}