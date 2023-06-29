namespace _06._Vehicle_Catalogue
{
    public class Vehicle
    {
        public Vehicle(string type, string model, string color, decimal hP)
        {
            Type = type;
            Model = model;
            Color = color;
            HP = hP;
        }

        private string typeUp;

        public string Type
        {
            get
            {
                return typeUp;
            }
            set
            {
                typeUp = Capitalize(value);
            }
        }
        
        public string Model { get; set; }
         
        public string Color { get; set; }

        public decimal HP { get; set; }
        
        public string Capitalize(string value)
        {
            char[] charArray = value.ToCharArray();
            if (char.IsLower(charArray[0]))
            {
                charArray[0] = char.ToUpper(charArray[0]);

            }

            return new string(charArray);
        }

        public string Print()
        {
            string result = "";

            result += $"Type: {Type}\n";
            result += $"Model: {Model}\n";
            result += $"Color: {Color}\n";
            result += $"Horsepower: {HP}";
            return result;

        }
    }
    
    
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split();

                string type = arguments[0];
                string model = arguments[1];
                string color = arguments[2];
                decimal hP = decimal.Parse(arguments[3]);

                Vehicle vehicle = new Vehicle(type, model,color, hP);
                catalogue.Add(vehicle);
            }

            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                
                // ---------------- Solution 1 -----------------------//

                //Vehicle foundVehicle = catalogue.Find(v => v.Model == command);
                //if (foundVehicle != null)
                //{
                //    Console.WriteLine(foundVehicle.Print());

                //}


                // ---------------- Solution 2 -----------------------//
                foreach (Vehicle vehicle in catalogue)
                {
                    if (vehicle.Model == command)
                    {
                        Console.WriteLine(vehicle.Print());
                    }
                }
            }

            decimal averageHP = catalogue
                .Where(v => v.Type == "Car")  // objects of Type vehicle => Collection
                .Select(v => v.HP) // all objects > HP => collection of Decimals
                .DefaultIfEmpty() //Switch to not nul collection of Decimal
                .Average(); // Average operation of all decimals in Collection

            Console.WriteLine($"Cars have average horsepower of: {averageHP:f2}.");

            averageHP = catalogue
                .Where(v => v.Type == "Truck")  // objects of Type vehicle => Collection
                .Select(v => v.HP) // all objects > HP => collection of Decimals
                .DefaultIfEmpty() //Switch to not nul collection of Decimal
                .Average(); // Average operation of all decimals in Collection

            Console.WriteLine($"Trucks have average horsepower of: {averageHP:f2}.");
        }
    }
}