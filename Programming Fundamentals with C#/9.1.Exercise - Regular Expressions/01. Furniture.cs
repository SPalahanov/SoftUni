using System.Text;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            decimal spendMoney = 0;

            StringBuilder furnitures = new StringBuilder();

            string pattern = @">>(?<Name>[A-Za-z]+)<<(?<Price>\d+(\.\d+)?)!(?<Quantity>\d+)";

            Regex regex = new Regex(pattern);

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string name = match.Groups["Name"].Value;
                    decimal price = decimal.Parse(match.Groups["Price"].Value);
                    int quantity = int.Parse(match.Groups["Quantity"].Value);

                    spendMoney += price * quantity;

                    furnitures.AppendLine(name);
                }
            }

            Console.WriteLine("Bought furniture:");

            Console.Write(furnitures.ToString());
            
            Console.WriteLine($"Total money spend: {spendMoney:f2}");
        }
    }
}