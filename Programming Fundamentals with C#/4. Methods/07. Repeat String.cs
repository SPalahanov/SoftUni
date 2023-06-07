namespace _07._Repeat_String
{
    internal class Program
    {
        //Create a method that receives two parameters:
        //• A string
        //• A number n(integer) represents how many times the string will be repeated
        //The method should return a new string, containing the initial one, repeated n times without space



        static void Main(string[] args)
        {
            var text = InputTwoParameters(out var n);
            SumStringMethod(n, text);
        }

        private static string? InputTwoParameters(out int n)
        {
            string text = Console.ReadLine();

            n = int.Parse(Console.ReadLine());
            return text;
        }

        static void SumStringMethod(int n, string? text)
        {
            string result = "";

            for (int i = 1; i <= n; i++)
            {
                result += text;
            }

            Console.WriteLine(result);
        }
    }
}