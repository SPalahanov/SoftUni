namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> list = new Box<string>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();

                list.Add(input);

            }

            Console.WriteLine(list.ToString());
        }
    }
}