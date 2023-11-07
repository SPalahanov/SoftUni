namespace PolymorphismMore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object obj;

            IEnumerable<int> list;
            ICollection<int> list2;
            IList<int> list3;
            List<int> list4;
        }

        static void Eat(IEnumerable<int> list)
        {
            foreach (var item in list)
            {
                
            }
        }
    }
}