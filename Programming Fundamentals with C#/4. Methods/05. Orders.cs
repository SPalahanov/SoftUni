namespace _05._Orders
{
    internal class Program
    {

        //Create a program that calculates and prints the total price of an order.The method should receive two parameters:
        //• A string, representing a product - "coffee", "water", "coke", "snacks"
        //• An integer, representing the quantity of the product
        //The prices for a single item of each product are:
        //• coffee – 1.50
        //• water – 1.00
        //• coke – 1.40
        //• snacks – 2.00
        //Print the result, rounded to the second decimal place.
        
        static void Main(string[] args)
        {
            string product = Console.ReadLine();

            int quantity = int.Parse(Console.ReadLine());

            PrintTotalPrice(product, quantity);
        }

        private static void PrintTotalPrice(string? product, int quantity)
        {
            CalculateCoffeesPrice(product, quantity);
            CalculateCokesPrice(product, quantity);
            CalculateWatersPrice(product, quantity);
            CalculateSnacksPrice(product, quantity);
        }

        static void CalculateCoffeesPrice(string product, int quantity)
        {
            if (product == "coffee")
            {
                double price = quantity * 1.50;
                Console.WriteLine($"{price:f2}");
            }
        }
        static void CalculateWatersPrice(string product, int quantity)
        {
            if (product == "water")
            {
                double price = quantity * 1.00;
                Console.WriteLine($"{price:f2}");
            }
        }
        static void CalculateCokesPrice(string product, int quantity)
        {
            if (product == "coke")
            {
                double price = quantity * 1.40;
                Console.WriteLine($"{price:f2}");
            }
        }
        static void CalculateSnacksPrice(string product, int quantity)
        {
            if (product == "snacks")
            {
                double price = quantity * 2.00;
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}