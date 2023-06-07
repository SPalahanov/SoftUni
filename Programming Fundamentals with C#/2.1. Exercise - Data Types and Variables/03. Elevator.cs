namespace _03.Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfpeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = (int)Math.Ceiling((double)numberOfpeople / capacity);

            Console.WriteLine(courses);
        }
    }
}