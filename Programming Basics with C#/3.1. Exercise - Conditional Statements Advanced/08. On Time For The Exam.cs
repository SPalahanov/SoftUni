using System;

namespace P08.OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMinutes;
            int arrivalTime = arrivalHour * 60 + arrivalMinutes;

            int min = examTime - arrivalTime;

            if (min <= 30 && min >= 0)
            {
                Console.WriteLine("On time");
                if (min > 0) 
                {
                    Console.WriteLine($"{min} minutes before the start");
                }
            }
            else if (min > 30)
            {
                if (min < 60)
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{min} minutes before the start");
                }
                else
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{min / 60}:{min % 60:d2} hours before the start");
                }
            }
            else if (min < 0)
            {
                if (min > -60)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{Math.Abs(min)} minutes after the start");
                }
                else
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{Math.Abs(min / 60)}:{Math.Abs(min % 60):d2} hours after the start");
                }
            }
        }
    }
}
