using System;

namespace P09.YardGreening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double space = double.Parse(Console.ReadLine());
            double price = space * 7.61;
            double discount = price * 0.18;
            double finalPrice = price - discount;
            Console.WriteLine($"The final price is {finalPrice} lv.");
            Console.WriteLine($"The discount is {discount} lv.");
        }
    }
}
