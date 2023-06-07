namespace _02.EnglishNameLastDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lastNumber = number % 10;

            //Console.WriteLine(lastNumber);

            if (lastNumber == 1)
            {
                Console.WriteLine("one");
            }
            else if (lastNumber == 2)
            {
                Console.WriteLine("two");
            }
            else if (lastNumber == 3)
            {
                Console.WriteLine("three");
            }
            else if (lastNumber == 4)
            {
                Console.WriteLine("four");
            }
            else if (lastNumber == 5)
            {
                Console.WriteLine("five");
            }
            else if (lastNumber == 6)
            {
                Console.WriteLine("six");
            }
            else if (lastNumber == 7)
            {
                Console.WriteLine("seven");
            }
            else if (lastNumber == 8)
            {
                Console.WriteLine("eight");
            }
            else if (lastNumber == 9)
            {
                Console.WriteLine("nine");
            }
            else if (lastNumber == 0)
            {
                Console.WriteLine("zero");
            }
        }
    }
}