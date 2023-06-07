namespace _01._Smallest_Of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int smallest = 0;
            
            smallest = IfFirstIsSmallest(first, second, third, smallest);
            smallest = IfSecondIsSmallest(second, first, third, smallest);
            smallest = IfThirdIsSmallest(third, first, second, smallest);

            Console.WriteLine(smallest);
        }

        static int IfFirstIsSmallest(int first, int second, int third, int smallest)
        {
            if (first <= second && first <= third)
            {
                smallest = first;
            }

            return smallest;
        }

        static int IfSecondIsSmallest(int second, int first, int third, int smallest)
        {
            if (second <= first && second <= third)
            {
                smallest = second;
            }

            return smallest;
        }

        static int IfThirdIsSmallest(int third, int first, int second, int smallest)
        {
            if (third <= first && third <= second)
            {
                smallest = third;
            }

            return smallest;
        }
    }
}