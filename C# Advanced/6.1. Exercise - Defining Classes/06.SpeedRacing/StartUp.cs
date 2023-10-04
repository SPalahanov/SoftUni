namespace SpeedRacing
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new();

            int carsNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsNumber; i++)
            {
                string[] carProps = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car()
                {
                    Model = carProps[0],
                    FuelAmount = double.Parse(carProps[1]),
                    FuelConsumptionPerKilometer = double.Parse(carProps[2]),
                };

                cars.Add(car.Model, car);
            }

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "End")
                {
                    break;
                }

                string[] driveProps = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = driveProps[1];
                double distance = double.Parse(driveProps[2]);

                Car car = cars[carModel];

                car.CalculateDriving(distance);
            }

            foreach (var car in cars.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}