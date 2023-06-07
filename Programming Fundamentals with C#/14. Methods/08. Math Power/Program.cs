namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = InputTwoParameters(out var power);

            double result = Result(number, power);
            Console.WriteLine(result);
        }

        private static double InputTwoParameters(out double power)
        {
            double number = double.Parse(Console.ReadLine());
            power = double.Parse(Console.ReadLine());
            return number;
        }

        static double Result(double number, double power)
        {
            return Math.Pow(number, power);
        }
    }
}