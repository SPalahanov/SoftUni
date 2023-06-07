using System;

namespace P03.TravelAgency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            string type = Console.ReadLine();
            string vip = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double totalPrice = 0;

            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
            }
            else
            {
                double price = 0;
                double discount = 0;


                if (city == "Bansko" || city == "Borovets")
                {
                    if (type == "noEquipment")
                    {
                        price = 80;
                        discount = 0.05;
                    }
                    else if (type == "withEquipment")
                    {
                        price = 100;
                        discount = 0.10;
                    }
                }
                else if (city == "Varna" || city == "Burgas")
                {
                    if (type == "noBreakfast")
                    {
                        price = 100;
                        discount = 0.07;
                    }
                    else if (type == "withBreakfast")
                    {
                        price = 130;
                        discount = 0.12;
                    }
                }

                if (price == 0 && discount == 0)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    if (vip == "yes")
                    {
                        price -= price * discount;
                    }

                    if (days > 7)
                    {
                        days -= 1;
                    }

                    totalPrice = days * price;
                    Console.WriteLine($"The price is {totalPrice:f2}lv! Have a nice time!");
                }
            }
        }
    }
}
