namespace GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> items = new();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string item = Console.ReadLine();

                items.Add(item);
            }

            int[] indices = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstElementIndex = indices[0];
            int secondElementIndex = indices[1];

            Slap(firstElementIndex, secondElementIndex, items);

            foreach (var item in items)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        static void Slap<T>(int firstIndex, int secondIndex, List<T> items)
        {
            T temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
    }
}