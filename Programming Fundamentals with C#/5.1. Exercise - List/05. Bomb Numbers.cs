using System.Collections.Generic;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            
            string specialNumber = Console.ReadLine();

            string [] arguments = specialNumber.Split(" ");

            while (numbers.Contains(int.Parse(arguments[0])))
            {
                RemoveNumbers(numbers, arguments[0], arguments[1]);
            }

            Console.WriteLine(numbers.Sum());
        }

        static List<int> RemoveNumbers(List<int> numbers, string special, string power)
        {
            int index = numbers.IndexOf(int.Parse(special));
            int rightPower = (numbers.Count - 1) - index;

            if (rightPower < int.Parse(power))
            {
                numbers.RemoveRange(index + 1, rightPower);
            }
            else
            {
                numbers.RemoveRange(index + 1, int.Parse(power));
            }


            if (index - int.Parse(power) < 0)
            {
                numbers.RemoveRange(0, index + 1);
            }
            else
            {
                numbers.RemoveRange(index - int.Parse(power), int.Parse(power) + 1);
            }

            return numbers;
        }
    }
}