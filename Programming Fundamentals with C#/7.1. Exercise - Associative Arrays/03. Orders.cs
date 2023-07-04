using System.Resources;

namespace _03._Orders
{
    class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public Product(string name, decimal price, decimal quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void Update(decimal price, decimal quantity)
        {
            Price = price;
            Quantity += quantity;
        }

        public override string ToString()
        {
            return $"{Name} -> {Price * Quantity}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string product;

            Dictionary<string, Product> products= new Dictionary<string, Product>();

            while ((product = Console.ReadLine()) != "buy")
            {
                string[] text = product.Split();

                string name = text[0];
                decimal price = decimal.Parse(text[1]);
                decimal quantity = decimal.Parse(text[2]);

                Product newProduct = new Product(name, price, quantity);

                if (!products.ContainsKey(newProduct.Name))
                {
                    products.Add(newProduct.Name, newProduct);
                }
                else
                {
                    products[newProduct.Name].Update(newProduct.Price, newProduct.Quantity);
                }
            }

            foreach (var kvp in products) 
            {
                Console.WriteLine(kvp.Value.ToString());
            }
        }
    }
}