namespace GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> list = new Box<int>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                int input = int.Parse(Console.ReadLine());

                list.Add(input);
            }

            Console.WriteLine(list.ToString());
        }
    }
}