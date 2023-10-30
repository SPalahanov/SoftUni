namespace RestaurantExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Waiter waiter = new Waiter(new MolecularKitchen());

            while (true)
            {
                waiter.TakeOrder(Console.ReadLine());
            }
        }
    }
}