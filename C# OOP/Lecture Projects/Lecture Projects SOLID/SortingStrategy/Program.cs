using SortingStrategy.SortingStrategies;
using SortingStrategy.SortingStrategies.Interfaces;

namespace SortingStrategy
{
    public class Program
    {
        static void Main(string[] args)
        {
            ISortingStrategy strategy = null;

            Console.WriteLine("How do you want to sort?");

            string type = Console.ReadLine();

            if (type == "Bubble")
            {
                strategy = new BubbleStrategy();
            }
            else if (type == "Selection")
            {
                strategy = new SelectionStrategy();
            }

            Sorter sorter = new Sorter(strategy, new List<int> { 5, 1, 3, 7, 21 });

            sorter.Sort();
        }
    }
}