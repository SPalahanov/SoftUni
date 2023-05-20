namespace _04.RefactoringPrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            for (int number = 2; number <= range; number++)
            {
                bool isValid = true;
                for (int cepitel = 2; cepitel < number; cepitel++)
                {
                    if (number % cepitel == 0)
                    {
                        isValid = false;
                        break;
                    }
                }

                string result = isValid.ToString();
                Console.WriteLine($"{number} -> {result.ToLower()}");
            }
        }
    }
}