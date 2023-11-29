using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions
{
    public interface IPromotionService
    {
        public decimal GetPrice(decimal price);
    }
}
