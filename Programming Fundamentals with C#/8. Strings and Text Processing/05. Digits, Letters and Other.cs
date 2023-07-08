namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            foreach (var i in input)
            {
                if (char.IsDigit(i))
                {
                    string digit = i.ToString();

                    Console.Write(digit);
                }
            }
            Console.WriteLine();

            foreach (var i in input)
            {
                if (char.IsLetter(i))
                {
                    string letter = i.ToString();

                    Console.Write(letter);
                }
            }
            Console.WriteLine();

            foreach (var i in input)
            {
                if (!char.IsLetter(i) && !char.IsDigit(i))
                {
                    string symbols = i.ToString();

                    Console.Write(symbols);
                }
            }
        }
    }
}