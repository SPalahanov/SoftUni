
/*
1 2 1 3
ikegfp'jpne)bv=41P83X@ 
ujfufKt)Tkmyft'duEprsfjqbvfv=53V55XA
find
 */

using System.Text;

namespace _03._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] key = Console.ReadLine().Split();

            string input;

            while ((input = Console.ReadLine()) != "find")
            {
                List<char> convertedList = new List<char>();

                for (int i = 0; i < input.Length; i++)
                {
                    convertedList.Add(input[i]);
                }

                int keyCounter = 0;

                for (int i = 0; i < convertedList.Count; i++)
                {
                    
                    if (keyCounter >= key.Length)
                    {
                        keyCounter = 0;
                        i--;
                    }
                    else
                    {
                        for (int j = keyCounter; j < key.Length; j++)
                        {
                            int num = 0;

                            num = convertedList[i];

                            num -= int.Parse(key[j]);

                            char letter = Convert.ToChar(num);

                            convertedList.RemoveAt(i);
                            convertedList.Insert(i, letter);

                            keyCounter++;
                            break;
                        }
                    }
                }

                int firstIndexType = convertedList.IndexOf('&');
                int lastIndexType = convertedList.LastIndexOf('&');
                List<char> types = convertedList.GetRange(firstIndexType + 1, lastIndexType - firstIndexType - 1);

                int firstIndexCoordinates = convertedList.IndexOf('<');
                int lastIndexCoordinates = convertedList.LastIndexOf('>');
                List<char> coordinates = convertedList.GetRange(firstIndexCoordinates + 1, lastIndexCoordinates - firstIndexCoordinates - 1);

                Console.WriteLine($"Found {String.Join("", types)} at {String.Join("", coordinates)}");
            }
        }
    }
}