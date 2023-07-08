namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text1 = Console.ReadLine();
            string text2 = Console.ReadLine();
            
            int index = text2.IndexOf(text1);

            //result = text2.Remove(0);

            while (index != -1)
            {
                text2 = text2.Remove(index, text1.Length);
                index = text2.IndexOf(text1);

            }

            Console.WriteLine(text2);
        }
    }
}