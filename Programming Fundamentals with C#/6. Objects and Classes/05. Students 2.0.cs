namespace _05._Students_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = " ";
            List<Student> students = new List<Student>();
            while ((input = Console.ReadLine()) != "end")
            {
                string[] text = input.Split(" ").ToArray();

                string firstName = text[0];
                string lastName = text[1];
                int age = int.Parse(text[2]);
                string city = text[3];

                Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

                if (student == null)
                {
                    students.Add(new Student(firstName, lastName, age, city));
                }
                else
                {
                    student.Age = age;
                    student.City = city;
                }
            }

            string cityName = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.City == cityName)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    public class Student
    {
        public Student(string firstName, string lastName, int age, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            City = city;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }
    }
}