using Moq;
using Promotions.Test.Fakes;

namespace Promotions.Test
{
    public class StoreTests
    {
        private List<Product> products;
        private Store store;
        private Mock<IPromotionService> mockPromotions;

        [SetUp]
        public void Setup()
        {
            mockPromotions = new Mock<IPromotionService>();

            mockPromotions.Setup(p => p.GetPrice(It.IsAny<decimal>())).Returns((decimal v) => v - v * 0.2m);
            
            products = new List<Product>()
            {
                new Product() {Name = "C# OOP", Price = 100},
                new Product() {Name = "C# Advanced", Price = 120}
            };

            store = new Store(products, mockPromotions.Object);
        }

        [Test]
        public void WhenGetProductPriceMethodReturnCorrectPriceForAProduct()
        {
            Assert.AreEqual(80, store.GetProductPrice(products[0].Name));

            mockPromotions.Verify(p =>p.GetPrice(It.IsAny<decimal>()), Times.Exactly(1));
        }

        [Test]
        public void WhenGetProductPriceMethodIsCalledWithInvalidProductThrows()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                store.GetProductPrice("Non Existing");
            });

        }
    }
}