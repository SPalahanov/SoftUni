namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersCounts = new Dictionary<int, int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbersCounts.ContainsKey(number))
                {
                    numbersCounts.Add(number, 0);
                }

                numbersCounts[number]++;
            }

            int result = numbersCounts.Single(x => x.Value % 2 == 0).Key;

            Console.WriteLine(result);
        }
    }
}