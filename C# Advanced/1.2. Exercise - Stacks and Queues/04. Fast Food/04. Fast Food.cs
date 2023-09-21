namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            string[] orders = Console.ReadLine()
                .Split()
                .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < orders.Length; i++)
            {
                queue.Enqueue(int.Parse(orders[i]));
            }

            Console.WriteLine(queue.Max());

            int currentOrder = 0;

            while (currentOrder <= quantityOfFood && queue.Count > 0)
            {
                currentOrder = queue.Peek();

                if (currentOrder <= quantityOfFood)
                {
                    quantityOfFood -= currentOrder;

                    queue.Dequeue();

                    if (queue.Count > 0)
                    {
                        currentOrder = queue.Peek();
                    }
                    else
                    {
                        currentOrder = 0;
                    }
                }
                else
                {
                    break;
                }
            }

            if (queue.Count > 0)
            {
                Console.WriteLine($"Orders left: {String.Join(" ", queue)}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}