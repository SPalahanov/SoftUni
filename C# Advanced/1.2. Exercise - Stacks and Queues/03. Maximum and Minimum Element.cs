namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string type = input[0];

                if (type == "1")
                {
                    stack.Push(input[1]);
                }

                if (type == "2")
                {
                    stack.Pop();
                }

                if (type == "3" && stack.Count != 0)
                {
                    Console.WriteLine(stack.Max());
                }

                if (type == "4" && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}