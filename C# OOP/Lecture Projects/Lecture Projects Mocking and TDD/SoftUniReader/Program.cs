namespace SoftUniReader
{
    public class Program
    {
        static void Main(string[] args)
        {
            SoftUniReader reader = new SoftUniReader(new HTTPRequester());
            Console.WriteLine(reader.ReadSoftUniData());
        }
    }
}