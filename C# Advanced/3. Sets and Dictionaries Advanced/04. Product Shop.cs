namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            SortedDictionary<string, Dictionary<string, double>> products = new SortedDictionary<string, Dictionary<string, double>>();

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] command = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = command[0];
                string productName = command[1];
                double price = double.Parse(command[2]);

                if (!products.ContainsKey(shop))
                {
                    products.Add(shop, new Dictionary<string, double>());
                }

                products[shop].Add(productName, price);
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key}->");

                foreach (var kvp in product.Value)
                {
                    Console.WriteLine($"Product: {kvp.Key}, Price: {kvp.Value}");
                }
            }
        }
    }
}