using System.Security;
using System.Transactions;

namespace _01._Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string text = Console.ReadLine();

            char[] arr = text.ToCharArray();

            List<string> list = new List<string>();


            foreach (char c in arr)
            {
                list.Add(c.ToString());
            }

            List<string> finalList = new List<string>();

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                int digits;
                int sum = 0;

                while (listOfNumbers[i] > 0)
                {
                    digits = listOfNumbers[i] % 10;
                    listOfNumbers[i] /= 10;
                    sum += digits;

                }

                if (sum > list.Count)
                {
                    int index = sum - list.Count;

                    finalList.Add(list[index]);
                    list.RemoveAt(index);

                }
                else if (sum < list.Count)
                {
                    int index = sum;

                    finalList.Add(list[index]);
                    list.RemoveAt(index);

                }
                else if (sum == list.Count)
                {
                    int index = 0;

                    finalList.Add(list[index]);
                    list.RemoveAt(index);
                }
            }
            Console.WriteLine(string.Join("", finalList));
        }
    }
}