namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            HashSet<string> carNumbers = new HashSet<string>(); 

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(", ");

                string direction = command[0];
                string carNumber = command[1];

                if (direction == "IN")
                {
                    carNumbers.Add(carNumber);
                }

                if (direction == "OUT")
                {
                    carNumbers.Remove(carNumber);
                }
            }

            if (carNumbers.Count > 0)
            {
                foreach (var carNumber in carNumbers)
                {
                    Console.WriteLine(String.Join("", carNumber));
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}