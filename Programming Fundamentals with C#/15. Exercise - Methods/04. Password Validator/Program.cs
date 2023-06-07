using System;
using System.Text.RegularExpressions;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool firstCheck = CheckIfPasswordIsBetween6And10Characters(password);
            bool secondCheck = CheckIfPasswordConsistOnlyOfLettersAndDigits(password);
            bool thirdCheck = CheckIfPasswordHaveAtLeast2Digits(password);

            PrintIfPasswordIsValid(firstCheck, secondCheck, thirdCheck);
        }

        private static void PrintIfPasswordIsValid(bool firstCheck, bool secondCheck, bool thirdCheck)
        {
            if (firstCheck == true && secondCheck == true && thirdCheck == true)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool CheckIfPasswordHaveAtLeast2Digits(string password)
        {
            if (Regex.IsMatch(password, @"\d{2}"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Password must have at least 2 digits");
                return false;
            }
        }

        static bool CheckIfPasswordConsistOnlyOfLettersAndDigits(string password)
        {
            if (Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Password must consist only of letters and digits");
                return false;
            }
        }

        static bool CheckIfPasswordIsBetween6And10Characters(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return false;
            }
        }
    }
}