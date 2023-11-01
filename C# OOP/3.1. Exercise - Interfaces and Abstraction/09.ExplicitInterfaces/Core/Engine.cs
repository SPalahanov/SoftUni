using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<Citizen> citizens = new List<Citizen>();
            
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);
                
                citizens.Add(new Citizen(name, country, age));
            }

            foreach (var citizen in citizens)
            {
                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
