using System.Text;

namespace _02._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstCharacter = char.Parse(Console.ReadLine());

            char lastCharacter = char.Parse(Console.ReadLine());

            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            sb.Append(text);

            int sum = 0;

            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] > firstCharacter && sb[i] < lastCharacter)
                {
                    int num = sb[i];
                    
                    sum += num;
                }
            }

            Console.WriteLine(sum);
        }
    }
}