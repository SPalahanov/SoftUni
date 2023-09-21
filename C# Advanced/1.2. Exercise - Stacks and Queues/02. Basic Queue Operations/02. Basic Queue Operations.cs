namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            Queue<string> queue = new Queue<string>();

            int elementsToPush = int.Parse(input[0]);
            int elementsToPop = int.Parse(input[1]);
            string searchedElement = input[2];

            string[] elements = Console.ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < elementsToPush; i++)
            {
                queue.Enqueue(elements[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (queue.Contains(searchedElement))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}