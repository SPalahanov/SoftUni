namespace IsKeyword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = new Dog();

            if (animal is Dog)
            {
                Console.WriteLine("animal is dog");
            }

            if (animal is Fish)
            {
                Console.WriteLine("animal is fish");
            }

            if (animal is IAnimal && animal is Object)
            {
                Console.WriteLine("IAnimal and Object");
            }

            AnimalEat(new Dog());
            AnimalEat(new Fish());
        }

        static void AnimalEat(IAnimal animal)
        {
            animal.Eat();

            if (animal is Dog)
            {
                ((Dog)animal).Bark();
                
                (animal as Dog).Bark();
            }

            if (animal is Dog dog)
            {
                dog.Bark();
            }
        }

        interface IAnimal
        {
            void Eat();
        }

        class Dog : IAnimal
        {
            public void Eat()
            {
                Console.WriteLine("Dog is eating");
            }

            public void Bark()
            {
                Console.WriteLine("Barking");
            }
        }

        class Fish : IAnimal
        {
            public void Eat()
            {
                Console.WriteLine("Fish is eating");
            }
        }
    }
}