namespace _01._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            int numberOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double bestResult = 0;
            double bestAttendance = 0;

            for (int i = 1; i <= numberOfStudents; i++)
            {
                double attendance = double.Parse(Console.ReadLine());

                double totalBonus = (attendance / numberOfLectures) * (5 + additionalBonus);

                if (totalBonus >= bestResult)
                {
                    bestResult = totalBonus;
                    bestAttendance = attendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(bestResult)}.");
            Console.WriteLine($"The student has attended {bestAttendance} lectures.");
        }
    }
}