namespace RubberDuckDebugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> stack = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int darthVaderCount = 0;
            int thorCount = 0;
            int blueCount = 0;
            int yellowCount = 0;

            while (stack.Any() || queue.Any())
            {
                int timeToCompleteTask = queue.Dequeue();
                int numberOfTasks = stack.Pop();
                int result = timeToCompleteTask * numberOfTasks;

                if (result <= 60)
                {
                    darthVaderCount++;
                }
                else if (result >= 61 && result <= 120)
                {
                    thorCount++;
                }
                else if (result >= 121 && result <= 180)
                {
                    blueCount++;
                }
                else if (result >= 181 && result <= 240)
                {
                    yellowCount++;
                }

                if (result > 240)
                {
                    stack.Push(numberOfTasks - 2);
                    queue.Enqueue(timeToCompleteTask);
                }
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");

            Console.WriteLine($"Darth Vader Ducky: {darthVaderCount}");
            Console.WriteLine($"Thor Ducky: {thorCount}");
            Console.WriteLine($"Big Blue Rubber Ducky: {blueCount}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {yellowCount}");
        }
    }
}