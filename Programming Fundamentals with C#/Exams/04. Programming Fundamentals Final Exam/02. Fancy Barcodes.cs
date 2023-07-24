using System.Text;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string pattern = @"(@#+)(?<product>[A-Z]{1}([A-Za-z0-9]{4,})[A-Z]{1})(@#+)";

                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    string product = match.Groups["product"].Value;

                    string numberPattern = @"\d+";

                    Regex r = new Regex(numberPattern);

                    MatchCollection matches = r.Matches(input);

                    StringBuilder sb = new StringBuilder();


                    foreach (Match number in matches)
                    {
                        sb.Append(number.ToString());
                    }

                    if (sb.Length == 0)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {sb.ToString()}");
                    }

                }

            }
        }
    }
}