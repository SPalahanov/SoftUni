namespace _01._Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            IfCommandIsInt(command);

            IfCommandIsReal(command);

            IfCommandIsString(command);
        }

        static void IfCommandIsInt(string? command)
        {
            if (command == "int")
            {
                int input = int.Parse(Console.ReadLine());

                Console.WriteLine(input * 2);
            }
        }

        static void IfCommandIsReal(string? command)
        {
            if (command == "real")
            {
                double input = double.Parse(Console.ReadLine());

                Console.WriteLine($"{(input * 1.5):f2}");
            }
        }

        static void IfCommandIsString(string? command)
        {
            if (command == "string")
            {
                string input = Console.ReadLine();

                Console.WriteLine($"${input}$");
            }
        }
    }
}