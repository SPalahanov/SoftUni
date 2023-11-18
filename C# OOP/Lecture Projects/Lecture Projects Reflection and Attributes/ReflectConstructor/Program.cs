using System.Reflection;

namespace ReflectConstructor
{
    public class Program
    {
        static void Main(string[] args)
        {
            Type studentType = typeof(Student);

            ConstructorInfo constructorInfo =
                studentType.GetConstructor(new Type[] { typeof(int), typeof(double), typeof(decimal) });

            Student student = (Student)constructorInfo.Invoke(new object[] { 5, 6d, 7m });

            ConstructorInfo[] constructors = studentType.GetConstructors();

            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.GetParameters().Length);

                ParameterInfo[] parameters = constructor.GetParameters();

                foreach (ParameterInfo parameter in parameters)
                {
                    Console.Write($"{parameter.ParameterType.Name} {parameter.Name}, ");
                }

                Console.WriteLine();
            }
        }
    }

    class Student
    {
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Score = 2;
        }

        public Student()
        {
            
        }

        public Student(int x, double y, decimal z)
        {
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
            Console.WriteLine();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Score { get; set; }
    }
}