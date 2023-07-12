using System.Text;

namespace _04._Morse_Code_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string titleOfArticle = Console.ReadLine();

            string contentOfArticle = Console.ReadLine();

            Console.WriteLine($"<h1>\n    {titleOfArticle}\n</h1>");
            Console.WriteLine($"<article>\n    {contentOfArticle}\n</article>");

            string comments;

            while ((comments = Console.ReadLine()) != "end of comments")
            {
                Console.WriteLine($"<div>\n    {comments}\n</div>");

            }
        }
    }
}