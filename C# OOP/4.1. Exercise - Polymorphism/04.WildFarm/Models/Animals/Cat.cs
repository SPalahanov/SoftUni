using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }
        protected override double WeightMultiplier => CatWeightMultiplier;
        protected override IReadOnlyCollection<Type> PreferredFoodTypes 
            => new HashSet<Type> { typeof(Meat), typeof(Vegetable), typeof(Fruit), typeof(Seeds) };
        public override string ProduceSound()
            => "Meow";
    }
}
