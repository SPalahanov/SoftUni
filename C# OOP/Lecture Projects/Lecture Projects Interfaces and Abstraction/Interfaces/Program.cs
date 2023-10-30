namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICar car = new Car();

            car.Start();
            car.Accelerate();
            car.Break();


        }


    }

    interface ICar
    {
        void Start();
        void Break();
        void Accelerate();
        public int Speed { get; set; }
    }

    class Car : ICar
    {
        public void Start()
        {
            
        }

        public void Break()
        {

        }

        public void Accelerate()
        {

        }

        public int Speed { get; set; }
    }


}