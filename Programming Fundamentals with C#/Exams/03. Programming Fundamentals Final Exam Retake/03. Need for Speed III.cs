namespace _03._Need_for_Speed_III
{
    class Car
    {
        public Car(string name, int mileage, int fuel)
        {
            Name = name;
            Mileage = mileage;
            Fuel = fuel;
        }

        public string Name { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|");

                string name = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);

                Car car = new Car(name, mileage, fuel);

                cars[name] = car;
            }

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] arguments = command.Split(" : ");

                string carName = arguments[1];

                if (arguments[0] == "Drive")
                {
                    int distance = int.Parse(arguments[2]);
                    int fuelToConsume = int.Parse(arguments[3]);

                    if (cars[carName].Fuel < fuelToConsume)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[carName].Mileage += distance;
                        cars[carName].Fuel -= fuelToConsume;

                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuelToConsume} liters of fuel consumed.");
                    }

                    if (cars[carName].Mileage >= 100_000)
                    {
                        cars.Remove(carName);
                        Console.WriteLine($"Time to sell the {carName}!");
                    }
                }

                if (arguments[0] == "Refuel")
                {
                    int fuelToRefill = int.Parse(arguments[2]);
                    int maxAmountOfFuel = 75;
                    int refilledFuel;

                    if (cars[carName].Fuel + fuelToRefill > maxAmountOfFuel)
                    {

                        refilledFuel = maxAmountOfFuel - cars[carName].Fuel;
                        cars[carName].Fuel = maxAmountOfFuel;
                    }
                    else
                    {
                        refilledFuel = fuelToRefill;
                        cars[carName].Fuel += fuelToRefill;
                    }

                    Console.WriteLine($"{carName} refueled with {refilledFuel} liters");
                }

                if (arguments[0] == "Revert")
                {
                    int kilometers = int.Parse(arguments[2]);

                    cars[carName].Mileage -= kilometers;

                    if (cars[carName].Mileage < 10_000)
                    {
                        cars[carName].Mileage = 10_000;
                    }
                    else
                    {
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                    }

                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }
}