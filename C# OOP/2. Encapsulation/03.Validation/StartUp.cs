using System;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();

                int age = int.Parse(personInfo[2]);
                decimal salary = decimal.Parse(personInfo[3]);

                try
                {
                    Person person = new Person(personInfo[0], personInfo[1], age, salary);

                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            decimal percentage = decimal.Parse(Console.ReadLine());

            foreach (Person person in persons)
            {
                person.IncreaseSalary(percentage);

                Console.WriteLine(person.ToString());
            }

        }
    }
}