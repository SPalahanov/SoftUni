namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                //=========== this ===========//

                Person person = new Person();

                person.Name = tokens[0];
                person.Age = int.Parse(tokens[1]);
                person.Town = tokens[1];


                //=========== or this ===========//

                //Person person = new Person()
                //{
                //    Name = tokens[0];
                //    Age = int.Parse(tokens[1]);
                //    Town = tokens[1];
                //};

                people.Add(person);
            }

            int compareIndex = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = people[compareIndex];

            int equalCount = 0;
            int diffCount = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equalCount++;
                }
                else
                {
                    diffCount++;
                }
            }

            if (equalCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {diffCount} {people.Count}");
            }
        }
    }
}