using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const double BaseDoughCaloriesPerGram = 2;
        private readonly Dictionary<string, double> flourTypes;
        private readonly Dictionary<string, double> bakingTechniques;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            flourTypes = new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1.0 } };
            bakingTechniques = new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };

            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                if (!flourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (!bakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value.ToLower();
            }
        }

        public double Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in range [1..200].");
                }

                weight = value;
            }
        }

        public double DoughCalories
        {
            get
            {
                double flourTypeModifier = flourTypes[FlourType];
                double bakingTechniqueModifier = bakingTechniques[BakingTechnique];

                return BaseDoughCaloriesPerGram * weight * flourTypeModifier * bakingTechniqueModifier;
            }
        }
    }
}
