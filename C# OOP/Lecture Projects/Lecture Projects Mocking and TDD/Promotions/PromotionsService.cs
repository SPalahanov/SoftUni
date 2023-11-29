using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions
{
    public class PromotionsService : IPromotionService
    {
        private DateTime dateToday;
        
        public PromotionsService()
        : this(DateTime.Now)
        {
            //poor man's Dependency Injection
        }

        public PromotionsService(DateTime dateToday)
        {
            this.dateToday = dateToday;
        }

        public decimal GetPrice(decimal price)
        {
            if (dateToday.DayOfWeek == DayOfWeek.Thursday)
            {
                return price - price * 0.2m;
            }

            if (dateToday.DayOfWeek == DayOfWeek.Friday)
            {
                return price - price * 0.8m;
            }

            return price;
        }
    }
}
