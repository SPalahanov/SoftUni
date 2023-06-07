namespace _06.BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInput = int.Parse(Console.ReadLine());
            string input;

            int openBracketsCounter = 0;
            int closedBracketsCounter = 0;
            int unbalanceCounter = 0;

            for (int i = 1; i <= numberOfInput; i++)
            {
                input = Console.ReadLine();

                if (input == "(")
                {
                    openBracketsCounter++;
                }
                else if (input == ")")
                {
                    closedBracketsCounter++;
                }

                int counter = openBracketsCounter - closedBracketsCounter;

                if (counter < 0 || counter >1)
                {
                    unbalanceCounter += counter;
                }
            }

            if (openBracketsCounter == closedBracketsCounter && unbalanceCounter == 0)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}