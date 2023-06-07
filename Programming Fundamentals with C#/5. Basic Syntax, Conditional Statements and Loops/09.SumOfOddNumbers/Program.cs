namespace _09.SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;

            for (var i = 1; i <= n * 2; i++)
            {
                //i = i + 2;
                //Console.WriteLine(i);

                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                    sum = sum + i;
                }
                //i = i + 2;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}