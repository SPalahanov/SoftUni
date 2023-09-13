using System.Text;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine()
                .Split()
                .ToArray();

            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < children.Length; i++)
            {
                queue.Enqueue(children[i]);
            }

            int n = int.Parse(Console.ReadLine());

            int tossCount = 0;

            while (queue.Count > 1)
            {
                tossCount++;

                string current = queue.Dequeue();

                if (tossCount == n)
                {
                    Console.WriteLine($"Removed {current}");

                    tossCount = 0;
                }

                if (tossCount > 0 && tossCount < n)
                {
                    queue.Enqueue(current);
                }
            }

            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}