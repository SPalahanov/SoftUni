namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            HashSet<string> guests = new HashSet<string>();

            while ((input = Console.ReadLine()) != "PARTY")
            {
                guests.Add(input);
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (guests.Contains(input))
                {
                    guests.Remove(input);
                }
            }
            
            Console.WriteLine(guests.Count);
            
            foreach (var guest in guests.OrderByDescending(x => char.IsDigit(x[0])))
            {
                Console.WriteLine(string.Join(" ", guest));
            }
        }
    }
}