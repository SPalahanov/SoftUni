namespace Yield_Return_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerator<int> enumerator = Generate5Numbers();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

        static IEnumerator<int> Generate5Numbers()
        {
            Console.WriteLine("Before yield");

            yield return 5;

            Console.WriteLine("After yield");

            yield return 51;

            Console.WriteLine("After yield");

            yield return 15;

            Console.WriteLine("After yield");

            yield return 335;

            Console.WriteLine("After yield");
        }
    }
}