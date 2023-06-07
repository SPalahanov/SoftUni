namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = 0;

            int topInteger = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                bool isTrue = true;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] <= numbers[j])
                    {
                        isTrue = false;
                    }
                }

                if (isTrue == true)
                {
                    Console.Write(string.Join(' ', numbers[i]) + " ");
                }
            }
        }
    }
}