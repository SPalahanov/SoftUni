﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePattern.Models
{
    public class TwelveGrain : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for 12-Grain Bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Backing the 12-Grain Bread. (25 minutes)");
        }
    }
}
