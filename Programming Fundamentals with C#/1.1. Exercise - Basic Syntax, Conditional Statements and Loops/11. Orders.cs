namespace _11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orderCount = int.Parse(Console.ReadLine());
            double totalPrice = 0;

            for (int i = 1; i <= orderCount; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                double orderPrice = pricePerCapsule * days * capsulesCount;
                Console.WriteLine($"The price for the coffee is: ${orderPrice:f2}");

                totalPrice += orderPrice;
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}