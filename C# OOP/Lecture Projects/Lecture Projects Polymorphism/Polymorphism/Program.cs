namespace Polymorphism
{
    public class Program
    {
        static void Main(string[] args)
        {
            //IIAnimal animal = new Dog();
            //animal.Eat();

            //animal = new Fish();
            //animal.Eat();

            AnimalEat(new Dog());
        }

        static void AnimalEat(IIAnimal animal)
        {
            animal.Eat();
        }

        interface IIAnimal
        {
            void Eat();
        }

        class Dog : IIAnimal
        {
            public void Eat()
            {
                Console.WriteLine("Dog is eating");
            }
        }

        class Fish : IIAnimal
        {
            public void Eat()
            {
                Console.WriteLine("Fish is eating");
            }
        }
    }
}