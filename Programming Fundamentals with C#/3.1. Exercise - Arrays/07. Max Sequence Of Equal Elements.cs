namespace _07.MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] symbols = Console.ReadLine().Split().ToArray();

            int bestCount = 0;
            string bestCountSymbol = " ";

            for (int i = 0; i < symbols.Length; i++)
            {
                int count = 0;

                for (int j = i; j < symbols.Length; j++)
                {
                    if (symbols[i] == symbols[j])
                    {
                        count++;
                        if (bestCount < count)
                        {
                            bestCount = count;
                            bestCountSymbol = symbols[i];
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for (int i = 0; i < bestCount; i++)
            {
                Console.Write($"{bestCountSymbol} ");
            }
        }
    }
}