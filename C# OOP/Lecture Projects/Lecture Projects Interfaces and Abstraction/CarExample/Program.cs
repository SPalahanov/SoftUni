namespace CarExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver(new Horse());

            string input;

            while (true)
            {
                string choice = Console.ReadLine();

                if (choice == "Start")
                {
                    driver.Start();
                }

                if (choice == "Acc")
                {
                    driver.Accelerate();
                }
                if (choice == "Break")
                {
                    driver.Break();
                }
            }
        }
    }
}