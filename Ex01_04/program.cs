using System;

namespace Ex01_04
{
    class Program
    {
        static string m_InputString;

        public static void Main()
        {
            GetStringFromUser();
            Console.WriteLine($"The string you entered is: {m_InputString}");

            bool v_IsPalindrome = IsPalindrome(m_InputString);
            Console.WriteLine(v_IsPalindrome
                ? "The string is a palindrome."
                : "The string is not a palindrome.");

            if (IsTheStringHasOnlyDigits(m_InputString))
            {
                Console.WriteLine("The string contains only digits.");
                double numberRepresentedByTheString = double.Parse(m_InputString);

                if (IsTheNumberDivisibleByThree((int)numberRepresentedByTheString))
                {
                    Console.WriteLine("The number is divisible by 3.");
                }
                else
                {
                    Console.WriteLine("The number is not divisible by 3.");
                }
            }
            else
            {
                Console.WriteLine("The string does not contain only digits.");
            }

            if (IsTheStringHasOnlyLetters(m_InputString))
            {
                Console.WriteLine("The string contains only letters.");
                HowManyUpperCaseLetters(m_InputString);

                if (IsAlphabeticallySortedAscending(m_InputString))
                {
                    Console.WriteLine("The string is sorted in ascending order.");
                }
                else
                {
                    Console.WriteLine("The string is not sorted in ascending order.");
                }
            }
            else
            {
                Console.WriteLine("The string does not contain only letters.");
            }
        }

        public static void GetStringFromUser()
        {
            Console.WriteLine("Please enter a 12-character string:");
            m_InputString = Console.ReadLine();
            while (m_InputString.Length != 12)
            {
                Console.WriteLine("Invalid input, please enter exactly 12 characters:");
                m_InputString = Console.ReadLine();
            }
        }

        public static bool IsPalindrome(string i_InputString)
        {
            if (i_InputString.Length <= 1)
            {
                return true;
            }

            if (i_InputString[0] == i_InputString[^1])
            {
                return IsPalindrome(i_InputString.Substring(1, i_InputString.Length - 2));
            }

            return false;
        }

        public static bool IsTheStringHasOnlyDigits(string i_InputString)
        {
            foreach (char c in i_InputString)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsTheNumberDivisibleByThree(int i_InputNumber)
        {
            return i_InputNumber % 3 == 0;
        }

        public static bool IsTheStringHasOnlyLetters(string i_InputString)
        {
            foreach (char c in i_InputString)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static void HowManyUpperCaseLetters(string i_InputString)
        {
            int upperCaseCount = 0;
            foreach (char c in i_InputString)
            {
                if (char.IsUpper(c))
                {
                    upperCaseCount++;
                }
            }
            Console.WriteLine($"There are {upperCaseCount} uppercase letters in the string.");
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