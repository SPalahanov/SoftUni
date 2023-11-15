using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promotions.PromotionsStrategies.Interfaces;

namespace Promotions.PromotionsStrategies
{
    public class FridayPromotion : IPromotionStrategy
    {
        public decimal ApplyPromotion(decimal price)
        {
            Console.WriteLine("Applying friday promotion");

            return price - price * 0.3m;
        }

        public bool isValid()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                return true;
            }

            return false;
        }
    }
}
