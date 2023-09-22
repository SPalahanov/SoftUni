namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            int capacity = int.Parse(Console.ReadLine());

            int rackCount = 0;

            int currentCapacity = 0;

            Stack<int> racks = new Stack<int>(input);
            
            while (racks.Count > 0)
            {
                int currentValue = racks.Pop();
                
                if (currentValue + currentCapacity <= capacity)
                {
                    currentCapacity += currentValue;
                }
                else
                {
                    rackCount++;

                    currentCapacity = currentValue;
                }
            }

            if (currentCapacity > 0)
            {
                rackCount++;
            }

            Console.WriteLine(rackCount);
        }
    }
}