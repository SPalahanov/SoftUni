namespace Exceptions
{
    public class Program
    {
        static void Main(string[] args)
        {
            Exception ex = new Exception("Ogromna greshka. Vsichko se schupi");

            //Console.WriteLine(ex.Message);

            throw ex;
        }
    }
}