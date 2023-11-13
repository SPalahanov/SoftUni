namespace Finaily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = null;


            try
            {
                //int n = int.Parse(Console.ReadLine());

                //Console.WriteLine("Number read!");

                 reader = new StreamReader("../../../test.txt");
                 int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("OOPS error!");
                throw e;

            }
            finally
            {
                Console.WriteLine("This always executes");

                reader.Close();
            }
        }
    }
}