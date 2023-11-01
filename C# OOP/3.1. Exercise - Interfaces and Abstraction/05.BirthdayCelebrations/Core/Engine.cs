using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<string> specificBirthdates = new List<string>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string inputType = tokens[0];

                if (inputType == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];

                    ICitizen citizen = new Citizen(name, age, id, birthdate);

                    specificBirthdates.Add(citizen.Birthdate);
                }
                else if (inputType == "Pet")
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];

                    IPet pet = new Pet(name, birthdate);

                    specificBirthdates.Add(pet.Birthdate);
                }
            }

            string specificYear = Console.ReadLine();

            if (specificBirthdates.Any())
            {
                foreach (var specificBirthdate in specificBirthdates)
                {
                    if (specificBirthdate.EndsWith(specificYear))
                    {
                        Console.WriteLine(specificBirthdate);
                    }
                }
            }
        }
    }
}
