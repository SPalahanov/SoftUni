using System.Security.Cryptography.X509Certificates;

namespace Constraints
{
    public class Program
    {
        static void Main(string[] args)
        {
            Zoo<Animal> animals;
            
            Zoo<Fish> fish;

            Zoo<Lion> lions = new Zoo<Lion>();

            lions.Add(new Lion());
            lions.PrintAllAnimals();
        }
    }

    class Zoo<T> where T : Animal, new() 
    {
        private List<T> animals = new List<T>();

        public void Add(T element)
        {
            animals.Add(element);
        }

        public void PrintAllAnimals()
        {
            T fish = new T();
            fish.Age = 5;
            
            foreach (T animal in animals)
            {
                Console.WriteLine($"{animal.Name} : {animal.Age}");
                Console.WriteLine(animal);
            }
        }
    }

    class Animal
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    class Fish : Animal
    {
        public bool SweatWater { get; set; }
    }

    class Lion : Animal
    {
        public int MeatPerWeek { get; set; }
    }
}