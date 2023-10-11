namespace Threeuple
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] personTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] drinkTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] bankTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //bool drunk = drinkTokens[2] == "drunk";

            CustomThreeuple<string, string, string> person =
                new($"{personTokens[0]} {personTokens[1]}", personTokens[2], string.Join(" ", personTokens[3..]));

            CustomThreeuple<string, int, bool> drinks =
                new(drinkTokens[0], int.Parse(drinkTokens[1]), drinkTokens[2] == "drunk");

            CustomThreeuple<string, double, string> banks =
                new(bankTokens[0], double.Parse(bankTokens[1]), bankTokens[2]);

            Console.WriteLine(person);
            Console.WriteLine(drinks);
            Console.WriteLine(banks);
        }
    }
}