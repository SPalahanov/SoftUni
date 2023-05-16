namespace _10.MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            //int sum;
            for (int i = 1; i <= 10; i++)
            {
                int sum = number * i;
                Console.WriteLine($"{number} X {i} = {sum}");
            }
        }
    }
}