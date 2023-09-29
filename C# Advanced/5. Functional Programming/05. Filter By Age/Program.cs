using System.Threading.Channels;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        class Student
        {
            public string Name { get; set; }

            public int Age { get; set; }

        }


        static void Main(string[] args)
        {
            List <Student> students = new List<Student>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                Student student = new Student();

                student.Name = name;
                student.Age = age;

                students.Add(student);
            }

            string filterType = Console.ReadLine();

            int filterNumber = int.Parse(Console.ReadLine());

            Func<Student, int, bool> filter = FilterGenerator(filterType);

            students = students
                .Where(student => filter(student, filterNumber))
                .ToList();

            string format = Console.ReadLine();

            Action<Student> printer = PrinterGenerator(format);

            students.ForEach(s => printer(s));

            Action<Student> PrinterGenerator(string format)
            {
                if (format == "name age")
                {
                    return s => Console.WriteLine($"{s.Name} - {s.Age}");
                }

                if (format == "name")
                {
                    return s => Console.WriteLine($"{s.Name}");
                }

                if (format == "age")
                {
                    return s => Console.WriteLine($"{s.Age}");
                }

                return null;
            }

            Func<Student, int, bool> FilterGenerator(string filterType)
            {
                Func<Student, int, bool> filter = null;

                if (filterType == "older")
                {
                    filter = (students, filterNumber) => students.Age >= filterNumber;
                }

                if (filterType == "younger")
                {
                    filter = (students, filterNumber) => students.Age < filterNumber;
                }

                return filter;
            }
        }
    }
}