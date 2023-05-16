using System;

namespace P07.FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int vegetableMenu = int.Parse(Console.ReadLine());

            double chickenMenuPrice = chickenMenu * 10.35;
            double fishMenuPrice = fishMenu * 12.40;
            double vegetableMenuPrice = vegetableMenu * 8.15;

            double menusPrice = chickenMenuPrice + fishMenuPrice + vegetableMenuPrice;
            double dessertPrice = menusPrice * 20 / 100;
            double orderPrice = menusPrice + dessertPrice + 2.50;

            Console.WriteLine(orderPrice);
        }
    }
}
