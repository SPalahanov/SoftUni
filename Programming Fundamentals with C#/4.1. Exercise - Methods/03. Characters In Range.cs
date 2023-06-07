namespace _03._Characters_In_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var first = InputTwoCharacters(out var second);


            PrintAllTheCharactersBetweenThemAccordingToASCII(first, second);
        }

        static char InputTwoCharacters(out char second)
        {
            char first = char.Parse(Console.ReadLine());
            second = char.Parse(Console.ReadLine());
            return first;
        }

        static void IfFirstCharIsSmallest(char first, char second)
        {
            if (first < second)
            {
                for (int i = first + 1; i < second; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
        }

        static void IfSecondCharIsSmallest(char second, char first)
        {
            if (second < first)
            {
                for (int i = second +1 ; i < first; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
        }

        static void PrintAllTheCharactersBetweenThemAccordingToASCII(char first, char second)
        {
            IfFirstCharIsSmallest(first, second);

            IfSecondCharIsSmallest(second, first);
        }
    }
}