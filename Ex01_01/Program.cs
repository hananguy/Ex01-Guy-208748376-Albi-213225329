using System;
using System.IO;

namespace Ex01_01
{

    class Program
    {
        private const int k_BinaryInputCount = 4;
        private const int k_LegalSizeForBinaryNumberInput = 7;

        public static void Main()
        {
            Console.WriteLine("Please enter four numbers in their binary representation:");
            string[] binaryRepresentationNumbers = new string[k_BinaryInputCount];
            //To function: 
            for (int i = 0; i < binaryRepresentationNumbers.Length; i++)
            {
                binaryRepresentationNumbers[i] = GetBinaryNumberFromUser();
            }
            //////////

            int[] decimalRepresentationNumbers = ConvertBinaryArrayToDecimal(binaryRepresentationNumbers);
            Console.WriteLine("The sorted array:");
            SortAndPrint(decimalRepresentationNumbers);
            CalcAverageAndPrint(decimalRepresentationNumbers);
            PrintLongestOnesSequence(binaryRepresentationNumbers);
        }
        public static bool IsLegalBinaryNumber(string i_binaryNumber, int i_legalSize)
        {
            if (i_binaryNumber.Length != i_legalSize)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < i_legalSize; i++)
                {
                    if (i_binaryNumber[i] != '0' && i_binaryNumber[i] != '1')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static string GetBinaryNumberFromUser()
        {
            string inputNumber = Console.ReadLine();
            bool v_isLegalInput = IsLegalBinaryNumber(inputNumber, k_LegalSizeForBinaryNumberInput);
            while (!v_isLegalInput)
            {
                Console.WriteLine("Invalid input, please try again:");
                inputNumber = Console.ReadLine();
                v_isLegalInput = IsLegalBinaryNumber(inputNumber, k_LegalSizeForBinaryNumberInput);
            }
            return inputNumber;
        }
        public static int[] ConvertBinaryArrayToDecimal(string[] i_NumbersToConvert)
        {
            int stringSize = i_NumbersToConvert.Length;
            int[] intNumbersArray = new int[stringSize];
            for (int i = 0; i < stringSize; i++)
            {
                intNumbersArray[i] = Convert.ToInt32(i_NumbersToConvert[i], 2);
            }
            return intNumbersArray;
        }
        public static void SortAndPrint(int[] i_NumbersArray)
        {
            Array.Sort(i_NumbersArray);
            for (int i = i_NumbersArray.Length - 1; i >= 0; i--)
            {
                Console.Write($"{i_NumbersArray[i]} ");
            }
        }
        public static void CalcAverageAndPrint(int[] i_NumbersArray)
        {
            int sumOfNumbers = 0;
            for (int i = 0; i < i_NumbersArray.Length; i++)
            {
                sumOfNumbers += i_NumbersArray[i];
            }
            int average = sumOfNumbers / i_NumbersArray.Length;
            Console.WriteLine(average);
        }
        public static void PrintLongestOnesSequence(string[] i_BinaryRepresentationNumbers)
      
        {
            int currentLongestOnesSequence = 0;
            int countOnes = 0;
            string currentStringWithTheLongestOnesSequence = "";
            for (int i = 0; i < i_BinaryRepresentationNumbers.Length; i++)
            {
                foreach (char ch in i_BinaryRepresentationNumbers[i])
                {
                    if (ch == '1')
                    {
                        countOnes++;
                    }
                    else
                    {
                        countOnes = 0;
                    }
                    if (countOnes > currentLongestOnesSequence)
                    {
                        currentLongestOnesSequence = countOnes;
                        currentStringWithTheLongestOnesSequence = i_BinaryRepresentationNumbers[i];
                    }
                }
                countOnes = 0;
                
            }
            Console.WriteLine($"The longest sequence of ones is {currentLongestOnesSequence} in the number {currentStringWithTheLongestOnesSequence}.");

        }

        public static void CountTransitions(string[] i_BinaryRepresentationNumbers)
        {
            int currentTransitionsCount = 0;
            string currentString = "";
            for (int i = 0; i < i_BinaryRepresentationNumbers.Length; i++)
            {
                foreach (char ch in i_BinaryRepresentationNumbers[i])
                {



                    
                }
                currentTransitionsCount = 0;
            }
    }
}
    

