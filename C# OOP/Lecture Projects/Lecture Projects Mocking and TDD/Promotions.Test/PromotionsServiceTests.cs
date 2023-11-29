using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateTime = System.DateTime;

namespace Promotions.Test
{
    public class PromotionsServiceTests
    {
        private PromotionsService promotionsService;

        [SetUp]
        public void SetUp()
        {
            promotionsService = new PromotionsService();
        }

        [Test]
        public void WhenThursdayPromotionDiscountShouldBeTwentyPercent()
        {
            promotionsService = new PromotionsService(new DateTime(2023, 11, 23));
            
            Assert.AreEqual(80, promotionsService.GetPrice(100));
        }

        [Test]
        public void WhenFridayPromotionDiscountShouldBeEightyPercent()
        {
            promotionsService = new PromotionsService(new DateTime(2023, 11, 24));


            Assert.AreEqual(20, promotionsService.GetPrice(100));
        }
    }
}
