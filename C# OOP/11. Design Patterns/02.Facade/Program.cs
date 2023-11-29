namespace Facade
{
    public class Program
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                 .Info.WithType("BMW").WithColor("black").WithNumberOfDoors(5)
                 .Built.InCity("Leipzig").AtAddress("Some address 254")
                 .Build();

            Console.WriteLine(car.ToString());
        }
    }
}