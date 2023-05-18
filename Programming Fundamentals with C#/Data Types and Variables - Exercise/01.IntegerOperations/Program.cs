namespace _01.IntegerOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());
            
            double sum = Math.Floor((firstNumber + secondNumber) / thirdNumber) * fourthNumber;

            Console.WriteLine(sum);
        }
    }
}