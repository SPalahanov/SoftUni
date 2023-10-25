namespace Persons
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age > 15)
            {
                Person person = new Person(name, age);

                Console.WriteLine(person);
            }
            else
            {
                Child child = new Child(name, age);
                Console.WriteLine(child);
            }

            

            //Person person = new Person("Pesho", 5);

            //Console.WriteLine(person);

            //Child child = new Child("Goshko", 12);

            //Console.WriteLine(child);
        }
    }
}