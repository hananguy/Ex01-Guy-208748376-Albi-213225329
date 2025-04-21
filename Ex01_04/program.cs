using System;
using System.Text;

namespace Ex01_04
{
    class Program
    {
        private static string s_UserInputString = string.Empty;

        public static void Main()
        {
            GetStringFromUser();
            Console.WriteLine(string.Format("Input: {0}", s_UserInputString));

            Console.WriteLine(" • Is palindrome: {0}", IsPalindrome(s_UserInputString.ToLower()) ? "Yes" : "No");

            if (ContainsOnlyDigits(s_UserInputString))
            {
                if (long.TryParse(s_UserInputString, out long numericValue))
                {
                    Console.WriteLine(" • Divisible by 3: {0}", IsDivisibleByThree(numericValue) ? "Yes" : "No");
                }
                else
                {
                    Console.WriteLine(" • Could not parse number");
                }
            }

            if (ContainsOnlyLetters(s_UserInputString))
            {
                Console.WriteLine(GetUppercaseLettersReport(s_UserInputString));
                Console.WriteLine(" • Alphabetically ascending: {0}", IsAlphabeticallySortedAscending(s_UserInputString.ToLower()) ? "Yes" : "No");
            }
        }

        public static void GetStringFromUser()
        {
            Console.WriteLine("Please enter a 12-character string:");
            s_UserInputString = Console.ReadLine();
            while (s_UserInputString.Length != 12)
            {
                Console.WriteLine("Invalid input, please enter exactly 12 characters:");
                s_UserInputString = Console.ReadLine();
            }
        }

        public static bool IsPalindrome(string i_StringToCheck)
        {
            if (i_StringToCheck.Length <= 1)
            {
                return true;
            }

            if (i_StringToCheck[0] == i_StringToCheck[^1])
            {
                return IsPalindrome(i_StringToCheck.Substring(1, i_StringToCheck.Length - 2));
            }

            return false;
        }

        public static bool ContainsOnlyDigits(string i_StringToCheck)
        {
            foreach (char ch in i_StringToCheck)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsDivisibleByThree(long i_ValueToCheck)
        {
            return i_ValueToCheck % 3 == 0;
        }

        public static bool ContainsOnlyLetters(string i_InputString)
        {
            foreach (char ch in i_InputString)
            {
                if (!char.IsLetter(ch))
                {
                    return false;
                }
            }
            return true;
        }

        public static string GetUppercaseLettersReport(string i_InputString)
        {
            int uppercaseCount = 0;
            StringBuilder builder = new StringBuilder();

            foreach (char letter in i_InputString)
            {
                if (char.IsUpper(letter))
                {
                    uppercaseCount++;
                }
            }

            builder.AppendFormat(" • Uppercase letters: {0}", uppercaseCount);
            return builder.ToString();
        }

        public static bool IsAlphabeticallySortedAscending(string i_InputString)
        {
            for (int i = 0; i < i_InputString.Length - 1; i++)
            {
                if (i_InputString[i] > i_InputString[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
