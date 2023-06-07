using System;

namespace P04.VacationBooksList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int page = int.Parse(Console.ReadLine());
            int pagePerHours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int totalHours = page / pagePerHours;
            int hoursPerDay = totalHours / days;
            Console.WriteLine(hoursPerDay);
        }
    }
}
