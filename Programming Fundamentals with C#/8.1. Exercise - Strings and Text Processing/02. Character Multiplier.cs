namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            string[] input = Console.ReadLine().Split();

            decimal result = Sum(input[0], input[1]);

            Console.WriteLine(result);
        }

        static decimal Sum(string first, string second)
        {
            decimal sum = 0;

            int length = Math.Max(first.Length, second.Length);

            for (int i = 0; i < length; i++)
            {
                if (i < first.Length && i < second.Length)
                {
                    sum += first[i] * second[i];
                }
                else if (i < first.Length)
                {
                    sum += first[i];
                }
                else if (i < second.Length)
                {
                    sum += second[i];
                }
            }

            return sum;
        }
    }
}