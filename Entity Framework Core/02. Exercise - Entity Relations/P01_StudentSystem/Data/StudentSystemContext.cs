using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using P01_StudentSystem.Data.Models;
using System.Reflection.Emit;
using System.Resources;


namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        private const string connectionString 
            = "Server=localhost\\SQLEXPRESS;Database=StudentSystem;Integrated Security=True";

        /*public StudentSystemContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions)
        {

        }*/

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; } 
        public DbSet<StudentCourse> StudentsCourses { get; set; } 
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new {sc.StudentId, sc.CourseId});
        }
    }
}
