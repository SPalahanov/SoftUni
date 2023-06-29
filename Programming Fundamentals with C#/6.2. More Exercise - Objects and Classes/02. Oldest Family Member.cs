namespace _02._Oldest_Family_Member
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }

        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public Person GetOldestMember()
        {
            return people.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPerson = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < numberOfPerson; i++)
            {
                string[] inputPersons = Console.ReadLine().Split();

                string name = inputPersons[0];
                int age = int.Parse(inputPersons[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }
            Person oldestPerson = family.GetOldestMember();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }

    }
}