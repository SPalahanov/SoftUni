namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            int temp = 0;

            if (n > numbers.Length)
            {
                temp = n - numbers.Length;

                for (int i = temp; i < numbers.Length; i++)
                {
                    int[] arr = numbers;
                    Console.Write(arr[i] + " ");
                }

                for (int i = 0; i < temp; i++)
                {
                    int[] arr = numbers;
                    Console.Write(arr[i] + " ");
                }
            }
            else
            {
                temp = Math.Abs(numbers.Length - (numbers.Length - n));

                for (int i = n; i < numbers.Length; i++)
                {
                    int[] arr = numbers;
                    Console.Write(arr[i] + " ");
                }

                for (int i = 0; i < temp; i++)
                {
                    int[] arr = numbers;
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }
}