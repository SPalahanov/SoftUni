using System.Diagnostics;
using System.Xml.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = input[0];

                if (!students.ContainsKey(input[0]))
                {
                    students.Add(name, new List<decimal>());
                }

                students[name].Add(decimal.Parse(input[1]));
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {String.Join(" ", student.Value.Select(grade => $"{grade:F2}"))} (avg: {student.Value.Average():F2})");
            }
        }
    }
}