﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name,string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }
        
        public string Name { get; private set; }
        public string Country { get; private set; }
        public int Age { get; private set; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }

        string IPerson.GetName()
        {
            return $"{Name}";
        }

        //string IResident.GetName() => $"Mr/Ms/Mrs {Name}";

        //string IPerson.GetName() => Name;
    }
}
