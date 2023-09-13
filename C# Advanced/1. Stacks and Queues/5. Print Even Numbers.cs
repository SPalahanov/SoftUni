namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < input.Length; i++)
            {
                numbers.Enqueue(int.Parse(input[i]));
            }

            List<int> nums = new List<int>();

            while (numbers.Count > 0)
            {
                int current = numbers.Dequeue();

                if (current % 2 == 0)
                {
                    nums.Add(current);
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}