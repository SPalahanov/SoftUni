namespace BindingFlagsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Weekdays.Wednesday | Weekdays.Sunday);
            Console.WriteLine((int)(Weekdays.Wednesday | Weekdays.Sunday | Weekdays.Monday | Weekdays.Tuesday | Weekdays.Saturday));

            Weekdays combine = (Weekdays)51;

            Console.WriteLine(combine);
        }

        [Flags]
        enum Weekdays
        {
            Monday = 0,
            Tuesday = 1,
            Wednesday = 2,
            Thursday = 4,
            Friday = 8,
            Saturday = 16,
            Sunday = 32,
        }
    }
}