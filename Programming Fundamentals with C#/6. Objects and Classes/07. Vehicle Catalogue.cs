namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            CatalogueVehicle catalogueVehicle = new CatalogueVehicle();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split("/")
                    .ToArray();

                string type = tokens[0];
                string brand = tokens[1];
                string model = tokens[2];
                int index = int.Parse(tokens[3]);


                Trucks truck = new Trucks(brand, model, index);
                Cars cars = new Cars(brand, model, index);

                if (type == "Car")
                {
                    cars.Brand = brand;
                    cars.Model = model;
                    cars.HorsePower = index;
                    catalogueVehicle.Cars.Add(cars);
                }

                if (type == "Truck")
                {
                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = index;
                    catalogueVehicle.Trucks.Add(truck);
                }

            }

            if (catalogueVehicle.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Cars car in catalogueVehicle.Cars.OrderBy(car => car.Brand))
                {

                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalogueVehicle.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Trucks truck in catalogueVehicle.Trucks.OrderBy(trucks => trucks.Brand))
                {

                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }

            }
        }
    }

    public class Trucks
    {
        public Trucks(string brand, string model, int index)
        {
            Brand = brand;
            Model = model;
            Weight = index;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }
    }

    public class Cars
    {
        public Cars(string brand, string model, int index)
        {
            Brand = brand;
            Model = model;
            HorsePower = index;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }
    }

    public class CatalogueVehicle
    {
        public CatalogueVehicle()
        {
            Cars = new List<Cars>();
            Trucks = new List<Trucks>();
        }

        public List<Cars> Cars { get; }

        public List<Trucks> Trucks { get; }
    }
}