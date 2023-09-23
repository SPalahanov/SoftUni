namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> userNames = new();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                userNames.Add(name);
            }

            foreach (var userName in userNames)
            {
                Console.WriteLine(userName);
            }
        }
    }
}