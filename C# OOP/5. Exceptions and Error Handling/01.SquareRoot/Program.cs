namespace SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double n = double.Parse(Console.ReadLine());

                if (n < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }

                Console.WriteLine(Math.Sqrt(n));

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}