namespace _07._Order_by_Age
{
    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }

        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split();

                string name = arguments[0];
                string id = arguments[1];
                int age = int.Parse(arguments[2]);

                Person person = new Person(name, id, age);

                persons.Add(person);

                persons = persons.OrderBy(person => person.Age).ToList();
                
            }

            foreach (Person person in persons)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
}