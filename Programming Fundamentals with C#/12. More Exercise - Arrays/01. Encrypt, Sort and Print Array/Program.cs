 using System.Collections.Immutable;
 using System.Diagnostics.CodeAnalysis;
 using System.Xml.Serialization;

namespace _01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] finalArr = new int[n];

            int sum = 0;

            for (int i = 0; i < n; i++)
            { 
                string[] names = Console.ReadLine()
                    .Split("")
                    .ToArray();

                int consonantSum = 0;
                int vowelSum = 0;

                char[] numbers = names[0].ToCharArray();

                for (int j = 0; j < numbers.Length; j++)
                {
                    char num = numbers[j];
                    Convert.ToInt32(num);

                    if (num == 65 || num == 97 || num == 79 || num == 111 || num == 73 || num == 105 || num == 69 || num == 101 || num == 85 || num == 117)
                    {
                        int vowel = num * numbers.Length;
                        vowelSum += vowel;
                    }
                    else
                    {
                        int consonant = num / numbers.Length;
                        consonantSum += consonant;
                    }
                    sum = consonantSum + vowelSum;
                }
                finalArr[i] = sum;
            }

            Array.Sort(finalArr);

            foreach (int arr in finalArr)
            {
                Console.WriteLine(arr);
            }
        }
    }
}