namespace _03.ExactSumOfRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfNumber = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 1; i <= countOfNumber; i++)
            {
                decimal numbers = decimal.Parse(Console.ReadLine());
                sum = sum + numbers;
            }

            Console.WriteLine(sum);
        }
    }
}