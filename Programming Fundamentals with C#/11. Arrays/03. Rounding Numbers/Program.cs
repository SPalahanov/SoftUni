namespace _03._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Decimal[] numbers = Console.ReadLine()
                .Split()
                .Select(decimal.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                decimal result = Math.Round(numbers[i],MidpointRounding.AwayFromZero);

                Console.WriteLine($"{numbers[i]} => {result}");
            }
        }
    }
}