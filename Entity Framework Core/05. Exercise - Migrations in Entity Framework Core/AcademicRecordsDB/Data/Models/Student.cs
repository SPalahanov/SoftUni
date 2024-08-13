using System;
using System.Collections.Generic;

namespace AcademicRecordsDB.Data.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();

            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
