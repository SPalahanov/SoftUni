using System.Collections;
using System.Security.AccessControl;

namespace Custom_Enumerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            SoftUni softuni = new SoftUni();

            softuni.AddStudent(new Student() {Name = "Dimitrichko", Age = 15});
            softuni.AddStudent(new Student() {Name = "Goshko", Age = 17});

            foreach (var student in softuni)
            {
                Console.WriteLine($"{student.Name} {student.Age}");
            }
        }
    }

    class StudentsEnumerator : IEnumerator<Student>
    {
        private int index = -1;
        private List<Student> students;
        
        public StudentsEnumerator(List<Student> students)
        {
            this.students = students;
        }

        public bool MoveNext()
        {
            index++;

            return index >= students.Count;
        }

        public void Reset()
        {
            index = -1;
        }

        public Student Current => students[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}