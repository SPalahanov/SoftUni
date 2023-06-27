namespace _04._Students
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

                students.Add(new Student(text[0], text[1], int.Parse(text[2]), text[3]));
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

        public string City { get; set;}
    }
}