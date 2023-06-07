namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int count = 0;

            Console.WriteLine(VowelsCounter(text, count));
        }

        private static int VowelsCounter(string text, int count)
        {
            foreach (char letters in text)
            {
                if (letters == 'a' || letters == 'A' || letters == 'o' ||letters == 'O' || letters == 'e' || letters == 'E' || letters == 'i' || letters == 'I' || letters == 'u' || letters == 'U')
                {
                    count++;
                }
            }
            return count;
        }
    }
}