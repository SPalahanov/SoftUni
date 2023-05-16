using System;

namespace P04.CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washmachinePrice = double.Parse(Console.ReadLine()); 
            int toyPrice = int.Parse(Console.ReadLine());
            int savedMoney = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savedMoney += i * 5 - 1;
                }
                else
                {
                    savedMoney += toyPrice;
                }
            }
            if (savedMoney >= washmachinePrice)
            {
                Console.WriteLine($"Yes! {savedMoney - washmachinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washmachinePrice - savedMoney:f2}");
            }
        }
    }
}
