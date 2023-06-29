namespace _03._Speed_Racing
{
    class Car
    {
        public Car(string model, decimal fuelAmount, decimal fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            Distance = 0;
        }

        public string Model { get; set; }

        public decimal FuelAmount { get; set; }

        public decimal FuelConsumption { get; set; }

        public decimal Distance { get; set; }

        public bool CanMoveDistance(decimal distance)
        {
            decimal fuelNeeded = distance * FuelConsumption;

            if (FuelAmount >= fuelNeeded)
            {
                FuelAmount -= fuelNeeded;
                Distance += distance;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {Distance}";
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                List<Car> cars = new List<Car>();

                int numberOfCar = int.Parse(Console.ReadLine());

                for (int i = 0; i < numberOfCar; i++)
                {
                    string[] carInformation = Console.ReadLine().Split();

                    string model = carInformation[0];
                    decimal fuelAmount = decimal.Parse(carInformation[1]);
                    decimal fuelConsumption = decimal.Parse(carInformation[2]);

                    Car car = new Car(model, fuelAmount, fuelConsumption);

                    cars.Add(car);

                }

                string command;

                while ((command = Console.ReadLine()) != "End")
                {
                    string[] carInformation = command.Split();

                    string model = carInformation[1];
                    decimal distance = decimal.Parse(carInformation[2]);

                    Car car = cars.FirstOrDefault(c => c.Model == model);

                    if (car != null)
                    {
                        if (!car.CanMoveDistance(distance))
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                        }
                    }
                }

                foreach (Car car in cars)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}