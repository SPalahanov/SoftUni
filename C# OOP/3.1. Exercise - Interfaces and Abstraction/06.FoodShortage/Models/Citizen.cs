using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age; 
            Id = id;
            Birthdate = birthdate;
        }
        
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthdate { get; private set; }
        public int Food { get; private set; }
        public int BuyFood()
        {
            return Food += 10;
        }
    }
}
