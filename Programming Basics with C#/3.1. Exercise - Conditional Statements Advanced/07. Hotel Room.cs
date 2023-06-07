using System;

namespace P07.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            string type = "";

            if (month == "May" || month == "October")
            {
                double studio = 50;
                double apartment = 65;
                double studioPrice = nights * studio;
                double apartmentPrice = nights * apartment; ;

                if (nights > 7 && nights <= 14)
                {
                    studioPrice = studioPrice - studioPrice * 0.05;
                    apartmentPrice = apartmentPrice;
                }
                else if (nights > 14)
                {
                    studioPrice = studioPrice - studioPrice * 0.30;
                    apartmentPrice = apartmentPrice - apartmentPrice * 0.10;
                }
                else
                {
                    studioPrice = studioPrice;
                    apartmentPrice = apartmentPrice;
                }
                Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
                Console.WriteLine($"Studio: {studioPrice:f2} lv.");
            }
            else if (month == "June" || month == "September")
            {
                double studio = 75.20;
                double apartment = 68.70;
                double studioPrice = nights * studio;
                double apartmentPrice = nights * apartment; ;

                if (nights > 14)
                {
                    studioPrice = studioPrice - studioPrice * 0.20;
                    apartmentPrice = apartmentPrice - apartmentPrice * 0.10;
                }
                else
                {
                    studioPrice = studioPrice;
                    apartmentPrice = apartmentPrice;
                }
                Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
                Console.WriteLine($"Studio: {studioPrice:f2} lv.");
            }
            else if (month == "July" || month == "August")
            {
                double studio = 76;
                double apartment = 77;
                double studioPrice = nights * studio;
                double apartmentPrice = nights * apartment; ;

                if (nights > 14)
                {
                    apartmentPrice = apartmentPrice - apartmentPrice * 0.10;
                }
                else
                {
                    studioPrice = studioPrice;
                    apartmentPrice = apartmentPrice;
                }
                Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
                Console.WriteLine($"Studio: {studioPrice:f2} lv.");
            }
        }
    }
}
