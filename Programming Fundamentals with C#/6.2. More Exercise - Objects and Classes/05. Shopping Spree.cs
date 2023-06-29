using System;
using System.Collections.Generic;

namespace _05._Shopping_Spree
{
    class Person
    {
        public string Name { get; set; }
        public double Money { get; set; }
        public List<string> Bag { get; set; }

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            Bag = new List<string>();
        }

        public void BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                Bag.Add(product.ProductName);
                Console.WriteLine($"{Name} bought {product.ProductName}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.ProductName}");
            }
        }
    }

    class Product
    {
        public Product(string productName, double cost)
        {
            ProductName = productName;
            Cost = cost;
        }

        public string ProductName { get; set; }

        public double Cost { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string[] input1 = Console.ReadLine().Split(';');
            for (int i = 0; i < input1.Length; i++)
            {
                string[] text1 = input1[i].Split("=");

                string personName = text1[0];
                double money = double.Parse(text1[1]);

                Person person = new Person(personName, money);
                persons.Add(person);
            }

            List<Product> products = new List<Product>();

            string[] input2 = Console.ReadLine().Split(';');
            for (int i = 0; i < input2.Length; i++)
            {
                string[] text2 = input2[i].Split("=");

                string productName = text2[0];
                double cost = double.Parse(text2[1]);

                Product product = new Product(productName, cost);
                products.Add(product);
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] arguments = command.Split();

                string personName = arguments[0];
                string productName = arguments[1];

                Person person = persons.Find(p => p.Name == personName);
                Product product = products.Find(p => p.ProductName == productName);

                person.BuyProduct(product);
            }

            foreach (Person person in persons)
            {
                Console.Write($"{person.Name} - ");
                if (person.Bag.Count > 0)
                {
                    Console.WriteLine(string.Join(", ", person.Bag));
                }
                else
                {
                    Console.WriteLine("Nothing bought");
                }
            }
        }
    }
}
