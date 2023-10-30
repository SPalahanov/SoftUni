namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            IFlyable flyable = new Plane();

            IDrivable drivable = new Plane();

            flyable.Break();

            drivable.Break();
            
        }
    }

    interface IFlyable
    {
        void Break();
    }

    interface IDrivable
    {
        void Break();
    }

    class Plane : IFlyable, IDrivable
    {
        void IDrivable.Break()
        {
            Console.WriteLine("Drivable Break");
        }

        void IFlyable.Break()
        {
            Console.WriteLine("Flyable Break");
        }
    }
}