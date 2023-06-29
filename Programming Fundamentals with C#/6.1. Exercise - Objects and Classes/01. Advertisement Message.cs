namespace _01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMesseges = int.Parse(Console.ReadLine());

            Random random = new Random();

            string[] phrases = {"Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product."};
            string[] events = {"Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"};
            string[] authors = {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
            string[] cities = {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

            for (int i = 0; i < numberOfMesseges; i++)
            {
                int phraseIndex = random.Next(phrases.Length);
                int eventIndex = random.Next(events.Length);
                int authorIndex = random.Next(authors.Length);
                int cityIndex = random.Next(cities.Length);

                string phrase = phrases[phraseIndex];
                string eventName = events[eventIndex];
                string author = authors[authorIndex];
                string city = cities[cityIndex];

                Console.WriteLine($"{phrase} {eventName} {author} – {city}.");
            }
        }
    }
}