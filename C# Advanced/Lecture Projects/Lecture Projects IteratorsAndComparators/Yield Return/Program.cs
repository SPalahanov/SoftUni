using System.Collections;

namespace Yield_Return
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Enumerable list = new Enumerable();
            
            foreach (var item in list)
            {
                Console.WriteLine(item);
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

        class Enumerable : IEnumerable<int>
        {
            public IEnumerator<int> GetEnumerator()
            {
                return Generate5Numbers();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return Generate5Numbers();
            }
        }
    }
}