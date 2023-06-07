namespace _01.DataTypeFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string comand;
            int intResult;
            float floatResult;
            bool boolResult;
            char charResult;

            while ((comand = Console.ReadLine()) != "END")
            {
                if (int.TryParse(comand, out intResult))
                {
                    Console.WriteLine($"{comand} is integer type");
                }
                else if (float.TryParse(comand, out floatResult))
                {
                    Console.WriteLine($"{comand} is floating point type");
                }
                else if (char.TryParse(comand, out charResult))
                {
                    Console.WriteLine($"{comand} is character type");
                }
                else if (bool.TryParse(comand, out boolResult))
                {
                    Console.WriteLine($"{comand} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{comand} is string type");
                }
            }
        }
    }
}