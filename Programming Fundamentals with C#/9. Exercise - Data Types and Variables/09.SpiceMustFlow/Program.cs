namespace _09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int daysCount = 0;
            int spice = 0;
            int startingYield = yield;

            while (yield >= 100)
            {
                daysCount++;
                spice += yield;
                spice -= 26;
                yield -= 10;

                if (yield < 100)
                {
                    spice -= 26;
                }

            }

            Console.WriteLine(daysCount);
            Console.WriteLine(spice);
        }
    }
}