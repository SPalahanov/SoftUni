namespace _01._Student_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //int number;
            //bool isNumber = int.TryParse(input, out number);
            //if (!isNumber)
            //{
            //    Console.WriteLine("Not a number!");
            //}
            //else
            //{
            //    Console.WriteLine(number);
            //}

            string studentName = Console.ReadLine();
            int studentAge = int.Parse(Console.ReadLine());
            double studentGrade = double.Parse(Console.ReadLine());
            Console.WriteLine($"Name: {studentName}, Age: { studentAge}, Grade: { studentGrade:f2}");

        }
    }
}