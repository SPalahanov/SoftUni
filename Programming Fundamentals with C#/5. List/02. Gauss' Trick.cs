namespace _02._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sum = 0;

            for (int i = 0; i <= numbers.Count / 2; i++)
            {
                if (i < (numbers.Count - 1) - i)
                {

                    sum = numbers[i] + numbers[(numbers.Count - 1) - i];
                    Console.Write($"{sum} ");
                }
                else if (i == (numbers.Count - 1) - i)
                {
                    Console.WriteLine(numbers[i]);
                }


            }
        }
    }
}