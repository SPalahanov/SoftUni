using ShoppingSpree.Models;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            List<Product> products = new List<Product>();

            

            try
            {
                string[] nameMoneyPairs = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var pair in nameMoneyPairs)
                {
                    string[] nameMoney = pair
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    Person person = new(nameMoney[0], decimal.Parse(nameMoney[1]));

                    people.Add(person);
                }

                string[] productCostPairs = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var pair in productCostPairs)
                {
                    string[] productCost = pair
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    Product product = new(productCost[0], decimal.Parse(productCost[1]));

                    products.Add(product);
                }
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return;
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] personProduct = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = personProduct[0];
                string productName = personProduct[1];

                Person person = people.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(p => p.Name == productName);

                if (person is not null && product is not null)
                {
                    Console.WriteLine(person.AddProduct(product));
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }  
    }
}