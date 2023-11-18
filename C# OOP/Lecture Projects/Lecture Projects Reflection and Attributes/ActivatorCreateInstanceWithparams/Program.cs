namespace ActivatorCreateInstanceWithparams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = (Student)Activator.CreateInstance(typeof(Student), new object [] {"Dimitrichko", "Petrov"});

            Console.WriteLine(student.FirstName);
            Console.WriteLine(student.LastName);
        }

        class Student
        {
            public Student(string firstName, string lasName)
            {
                this.FirstName = firstName;
                this.LastName = lasName;
            }

            public string FirstName { get; set; }

            public string LastName { get; set; }
        }
    }
}