namespace ActivatorCreateInstance
{
    public class Program
    {
        static void Main(string[] args)
        {
            Type studentype = typeof(Student);

            Student student = (Student)Activator.CreateInstance(studentype);
        }
    }

    class Student
    {
        public Student()
        {
            Console.WriteLine("Student was created!");
        }
        public void SayHi()
        {
            Console.WriteLine("Hello from student");
        }
    }
}