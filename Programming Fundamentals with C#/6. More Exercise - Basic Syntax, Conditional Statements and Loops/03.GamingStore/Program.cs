using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace _03.GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OutFall 4 $39.99
            //CS: OG $15.99
            //Zplinter Zell $19.99
            //Honored 2 $59.99
            //RoverWatch $29.99
            //RoverWatch Origins Edition $39.99

            double balance = double.Parse(Console.ReadLine());
            double currentBalance = 0;
            double startBalance = balance;
            string nameOfGame;
            while ((nameOfGame = Console.ReadLine()) != "Game Time")
            {
                
                if (nameOfGame == "OutFall 4")
                {
                    balance -= 39.99;

                    if (balance < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        balance += 39.99;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {nameOfGame}");
                    }
                }
                else if (nameOfGame == "CS: OG")
                {
                    balance -= 15.99;

                    if (balance < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        balance += 15.99;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {nameOfGame}");
                    }
                }
                else if (nameOfGame == "Zplinter Zell")
                {
                    balance -= 19.99;

                    if (balance < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        balance += 19.99;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {nameOfGame}");
                    }
                }
                else if (nameOfGame == "Honored 2")
                {
                    balance -= 59.99;

                    if (balance < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        balance += 59.99;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {nameOfGame}");
                    }
                }
                else if (nameOfGame == "RoverWatch")
                {
                    balance -= 29.99;


                    if (balance < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        balance += 29.99;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {nameOfGame}");
                    }
                }
                else if (nameOfGame == "RoverWatch Origins Edition")
                {
                    balance -= 39.99;

                    if (balance < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        balance += 39.99;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {nameOfGame}");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }
            if (balance <= 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${startBalance - balance:f2}. Remaining: ${balance:f2}");
            }

            
        }
    }
}