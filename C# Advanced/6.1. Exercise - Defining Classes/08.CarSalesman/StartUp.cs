using System.Runtime.InteropServices.ComTypes;

namespace CarSalesman
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int numberOfEngine = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEngine; i++)
            {
                string[] engineArguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineArguments[0];
                int power = int.Parse(engineArguments[1]);
                int displament;
                
                Engine engine = new Engine(model, power);

                if (engineArguments.Length > 2)
                {
                    bool IsDigit = int.TryParse(engineArguments[2], out displament);
                    
                    if (IsDigit)
                    {
                        engine.Displacement = displament;
                    }
                    else
                    {
                        engine.Efficiency = engineArguments[2];
                    }

                    if (engineArguments.Length > 3)
                    {
                        engine.Efficiency = engineArguments[3];
                    }
                    
                }

                engines.Add(engine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carArguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carArguments[0];
                Engine engine = engines.Find(e => e.Model == carArguments[1]);
                int weight;

                Car car = new Car(model, engine);

                if (carArguments.Length > 2)
                {
                    bool IsDigit = int.TryParse(carArguments[2], out weight);

                    if (IsDigit)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carArguments[2];
                    }

                    if (carArguments.Length > 3)
                    {
                        car.Color = carArguments[3];
                    }
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}