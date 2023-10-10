namespace Generic_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            SoftUniList<int> list = new SoftUniList<int>();

            string result = list.GenericMethod<string>("5");
            
        }
    }

    class SoftUniList<TClass>
    {
        public T GenericMethod<T>(T input)
        {
            Console.WriteLine(typeof(T).Name);
            Console.WriteLine(typeof(TClass).Name);
            Console.WriteLine(input);

            return default (T);
        }
    }
}