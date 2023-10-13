using System.Collections;

namespace Numbers_Enumerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumbersEnumerable nums = new();
            
            foreach (var item in nums)
            {
                Console.Write($"{item} ");
            }
        }
    }

    class NumbersEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new NumbersEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }
    }

    class  NumbersEnumerator : IEnumerator<int>
    {
        private int element = 0;

        public int Current
        {
            get { return element; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            element++;
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}