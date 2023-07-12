using System.Text;

namespace _01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int n = int.Parse(Console.ReadLine()); n > 0; n--)
            {
                string input = Console.ReadLine();

                string name = input.Split('@')[1].Split('|')[0];

                string age = input.Split('#')[1].Split('*')[0];

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}