namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (input)
                    {
                        case "Dog":
                            Dog dog = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            Console.WriteLine(input);
                            Console.WriteLine(dog.ToString());
                            break;
                        case "Frog":
                            Frog frog = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            Console.WriteLine(input);
                            Console.WriteLine(frog.ToString());
                            break;
                        case "Cat":
                            Cat cat = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            Console.WriteLine(input);
                            Console.WriteLine(cat.ToString());
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(tokens[0], int.Parse(tokens[1]));
                            Console.WriteLine(input);
                            Console.WriteLine(tomcat.ToString());
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(tokens[0], int.Parse(tokens[1]));
                            Console.WriteLine(input);
                            Console.WriteLine(kitten.ToString());
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}