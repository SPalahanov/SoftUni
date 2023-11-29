using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Models
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;
        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;

            Price = new List<decimal>();
        }

        public List<decimal> Price { get; set; }

        public override SandwichPrototype Clone()
        {
            string ingredietList = GetIngredients();

            Console.WriteLine($"Cloning sandwich with ingredients: {ingredietList}");

            return MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngredients()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}
