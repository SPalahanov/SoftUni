using System.Diagnostics.CodeAnalysis;

namespace MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(",");

            Dictionary<int, double> bankAccounts = new Dictionary<int, double>();

            foreach (string item in input)
            {
                double[] inputTokens = item
                    .Split('-')
                    .Select(double.Parse)
                    .ToArray();

                bankAccounts.Add((int)inputTokens[0], inputTokens[1]);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    int accountNumber = int.Parse(tokens[1]);
                    double sum = double.Parse(tokens[2]);

                    if (!bankAccounts.ContainsKey(accountNumber))
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    double currentBalance = bankAccounts[accountNumber];

                    if (tokens[0] == "Deposit")
                    {

                        bankAccounts[accountNumber] = currentBalance + sum;
                    }
                    else if (tokens[0] == "Withdraw")
                    {
                        if (sum > bankAccounts[accountNumber])
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }

                        bankAccounts[accountNumber] = currentBalance - sum;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                    Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:f2}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Enter another command");
            }
        }
    }
}