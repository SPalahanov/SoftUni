using System;
using System.Diagnostics.CodeAnalysis;

namespace P08.OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string grade = Console.ReadLine();

            int nights = days - 1;

            if (roomType == "room for one person")
            {
                double pricePerNigts = 18.00;
                double price = pricePerNigts * nights;
                if (days <= 10)
                {
                    if (grade == "positive")
                    {
                        price = price + price * 0.25;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (grade == "negative")
                    {
                        price = price - price * 0.1;
                        Console.WriteLine($"{price:f2}");
                    }
                }
                else if (days > 10 && days < 15)
                {
                    if (grade == "positive")
                    {
                        price = price + price * 0.25;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (grade == "negative")
                    {
                        price = price - price * 0.1;
                        Console.WriteLine($"{price:f2}");
                    }
                }
                else if (days > 15)
                {
                    if (grade == "positive")
                    {
                        price = price + price * 0.25;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (grade == "negative")
                    {
                        price = price - price * 0.1;
                        Console.WriteLine($"{price:f2}");
                    }
                }
            }
            else if (roomType == "apartment")
            {
                double pricePerNigts = 25.00;
                double price = pricePerNigts * nights;
                if (days <= 10)
                {
                    price = price - price * 0.3;
                    if (grade == "positive")
                    {
                        price = price + price * 0.25;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (grade == "negative")
                    {
                        price = price - price * 0.1;
                        Console.WriteLine($"{price:f2}");
                    }
                }
                else if (days > 10 && days < 15)
                {
                    price = price - price * 0.35;
                    if (grade == "positive")
                    {
                        price = price + price * 0.25;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (grade == "negative")
                    {
                        price = price - price * 0.1;
                        Console.WriteLine($"{price:f2}");
                    }
                }
                else if (days > 15)
                {
                    price = price - price * 0.5;
                    if (grade == "positive")
                    {
                        price = price + price * 0.25;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (grade == "negative")
                    {
                        price = price - price * 0.1;
                        Console.WriteLine($"{price:f2}");
                    }
                }
            }
            else if (roomType == "president apartment")
            {
                double pricePerNigts = 35.00;
                double price = pricePerNigts * nights;
                if (days <= 10)
                {
                    price = price - price * 0.1;
                    if (grade == "positive")
                    {
                        price = price + price * 0.25;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (grade == "negative")
                    {
                        price = price - price * 0.1;
                        Console.WriteLine($"{price:f2}");
                    }
                }
                else if (days > 10 && days < 15)
                {
                    price = price - price * 0.15;
                    if (grade == "positive")
                    {
                        price = price + price * 0.25;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (grade == "negative")
                    {
                        price = price - price * 0.1;
                        Console.WriteLine($"{price:f2}");
                    }
                }
                else if (days > 15)
                {
                    price = price - price * 0.2;
                    if (grade == "positive")
                    {
                        price = price + price * 0.25;
                        Console.WriteLine($"{price:f2}");
                    }
                    else if (grade == "negative")
                    {
                        price = price - price * 0.1;
                        Console.WriteLine($"{price:f2}");
                    }
                }
            }
        }
    }
}
