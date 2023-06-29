namespace _03._Articles_2._0
{
    class Articles
    {
        public Articles(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }
        
        public override string ToString()
        {
            string result = $"{Title} - {Content}: {Author}";

            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Articles> articles = new List<Articles>();

            int articleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < articleCount; i++)
            {
                string[] articalArguments = Console.ReadLine().Split(", ");

                string title = articalArguments[0];
                string content = articalArguments[1];
                string author = articalArguments[2];

                Articles article = new Articles(title, content, author);
                articles.Add(article);
            }

            Console.WriteLine(string.Join("\n", articles));
        }
    }
}
