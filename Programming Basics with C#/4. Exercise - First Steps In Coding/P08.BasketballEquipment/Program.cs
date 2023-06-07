using System;

namespace P08.BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int annualBasketballFee = int.Parse(Console.ReadLine());

            double shoes = annualBasketballFee - (annualBasketballFee * 40 / 100);
            double outfit = shoes - (shoes * 20 / 100);
            double ball = outfit * 25 / 100;
            double accessory = ball * 20 / 100;

            Console.WriteLine(annualBasketballFee + shoes + outfit + ball + accessory);
        }
    }
}
