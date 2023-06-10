using System.Linq;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split("|")
                .ToList();

            list.Reverse(0, list.Count);

            string text = string.Join(" ", list);

            string[] arr = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}