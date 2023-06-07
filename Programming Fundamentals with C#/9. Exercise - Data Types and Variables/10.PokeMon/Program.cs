namespace _10.PokeMon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            double precent = n * 0.5d;
            int pokeCount = 0;

            while (n >= m)
            {
                n -= m;
                pokeCount++;

                if (precent == n && y != 0)
                {
                    n /= y;
                }
            }

            Console.WriteLine(n);
            Console.WriteLine(pokeCount);
        }
    }
}