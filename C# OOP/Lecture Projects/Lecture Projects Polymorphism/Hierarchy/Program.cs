namespace Hierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Fish fish = new Fish();

            Animal animal;

            animal = dog;
            animal = fish;

            if (new Random().Next() % 2 == 0)
            {
                animal = new Fish();
            }
            else
            {
                animal = new Dog();
            }

            animal.Eat();
        }
    }

    class Animal
    {
        public virtual void Eat()
        {
            Console.WriteLine("Eat");
        }
    }

    class Dog : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Iskam oshte");
        }
    }

    class Fish : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("brrrrrr");
        }
    }
}