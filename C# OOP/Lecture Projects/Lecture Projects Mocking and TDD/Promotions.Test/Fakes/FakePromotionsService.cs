namespace Promotions.Test.Fakes;

public class FakePromotionsService : IPromotionService
{
    public decimal GetPrice(decimal price)
    {
        return price - price * 0.2m;
    }
}