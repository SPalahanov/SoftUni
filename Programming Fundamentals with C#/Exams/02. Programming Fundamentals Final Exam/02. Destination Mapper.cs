using System.Diagnostics;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(=|/)(?<place>[A-Z][A-Za-z]{2,})\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            //============ / First Solution /==========//

            var match = matches.Select(x => x.Groups["place"].Value);

            Console.WriteLine($"Destinations: {string.Join(", ", match)}");
            Console.WriteLine($"Travel Points: {match.Sum(x => x.Length)}");


            //============ / Second Solution /==========//

            //int travelPoints = 0;

            //List<string> matchList = new List<string>();

            //foreach (Match match in matches)
            //{
            //    string place = match.Value.Trim('=').Trim('/');

            //    matchList.Add(place);

            //    travelPoints += place.Length;
            //}

            //Console.WriteLine($"Destinations: {string.Join(", ", matchList)}");
            //Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}