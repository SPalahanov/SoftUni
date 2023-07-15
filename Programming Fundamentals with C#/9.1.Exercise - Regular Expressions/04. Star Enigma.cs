using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            string pattern = @"\@(?<planetName>[A-Za-z]+)[^\@\-\!\:\>]*\:(?<population>\d+)[^\@\-\!\:\>]*\!(?<attackType>A|D)\![^\@\-\!\:\>]*\-\>[^\@\-\!\:\>]*?(?<soldiersCount>\d+)[^\@\-\!\:\>]*";

            int attackedPlanetsCount = 0;
            int destroyedPlanetsCount = 0;

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            Regex regex = new Regex(pattern);
            
            for (int j = 0; j < n; j++)
            {
                string input = Console.ReadLine();

                int counter = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == 'S' || input[i] == 'T' || input[i] == 'A' || input[i] == 'R' || input[i] == 's' || input[i] == 't' || input[i] == 'a' || input[i] == 'r')
                    {
                        counter++;
                    }
                }
                
                StringBuilder sb = new StringBuilder();

                foreach (var letter in input)
                {
                    int letterNum = letter;
                    int newLetterNumber = letterNum - counter;

                    char newLetter = (char)newLetterNumber;

                    sb.Append(newLetter);
                }

                Match match = regex.Match(sb.ToString());

                if (match.Success)
                {
                    string planetName = match.Groups["planetName"].Value;
                    string attackType = match.Groups["attackType"].Value;
                    
                    if (attackType == "A")
                    {
                        attackedPlanetsCount++;

                        attackedPlanets.Add(planetName);
                    }

                    if (attackType == "D")
                    {
                        destroyedPlanetsCount++;

                        destroyedPlanets.Add(planetName);
                    }

                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanetsCount}");
            if (attackedPlanetsCount > 0)
            {
                attackedPlanets.Sort();

                foreach (var planet in attackedPlanets)
                {
                    Console.WriteLine($"-> {planet}");
                }
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanetsCount}");
            if (destroyedPlanetsCount > 0)
            {
                destroyedPlanets.Sort();


                foreach (var planet in destroyedPlanets)
                {
                    Console.WriteLine($"-> {planet}");
                }
            }

        }
    }
}