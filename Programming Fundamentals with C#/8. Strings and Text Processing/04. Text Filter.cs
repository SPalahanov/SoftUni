namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            string text = Console.ReadLine();
            
            foreach (var i in input)
            {
                text = text.Replace(i,new string('*', i.Length));
            }
            Console.WriteLine(text);
        }
    }
}