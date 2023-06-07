using System.Runtime.ExceptionServices;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numAsStr = " ";
            while ((numAsStr = Console.ReadLine()) != "END")            
            {
                Console.WriteLine(IsPalindrom(numAsStr));
            }
        }

        /* ===============First Logic -Method IsPalindrom with Array.Reverse() Methods=============== */

        static bool IsPalindrom(string input)
        {
            char[] arr = input.ToCharArray();

            Array.Reverse(arr);

            string second = new string(arr);

            return input == second;
        }

        /* =======Second Logic - Method IsPalindrom with Substring() and Array.Reverse() Methods=======  */


        //static bool IsPalindrom(string input)
        //{
        //    string first = input.Substring(0, input.Length / 2);
        //    char[] arr = input.ToCharArray();

        //    Array.Reverse(arr);

        //    string temp = new string(arr);
        //    string second = temp.Substring(0, temp.Length / 2);


        //    return first == second;
        //}
    }
}