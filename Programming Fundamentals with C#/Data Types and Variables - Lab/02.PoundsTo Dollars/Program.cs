namespace _02.PoundsTo_Dollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pounds = int.Parse(Console.ReadLine());
            float dollars = pounds * 1.31f;

            Console.WriteLine($"{dollars:f3}");
        }
    }
}