namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int[] wagon = new int[input];

            int sum = 0;

            for (int i = 0; i < input; i++)
            {
                int numberOfPeople = int.Parse(Console.ReadLine());

                wagon[i] = numberOfPeople;
                sum += wagon[i];
            }
            Console.WriteLine(string.Join(' ', wagon));
            Console.WriteLine(sum);
        }
    }
}