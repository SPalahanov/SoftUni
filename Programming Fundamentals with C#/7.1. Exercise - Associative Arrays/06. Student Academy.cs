namespace _06._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());


                if (!students.ContainsKey(name))
                {
                    students[name] = new List<double>();
                }

                students[name].Add(grade);
            }

            var filteredStudents = students
                .Where(s => s.Value.Average() >= 4.50);

            foreach (var fStudent in filteredStudents)
            {
                Console.WriteLine($"{fStudent.Key} -> {fStudent.Value.Average():f2}");
            }
        }
    }
}