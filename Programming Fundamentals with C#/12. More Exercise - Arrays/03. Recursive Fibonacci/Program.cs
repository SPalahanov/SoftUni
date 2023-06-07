using Microsoft.VisualBasic;

namespace _03._Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int fibonachiNumber = int.Parse(Console.ReadLine());

            int[] startArr = new int[] { 1, 1 };


            for (int i = 0; i < fibonachiNumber; i++)
            {
                int[] fibonachiSequence = new int[startArr.Length + 1];
                fibonachiSequence[0] = 1;
                fibonachiSequence[1] = 1;

                for (int j = 2; j < fibonachiSequence.Length; j++)
                {
                    fibonachiSequence[j] = startArr[j - 2] + startArr[j - 1];
                }

                startArr = fibonachiSequence.ToArray();
            }

            Console.WriteLine($"{startArr[fibonachiNumber - 1]}");
        }
    }
}