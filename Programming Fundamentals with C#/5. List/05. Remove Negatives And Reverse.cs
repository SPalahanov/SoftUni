namespace _05._Remove_Negatives_And_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            numbers.RemoveAll(n => n < 0);

            if ((numbers.Count) == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                numbers.Reverse(0, numbers.Count);

                Console.WriteLine(String.Join(" ", numbers));
            }
        }
    }
}