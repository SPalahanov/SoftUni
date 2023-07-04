namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> dictionary = new SortedDictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (dictionary.ContainsKey(numbers[i]))
                {

                    dictionary[numbers[i]]++;
                }
                else
                {
                    dictionary[numbers[i]] = 1;
                }
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}