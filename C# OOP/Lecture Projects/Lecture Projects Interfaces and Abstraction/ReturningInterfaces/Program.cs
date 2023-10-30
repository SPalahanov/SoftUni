namespace ReturningInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> list = Method();

            List<int> list2 = Method().ToList();    
        }

        static IEnumerable<int> Method()
        {
            return new List<int>();
        }
    }

    
}