namespace Comparers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new();

            students.Add(new Student("Student1", 5));
            students.Add(new Student("Student2", 4));
            students.Add(new Student("Student3", 3));
            students.Add(new Student("Student4", 6));

            StudentsComparer comparer = new StudentsComparer();

            //Console.WriteLine(comparer.Compare(students[0], students[1]));

            students.Sort(comparer);

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Name} - {item.Score}");
            }
        }
    }

    class StudentsComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Score.CompareTo(y.Score);
        }
    }


    class Student
    {
        public Student(string name, double score)
        {
            Name = name;
            Score = score;
        }

        public string Name { get; set; }
        public double Score { get; set; }
    }
}