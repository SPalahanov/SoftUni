using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShortage.Core.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                if (tokens.Length == 4)
                {
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    IBuyer citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(citizen);
                }
                else
                {
                    string group = tokens[2];

                    IBuyer rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }
            
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                buyers.FirstOrDefault(b => b.Name == command)?.BuyFood();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
