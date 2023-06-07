namespace _02._Grades
{
    internal class Program
    {
        //2.00 – 2.99 - "Fail"
        //3.00 – 3.49 - "Poor"
        //3.50 – 4.49 - "Good"
        //4.50 – 5.49 - "Very good"
        //5.50 – 6.00 - "Excellent"


        static void Main()
        {
            double grade = double.Parse(Console.ReadLine());

            PrintGradeInWords(grade);
        }

        private static void PrintGradeInWords(double grade)
        {
            PrintTwoInWords(grade);

            PrintThreeInWords(grade);

            PrintFourInWords(grade);

            PrintFiveInWords(grade);

            PrintSixInWords(grade);
        }

        private static void PrintSixInWords(double grade)
        {
            if (grade >= 5.50 && grade <= 6.00)
            {
                Console.WriteLine("Excellent");
            }
        }

        private static void PrintFiveInWords(double grade)
        {
            if (grade >= 4.50 && grade <= 5.49)
            {
                Console.WriteLine("Very good");
            }
        }

        private static void PrintFourInWords(double grade)
        {
            if (grade >= 3.50 && grade <= 4.49)
            {
                Console.WriteLine("Good");
            }
        }

        private static void PrintThreeInWords(double grade)
        {
            if (grade >= 3.00 && grade <= 3.49)
            {
                Console.WriteLine("Poor");
            }
        }

        private static void PrintTwoInWords(double grade)
        {
            if (grade >= 2.00 && grade <= 2.99)
            {
                Console.WriteLine("Fail");
            }
        }
    }
}