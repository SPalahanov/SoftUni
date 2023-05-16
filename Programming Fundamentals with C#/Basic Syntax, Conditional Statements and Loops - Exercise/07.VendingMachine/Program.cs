using static System.Net.Mime.MediaTypeNames;

namespace _07.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string comand;
            double sum = 0;
            double balance = 0;
            string purchase;

            while ((comand = Console.ReadLine()) != "Start")
            {
                if (comand == "1")
                {
                    sum += 1;
                }
                else if (comand == "2")
                {
                    sum += 2;
                }
                else if (comand == "0.1")
                {
                    sum += 0.1;
                }
                else if (comand == "0.2")
                {
                    sum += 0.2;
                }
                else if (comand == "0.5")
                {
                    sum += 0.5;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {comand}");
                }
            }
            
            //Console.WriteLine(sum);

            while ((purchase = Console.ReadLine()) != "End")
            {
                if (purchase == "Nuts")
                {
                    sum = sum - 2.0;
                    if (sum >= 0)
                    {
                        Console.WriteLine("Purchased nuts");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        sum += 2.0;
                    }
                }
                else if (purchase == "Water")
                {
                    sum = sum - 0.7;
                    if (sum >= 0)
                    {
                        Console.WriteLine("Purchased water");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        sum += 0.7;
                    }
                }
                else if (purchase == "Crisps")
                {
                    sum = sum - 1.5;
                    if (sum >= 0)
                    {
                        Console.WriteLine("Purchased crisps");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        sum += 1.5;
                    }
                }
                else if (purchase == "Soda")
                {
                    sum = sum - 0.8;
                    if (sum >= 0)
                    {
                        Console.WriteLine("Purchased soda");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        sum += 0.8;
                    }
                }
                else if (purchase == "Coke")
                {
                    sum = sum - 1.0;
                    if (sum >= 0)
                    {
                        Console.WriteLine("Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        sum += 1.0;
                    };
                }
                else
                {
                    Console.WriteLine($"Invalid product");
                }
            }
            Console.WriteLine($"Change: { Math.Abs(sum):f2}");
        }
    }
}