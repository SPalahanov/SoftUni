namespace AbstractClass
{
    public class Program
    {
        static void Main(string[] args)
        {
            Car car = new DieselCar();

        }
    }

    abstract class Car
    {
        public void Start()
        {
            Console.WriteLine("Starting");
        }

        public abstract void Accelerate();
    }

    class DieselCar : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Diesel acceleration is the best!");
        }
    }
}