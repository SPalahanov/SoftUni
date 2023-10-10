namespace Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<object> objects = new List<object>();

            objects.Add(51);

            objects.Add("Hello");

            objects.Add(DateTime.Now);
            objects.Add(DateTime.Now);
            objects.Add(DateTime.Now);
            objects.Add(DateTime.Now);

            foreach (var item in objects)
            {
                if (item is DateTime)
                {
                    Console.WriteLine($"{((DateTime)item).DayOfWeek}");
                }
            }

            List<int> safe = new List<int>();
            safe.Add(5);

            List<object> list = new List<object>();
            list.Add("Hello");
            list.Add(5);



        }
    }
}