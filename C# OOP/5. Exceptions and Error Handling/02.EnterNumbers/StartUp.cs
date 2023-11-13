namespace EnterNumbers
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            int start = 1;
            int end = 100;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    numbers[i] = ReadNumber(start, end);
                    start = numbers[i];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;

                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        static int ReadNumber(int start, int end)
        {
            int number;

            bool IsInteger = int.TryParse(Console.ReadLine(), out number);

            if (!IsInteger)
            {
                throw new Exception("Invalid Number!");
            }

            if (number <= start || number >= end)
            {
                throw new Exception($"Your number is not in range {start} - 100!");
            }

            return number;
        }
    }
}