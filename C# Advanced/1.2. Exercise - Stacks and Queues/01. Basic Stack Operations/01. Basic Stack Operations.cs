namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            Stack<string> stack = new Stack<string>();

            int elementsToPush = int.Parse(input[0]);
            int elementsToPop = int.Parse(input[1]);
            string searchedElement = input[2];

            string[] elements = Console.ReadLine()
                .Split()
                .ToArray();
            
            for (int i = 0; i < elementsToPush; i++)
            {
                stack.Push(elements[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }
            
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(searchedElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}