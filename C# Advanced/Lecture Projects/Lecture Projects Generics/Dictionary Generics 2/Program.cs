namespace Dictionary_Generics_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoftUniDictionaty<string, int> dict = new SoftUniDictionaty<string, int>();

            dict.Add("pesho", 6);
        }
    }

    class SoftUniDictionaty<TKey, TValue>
    {
        private List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>();

        public void Add(TKey key, TValue value)
        {
            list.Add(new KeyValuePair<TKey, TValue>());
        }
    }
}