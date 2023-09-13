namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stack<int> stack = new Stack<int> (Console.ReadLine()
                .Split().Select(int.Parse));

            string command = String.Empty;

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] splitted = command.Split(' ');

                if (command.Contains("add"))
                {
                    int first = int.Parse(splitted[1]);
                    int second = int.Parse(splitted[2]);

                    stack.Push(first);
                    stack.Push(second);
                }
                else if (command.Contains("remove"))
                {
                    int n = int.Parse(splitted[1]);

                    if (n <= stack.Count)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            int sum = 0;

            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}