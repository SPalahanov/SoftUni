namespace Dictionary_Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict;

            PrintKeyValuePair<string, int>("Pesho", 6);
            PrintKeyValuePair<int, string>(5, "string");
        }

        static void PrintKeyValuePair<TKey, TValue>(TKey key, TValue value)
        {
            Console.WriteLine(typeof(TKey).Name);
            Console.WriteLine(typeof(TValue).Name);

            Console.WriteLine($"{key} : {value}");
        }
    }
}