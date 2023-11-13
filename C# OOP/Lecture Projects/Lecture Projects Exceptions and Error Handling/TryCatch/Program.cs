namespace TryCatch
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number between 1 and 10");

            int number = 0;

            try
            {
                number = int.Parse(Console.ReadLine());

                if (number < 1 || number > 10)
                {
                    throw new ArgumentOutOfRangeException("The number id not between 1 and 10");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception was thrown");
                

                try
                {
                    throw ex;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Second throw catched");
                    
                }
            }

            Console.WriteLine($"The number you entered is: {number}");
        }
    }
}