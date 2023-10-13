namespace Compare_Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new("Pesho", 6);
            Student student2 = new("Gesho", 6);

            Console.WriteLine(student.CompareTo(student2) == 1 ? "Pesho is a better student" : "Gosho is better");

            List<Student> students = new();

            students.Add(student);
            students.Add(student2);
            students.Add(new Student("Student1", 5));
            students.Add(new Student("Student2", 4));
            students.Add(new Student("Student3", 3));
            students.Add(new Student("Student4", 6));

            students.Sort();

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Name} - {item.Score}");
            }
        }
    }


    class Student : IComparable<Student>
    {
        public Student(string name, double score)
        {
            Name = name;
            Score = score;
        }
        
        public string Name { get; set; }
        public double Score { get; set; }
        public int CompareTo(Student? other)
        {
            Console.WriteLine($"Comparing {Name} with {other.Score}");
            
            if (Score < other.Score)
            {
                return -1;
            }
            else if (Score == other.Score)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}