namespace _11.MultiplicationTable2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            int sum;

            if (number2 <= 10)
            {
                for (int i = number2; i <= 10; i++)
                {
                    sum = number1 * i;
                    Console.WriteLine($"{number1} X {i} = {sum}");
                }
            }
            else
            {
                sum = number1 * number2;
                Console.WriteLine($"{number1} X {number2} = {sum}");
            }
        }
    }
}