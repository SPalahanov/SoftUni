using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promotions.PromotionsStrategies;
using Promotions.PromotionsStrategies.Interfaces;

namespace Promotions
{
    public class Store
    {
        private List<Product> products;
        private List<IPromotionStrategy> promotionStrategies;

        public Store(List<Product> products)
        {
            this.products = products;
            promotionStrategies = new List<IPromotionStrategy>()
            {
                new BossBirthdayPromotion(),
                new FridayPromotion()
            };
        }

        public void PrintProducts()
        {
            foreach (var product in products)
            {
                decimal price = product.Price;

                foreach (var strategy in promotionStrategies)
                {
                    if (strategy.isValid())
                    {
                        price = strategy.ApplyPromotion(price);
                    }
                }

                Console.WriteLine(price);
            }
        }
    }
}
