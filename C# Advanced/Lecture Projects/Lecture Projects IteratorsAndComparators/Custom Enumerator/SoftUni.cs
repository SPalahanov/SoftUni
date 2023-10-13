using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Enumerator
{
    class SoftUni : IEnumerable<Student>
    {
        private List<Student> students;

        public SoftUni()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return new StudentsEnumerator(students);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
