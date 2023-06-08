namespace _04._List_Of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();

            string prod;

            for (int i = 0; i < n; i++)
            {
                prod = Console.ReadLine();
                products.Add(prod);
            }

            products.Sort();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }

        }
    }
}