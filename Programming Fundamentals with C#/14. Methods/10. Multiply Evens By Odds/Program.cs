namespace _10._Multiply_Evens_By_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);
;
            int evens = 0;
            int odds = 0;

            Console.WriteLine(GetMultipleOfEvenAndOdds(odds, number, evens));
        }

        static int GetMultipleOfEvenAndOdds(int odds, int number, int evens)
        {
            int result;
            odds = GetSumOfOddsDigits(number, odds);
            evens = GetSumOfEvensDigits(number, evens);

            result = evens * odds;

            return result;
        }

        static int GetSumOfOddsDigits(int number, int odds)
        {
            int result;
            result = number;
            while (result != 0)
            {
                result = number % 10;

                if (result % 2 != 0)
                {
                    odds += result;
                }

                number /= 10;
                result = number;
            }

            return odds;
        }

        static int GetSumOfEvensDigits(int number, int evens)
        {
            int result;
            result = number;
            while (result != 0)
            {
                result = number % 10;

                if (result % 2 == 0)
                {
                    evens += result;
                }
                
                number /= 10;
                result = number;
            }

            return evens;
        }
    }
}