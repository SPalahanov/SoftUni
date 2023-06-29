namespace _02._Articles
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

        public void EditContent(string text)
        {
            Content = text;
        }

        public void ChangeAuthor(string text)
        {
            Author = text;
        }

        public void RenameTitle(string text)
        {
            Title = text;
        }

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
            string[] articalArguments = Console.ReadLine().Split(", ");

            string title = articalArguments[0];
            string content = articalArguments[1];
            string author = articalArguments[2];

            Articles articles = new Articles(title, content, author);

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] arguments = Console.ReadLine().Split(": ");

                string command = arguments[0];
                string text = arguments[1];

                switch (command)
                {
                    case "Edit":
                        articles.EditContent(text);
                        break;
                    case "ChangeAuthor":
                        articles.ChangeAuthor(text);
                        break;
                    case "Rename":
                        articles.RenameTitle(text);
                        break;
                }
            }

            Console.WriteLine(articles.ToString());
        }
    }
}