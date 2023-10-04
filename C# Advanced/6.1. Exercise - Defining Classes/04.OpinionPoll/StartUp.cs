using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = new Dictionary<string, int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] personProperties = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(personProperties[0], int.Parse(personProperties[1]));

                if (person.Age > 30)
                {
                    people.Add(person.Name, person.Age);
                }
            }

            foreach (var kvp in people.OrderBy(p =>p.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}