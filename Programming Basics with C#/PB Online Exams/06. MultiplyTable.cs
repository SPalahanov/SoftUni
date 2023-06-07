using System;

namespace _06.MultiplyTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiplier3 = number % 10;
            int num1 = number / 10;
            int multiplier2 = num1 % 10;
            int multiplier1 = num1 / 10;
            //Console.WriteLine(multiplier3);
            //Console.WriteLine(num1);
            //.WriteLine(multiplier2);
            ///.WriteLine(multiplier1);



            for (int i = 1; i <= multiplier3; i++)
            {
                for (int j = 1; j <= multiplier2; j++)
                {
                    for (int l = 1; l <= multiplier1; l++)
                    {
                        Console.WriteLine($"{i} * {j} * {l} = {i * j * l};");
                    }
                }
            }
        }
    }
}
