namespace _02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int middleIndex = (numbers.Count / 2) + 1;

            double leftRacerTime = 0;
            double rightRacerTime = 0;

            for (int i = 0; i < middleIndex - 1; i++)
            {
                if (numbers[i] == 0)
                {
                    leftRacerTime *= 0.8;
                }
                else
                {
                    leftRacerTime += numbers[i];
                }
            }

            for (int i = numbers.Count - 1; i >= middleIndex; i--)
            {
                if (numbers[i] == 0)
                {
                    rightRacerTime *= 0.8;
                }
                else
                {
                    rightRacerTime += numbers[i];
                }
            }

            string winner;

            if (leftRacerTime > rightRacerTime)
            {
                winner = "right";

                Console.WriteLine($"The winner is {winner} with total time: {rightRacerTime:#.#}");
            }
            else
            {
                winner = "left";

                Console.WriteLine($"The winner is {winner} with total time: {leftRacerTime:#.#}");
            }
        }
    }
}