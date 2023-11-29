using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePattern.Models
{
    public class SourDough : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for SourDough Bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Backing the SourDough Bread. (20 minutes)");
        }
    }
}
