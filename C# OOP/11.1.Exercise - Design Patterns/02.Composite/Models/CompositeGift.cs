using Composite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Models
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly ICollection<GiftBase> gifts;

        public CompositeGift(string name, decimal price)
            : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift) => gifts.Add(gift);

        public void Remove(GiftBase gift) => gifts.Remove(gift);

        public override decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            Console.WriteLine($"{Name} contains the foloowing products with prices:");

            foreach (var gift in gifts)
            {
                totalPrice += gift.CalculateTotalPrice();
            }

            return totalPrice;
        }
    }
}
