namespace Multiple_Type_Constraints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    class GenericClass<T1, T2, T3> where T1 : struct where T2 : new ()
    {

    }
}