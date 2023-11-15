using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions.PromotionsStrategies.Interfaces
{
    public interface IPromotionStrategy
    {
        public decimal ApplyPromotion(decimal price);

        bool isValid();
    }
}
