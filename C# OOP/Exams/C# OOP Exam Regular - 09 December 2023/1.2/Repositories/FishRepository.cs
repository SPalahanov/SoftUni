using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository : IRepository<IFish>
    {
        private List<IFish> fishes;

        public FishRepository()
        {
            fishes = new List<IFish>();
        }

        public IReadOnlyCollection<IFish> Models => fishes;

        public void AddModel(IFish model)
        {
            fishes.Add(model);
        }

        public IFish GetModel(string name)
        {
            IFish fish = fishes.FirstOrDefault(f => f.Name == name);

            return fish;
        }
    }
}
