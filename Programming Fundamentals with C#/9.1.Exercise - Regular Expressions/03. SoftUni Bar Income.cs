using System.Text.RegularExpressions;

class Customer
{
    public string Name { get; set; }

    public string Product { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public Customer(string name, string product, int quantity, decimal price)
    {
        Name = name;
        Product = product;
        Quantity = quantity;
        Price = price;
    }

    public decimal Method()
    {
        return Quantity * Price;
    }
}

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            string pattern = @"\%([A-Z][a-z]+)\%[^|$%.]*\<(\w+)\>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+(?:\.\d+)?)\$";

            List<Customer> customers = new List<Customer>();

            Regex regex = new Regex(pattern);

            while ((input = Console.ReadLine()) != "end of shift")
            {
                MatchCollection matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    string name = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int quantity = int.Parse(match.Groups[3].Value);
                    decimal price = decimal.Parse(match.Groups[4].Value);

                    Customer customer = new Customer(name, product, quantity, price);

                    customers.Add(customer);
                }
            }

            decimal totalIncome = 0;

            foreach (var customer in customers)
            {
                totalIncome += customer.Method();

                Console.WriteLine($"{customer.Name}: {customer.Product} - {customer.Method():f2}");
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}

//=============== Variant 2 ==============//

/*
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml.Linq;

class Order
{
    public string Name { get; set; }

    public string Product { get; set; }

    public uint Quantity { get; set; }

    public decimal Price { get; set; }

    public Order(string name, string product, uint quantity, decimal price)
    {
        Name = name;
        Product = product;
        Quantity = quantity;
        Price = price;
    }

    public decimal TotalPrice
    {
        get { return Quantity * Price; }
    }
}

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            string pattern = @"\%([A-Z][a-z]+)\%[^|$%.]*\<(\w+)\>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+(?:\.\d+)?)\$";

            decimal totalIncome = 0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                if (Regex.IsMatch(input, pattern) == false)
                {
                    continue;
                }
                
                Match match = Regex.Match(input, pattern);

                string name = match.Groups[1].Value;
                string product = match.Groups[2].Value;
                uint quantity = uint.Parse(match.Groups[3].Value);
                decimal price = decimal.Parse(match.Groups[4].Value);

                Order order = new Order(name, product, quantity, price);

                totalIncome += order.TotalPrice;

                Console.WriteLine($"{order.Name}: {order.Product} - {order.TotalPrice:F2}");
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
 */