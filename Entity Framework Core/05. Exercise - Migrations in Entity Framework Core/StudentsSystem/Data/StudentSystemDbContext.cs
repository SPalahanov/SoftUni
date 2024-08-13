using Microsoft.EntityFrameworkCore;
using StudentsSystem.Data.Models;

namespace StudentsSystem.Data
{
    public class StudentSystemDbContext : DbContext
    {
        public virtual DbSet<Resource> Resources { get; set; } = null;
        public virtual DbSet<Course> Courses { get; set; } = null;
        public virtual DbSet<Student> Students { get; set; } = null;
        public virtual DbSet<StudentCourse> StudentsCourses { get; set; } = null;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost\\SQLEXPRESS;Database=StudentsSystemDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // if we want to have the value saved in db as string
            //modelBuilder.Entity<Resource>()
            //    .Property(r => r.ResourceType)
            //    .HasConversion<int>();

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
