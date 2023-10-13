namespace ForEach_As_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new() { 1, 2, 3, 4, 5 };

            foreach (var item in list)
            {
                Console.WriteLine($"foreach {item}");
            }

            ForEach(item => Console.WriteLine($"Custom for each {item}"), list);
            ForEach(item => Console.WriteLine($"Custom for each {item}"), new string[] { "Edna", "Dve" });
        }

        static void ForEach<T>(Action<T> callBack, IEnumerable<T> collection)
        {
            IEnumerator<T> enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                callBack(enumerator.Current);
            }
        }
    }
}