using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern =
                @"(\||#)(?<itemName>[a-zA-Z\s]+)\1(?<expirationDate>\d{2}/\d{2}/\d{2})\1(?<calories>\d+)\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            int totalCalories = 0;

            int caloriesPerDay = 2000;

            foreach (Match match in matches)
            {
                totalCalories += int.Parse(match.Groups["calories"].Value);
            }

            int days = totalCalories / caloriesPerDay;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match match in matches)
            {
                string itemName = match.Groups["itemName"].Value;

                string expirationDate = match.Groups["expirationDate"].Value;

                string calories = match.Groups["calories"].Value;

                Console.WriteLine($"Item: {itemName}, Best before: {expirationDate}, Nutrition: {calories}");
            }
        }
    }
}