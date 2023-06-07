namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int existsCounter = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                int leftSum = 0;
                int rightSum = 0;
                
                for (int i = j; i < numbers.Length; i++)
                {
                    rightSum += numbers[i];
                }

                for (int i = j; i >= 0; i--)
                {
                    leftSum += numbers[i];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(j);
                    existsCounter++;
                }
                else if (leftSum == 0 && rightSum == 0) 
                {
                    Console.WriteLine("0");
                    break;
                }
            }
            if (existsCounter == 0)
            {
                Console.WriteLine("no");
            }
        }
    }
}