using System;

namespace P03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyForVacation = double.Parse(Console.ReadLine());
            double balance = double.Parse(Console.ReadLine());
            string type;
            double input;
            int allDays = 0;
            int spendDays = 0;
            while (balance < moneyForVacation)
            {
                type = Console.ReadLine();
                input = double.Parse(Console.ReadLine());
                allDays++;
                if (type == "save")
                {
                    balance += input;
                    spendDays = 0;
                }
                else if (type == "spend")
                {
                    spendDays++;
                    if (spendDays == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine($"{allDays}");
                        break;
                    }
                    
                    balance -= input;

                    if (balance < 0)
                    {
                        balance = 0;
                    }
                }
                //balance += balance;
            }
            if (balance >= moneyForVacation)
            {
                Console.WriteLine($"You saved the money for {allDays} days.");
            }
        }
    }
}
