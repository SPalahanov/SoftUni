namespace _08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int beerCount = int.Parse(Console.ReadLine());
            
            double bigestVolum = 0;
            string bestModel = " ";

            for (int i = 1; i <= beerCount; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                
                double volume = Math.PI * Math.Pow(radius, 2) * height;
                
                if (volume > bigestVolum)
                {
                    bigestVolum = volume;
                    bestModel = model;
                }
            }
            Console.WriteLine(bestModel);
        }
    }
}