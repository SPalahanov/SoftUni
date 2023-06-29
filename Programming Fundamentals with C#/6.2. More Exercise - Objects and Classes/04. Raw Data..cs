using System;
using System.Collections.Generic;
using System.Linq;

/*

After the N lines, you will receive a single line with one of 2 commands: "fragile" or "flamable". If the command
is "fragile", print all cars, whose Cargo Type is "fragile" with cargo with weight < 1000. If the command is
"flamable", print all of the cars whose Cargo Type is "flamable" and have Engine Power > 250. The cars should
be printed in order of appearing in the input.
 */
namespace _04._Raw_Data_
{
    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }
    }

    class Cargo
    {
        public int CargoWeight { get; set; }

        public string CargoType { get; set; }
    }

    class Engine
    {
        public int EngineSpeed { get; set; }

        public int EnginePower { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Engine engine = new Engine()
                {
                    EngineSpeed = engineSpeed,
                    EnginePower = enginePower
                };
                Cargo cargo = new Cargo()
                {
                    CargoWeight = cargoWeight,
                    CargoType = cargoType
                };

                Car car = new Car(model, engine, cargo);

                cars.Add(car);
                
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (Car car in cars.Where(x => x.Cargo.CargoType == "fragile" && x.Cargo.CargoWeight < 1000))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }

            if (command == "flamable")
            {
                foreach (Car car in cars.Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }
    }
}
