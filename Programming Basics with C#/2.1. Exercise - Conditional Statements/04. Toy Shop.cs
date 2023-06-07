using System;
using System.Runtime.ConstrainedExecution;

namespace P04.ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double vacation = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            int toys = puzzles + dolls + bears + minions + trucks;

            double money = puzzles * 2.60 + dolls * 3 + bears * 4.10 + minions * 8.20 + trucks * 2;

            if (toys >= 50)
            {
                money -= money * 0.25;
            }
            
            money -= money * 0.1;
           

            if (money >= vacation)
            {
                Console.WriteLine($"Yes! {money - vacation:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {vacation - money:f2} lv needed.");
            }
        }
    }
}
