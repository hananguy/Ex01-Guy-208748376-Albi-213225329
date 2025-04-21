using System;
using System.Text;


namespace Ex01_05
{
    class Program
    {
        public static void Main()
        {
            int maxDigit;
            string digitsSmallerThanLeftMostArray;
            string digistsDividedBy3Array;
            int leftMostDigit;
            string userInput = GetNumberFromUser();
            int userNumberInteger = Convert.ToInt32(userInput);
            int numOfDigitsSmallerThanLeftMost = CountDigitsSmallerThanLeftmost(userInput, out digitsSmallerThanLeftMostArray, out leftMostDigit);
            int numberOfDigitsDividedByThree = CountDigitsDivisibleBy3(userInput, out digistsDividedBy3Array);
            int maxMinDigitDifference = GetMaxMinDigitDifference(userInput);
            int maxDigitNumberOfAppearances = GetMostFrequentDigitAndCount(userInput, out maxDigit);
            Console.WriteLine($"Input: {userInput}");
            string smallerDigitsDisplay;
            if (numOfDigitsSmallerThanLeftMost > 0)
            {
                smallerDigitsDisplay = digitsSmallerThanLeftMostArray;
            }
            else
            {
                smallerDigitsDisplay = "None";
            }

            Console.WriteLine($"Leftmost digit: {leftMostDigit}. " + $"Digits smaller than it (excluding the first): {smallerDigitsDisplay}. " + $"Total: {numOfDigitsSmallerThanLeftMost}."); Console.WriteLine($"Digits divisible by 3: {digistsDividedBy3Array}. Total: {numberOfDigitsDividedByThree}.");
            Console.WriteLine($"Difference between the largest and smallest digit: {maxMinDigitDifference}");
            Console.WriteLine($"Most frequent digit: {maxDigit} (appears {maxDigitNumberOfAppearances} times)");

        }
        public static string GetNumberFromUser()
        {
            bool isValid;
            string userNumber;

            do
            {
                Console.WriteLine("Please enter an 8‑digit integer: ");
                userNumber = Console.ReadLine();
                isValid = userNumber.Length == 8 && int.TryParse(userNumber, out int resultInteger) == true;
                if (isValid == false)
                {
                    Console.Write("Incorrect input, Please try again.");
                }
            }

            while (isValid == false);

            return userNumber;
        }
        public static int CountDigitsSmallerThanLeftmost(string i_Number,out string o_SmallerDigits, out int i_LeftMostDigit)
        {
            if (string.IsNullOrEmpty(i_Number))
            {
                o_SmallerDigits = string.Empty;
                i_LeftMostDigit = -1;
                return 0;
            }

            i_LeftMostDigit = i_Number[0] - '0';
            StringBuilder sbResStringSmallerDigitsArray = new System.Text.StringBuilder();
            int countNumOfDigitsSmallerThanMostLeft = 0;

            for (int idx = 1; idx < i_Number.Length; idx++)
            {
                char currChar = i_Number[idx];
                int currDigit = currChar - '0';

                if (currDigit < i_LeftMostDigit)
                {
                    if (countNumOfDigitsSmallerThanMostLeft > 0)
                    { 
                        sbResStringSmallerDigitsArray.Append(',');
                    }

                    sbResStringSmallerDigitsArray.Append(currDigit);
                    countNumOfDigitsSmallerThanMostLeft++;
                }
            }

            o_SmallerDigits = sbResStringSmallerDigitsArray.ToString();

            return countNumOfDigitsSmallerThanMostLeft;
        }
    
        public static int ReadIntFromUser()
        {
            Console.WriteLine("Please enter an 8‑digit integer: ");
            string userInput = Console.ReadLine();
            int resultInteger;

            while(int.TryParse(userInput, out resultInteger) == false || userInput.Length != 8)
            {
                Console.Write("Please enter a valid integer (8-digit integer): ");
                userInput = Console.ReadLine();
            }

            return resultInteger;
        }
        public static int CountDigitsDivisibleBy3(string i_Number, out string o_NumberDividedBy3)
        { 
            if (string.IsNullOrEmpty(i_Number))
            {
                o_NumberDividedBy3 = string.Empty;
                return 0;
            }

            string strNumber = i_Number;
            StringBuilder sbNumbersDividedBy3 = new System.Text.StringBuilder();
            int numOfDigitsDivisibleBy3 = 0;

            if (strNumber == "0")
            {
                o_NumberDividedBy3 = "0";
                return 1;
            }

            foreach (char currChar in strNumber)
            {
                int currDigit = currChar - '0';
                if (currDigit % 3 == 0)
                {
                    if (sbNumbersDividedBy3.Length > 0)
                    { 
                        sbNumbersDividedBy3.Append(',');
                    }

                    sbNumbersDividedBy3.Append(currDigit);
                    numOfDigitsDivisibleBy3++;
                }
            }

            o_NumberDividedBy3 = sbNumbersDividedBy3.ToString();

            return numOfDigitsDivisibleBy3;
        }
        public static int GetMaxMinDigitDifference(string i_Number)
        {
            int maxDigit = GetMaxDigitFromInt(i_Number);
            int minDigit = GetMinDigitFromInt(i_Number);

            return maxDigit - minDigit;
        }
        public static int GetMaxDigitFromInt(string i_Number)
        {
            int maxDigit = 0;

            foreach (char currChar in i_Number)
            {
                int currDigit = currChar - '0';
                if (currDigit > maxDigit)
                    maxDigit = currDigit;
            }

            return maxDigit;
        }
        public static int GetMinDigitFromInt(string i_Number)
        {
            int minDigit = 9;

            foreach (char currChar in i_Number)
            {
                int currDigit = currChar - '0';
                if (currDigit < minDigit)
                    minDigit = currDigit;
            }
            return minDigit;
        }
        public static int GetMostFrequentDigitAndCount(string i_Number, out int o_Digit)
        {
            int[] digitCount = new int[10];
            int maxCount = 0;
            int maxDigit = 0;

            foreach (char currChar in i_Number)
            {
                int currDigit = currChar - '0';
                digitCount[currDigit]++;
            }

            for (int i = 0; i < digitCount.Length; i++)
            {
                if (digitCount[i] > maxCount)
                {
                    maxCount = digitCount[i];
                    maxDigit = i;
                }
            }
            
            o_Digit = maxDigit;

            return maxCount;
        }

    }

}
