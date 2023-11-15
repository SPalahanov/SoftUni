namespace Promotions
{
    public class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store(new List<Product>()
            {
                new Product() {Price = 100},
            });

            store.PrintProducts();
        }
    }
}