using StudentsSystem.Data;
using StudentsSystem.Data.Models;

namespace StudentsSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var context = new StudentSystemDbContext();

            Resource newResource = new Resource()
            {
                Name = "EF Intro Video",
                Url = "https://softuni.bg/ef/video1",
                ResourceType = ResourceType.Video
            };

            /*context.Resources.Add(newResource);
            context.SaveChanges();*/

            var resources = context.Resources
                .ToArray();

            foreach (var resourse in resources)
            {
                Console.WriteLine($"{resourse.Name} {resourse.ResourceType}");
            }
        }
    }
}
