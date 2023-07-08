namespace Problem_01._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalPriceWithoutTax = 0;

            string input = string.Empty;

            while (true)
            {
                input = Console.ReadLine();

                if (input == "special" || input == "regular")
                {

                    break;
                }

                double currentPrice = double.Parse(input);

                if (currentPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }

                totalPriceWithoutTax += currentPrice;
            }

            if (totalPriceWithoutTax == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            double tax = totalPriceWithoutTax * 0.2;

            double totalPrice = totalPriceWithoutTax + tax;

            if (input == "special")
            {

                totalPrice = (totalPriceWithoutTax + tax) * 0.9;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {totalPriceWithoutTax:f2}$");
            Console.WriteLine($"Taxes: {tax:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalPrice:f2}$");
        }
    }
}