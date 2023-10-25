namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(100, 200);
            vehicle.Drive(20);
            Console.WriteLine(vehicle.Fuel);

            Car car = new Car(100, 200);
            car.Drive(20);
            Console.WriteLine(car.Fuel);

            RaceMotorcycle motor = new RaceMotorcycle(100, 200);
            motor.Drive(20);
            Console.WriteLine(motor.Fuel);

            SportCar sCar = new SportCar(100, 200);
            sCar.Drive(20);
            Console.WriteLine(sCar.Fuel);
        }
    }
}