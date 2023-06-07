namespace _02._Print_Numbers_In_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrayLength = int.Parse(Console.ReadLine());
            int[] numbers = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = arrayLength - 1; i >= 0; i--)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}