using System.Xml.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> participantsPoints = new();
            SortedDictionary<string, int> languagesSubmissions = new();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] arguments = input.Split("-");


                string userName = arguments[0];

                if (arguments[1] == "banned")
                {
                    participantsPoints.Remove(userName);
                    continue;
                }

                string language = arguments[1];
                int points = int.Parse(arguments[2]);

                if (!participantsPoints.ContainsKey(userName))
                {
                    participantsPoints.Add(userName, points);
                }

                if (participantsPoints[userName] < points)
                {
                    participantsPoints[userName] = points;
                }

                if (!languagesSubmissions.ContainsKey(language))
                {
                    languagesSubmissions.Add(language, 0);
                }

                languagesSubmissions[language]++;
            }

            Console.WriteLine($"Results:");

            foreach (var participantPoint in participantsPoints.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{participantPoint.Key} | {participantPoint.Value}");
            }

            Console.WriteLine($"Submissions:");

            foreach (var languageSubmission in languagesSubmissions.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{languageSubmission.Key} - {languageSubmission.Value}");
            }
        }
    }
}