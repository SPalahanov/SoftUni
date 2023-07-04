namespace _05._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] arguments = input.Split(" : ");

                string courseName = arguments[0];
                string studentName = arguments[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses[courseName] = new List<string>();
                }

                courses[courseName].Add(studentName);
            }

            foreach (var kvp in courses)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach (var studentName in kvp.Value)
                {
                    Console.WriteLine($"-- {studentName}");
                }
            }
        }
    }
}