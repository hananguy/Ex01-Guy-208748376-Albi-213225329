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

            for (int i = 0; i < binaryRepresentationNumbers.Length; i++)
            {
                binaryRepresentationNumbers[i] = GetBinaryNumberFromUser();
            }

            int[] decimalRepresentationNumbers = ConvertBinaryArrayToDecimal(binaryRepresentationNumbers);
            Console.WriteLine("\nThe sorted array:");
            SortAndPrint(decimalRepresentationNumbers);

            CalcAverageAndPrint(decimalRepresentationNumbers);
            PrintLongestOnesSequence(binaryRepresentationNumbers);
            CountTransitions(binaryRepresentationNumbers);
            PrintOnesStatistics(binaryRepresentationNumbers);
        }

        public static bool IsLegalBinaryNumber(string i_binaryNumber, int i_legalSize)
        {
            if (i_binaryNumber.Length != i_legalSize)
            {
                return false;
            }

            for (int i = 0; i < i_legalSize; i++)
            {
                if (i_binaryNumber[i] != '0' && i_binaryNumber[i] != '1')
                {
                    return false;
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
            int[] intNumbersArray = new int[i_NumbersToConvert.Length];
            for (int i = 0; i < i_NumbersToConvert.Length; i++)
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
            Console.WriteLine();
        }

        public static void CalcAverageAndPrint(int[] i_NumbersArray)
        {
            int sumOfNumbers = 0;
            for (int i = 0; i < i_NumbersArray.Length; i++)
            {
                sumOfNumbers += i_NumbersArray[i];
            }

            int average = sumOfNumbers / i_NumbersArray.Length;
            Console.WriteLine($"Average: {average}");
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
            Console.WriteLine("\nNumber of transitions (0↔1):");
            for (int i = 0; i < i_BinaryRepresentationNumbers.Length; i++)
            {
                string current = i_BinaryRepresentationNumbers[i];
                int transitionCount = 0;

                for (int j = 0; j < current.Length - 1; j++)
                {
                    if (current[j] != current[j + 1])
                    {
                        transitionCount++;
                    }
                }

                Console.WriteLine($"The number {current} has {transitionCount} transitions.");
            }
        }
        public static void PrintOnesStatistics(string[] i_BinaryRepresentationNumbers)
        {
            int totalOnes = 0;
            int maxOnes = 0;
            string binaryWithMaxOnes = "";

            for (int i = 0; i < i_BinaryRepresentationNumbers.Length; i++)
            {
                int currentOnesCount = CountOnes(i_BinaryRepresentationNumbers[i]);
                totalOnes += currentOnesCount;

                if (currentOnesCount > maxOnes)
                {
                    maxOnes = currentOnesCount;
                    binaryWithMaxOnes = i_BinaryRepresentationNumbers[i];
                }
            }

            Console.WriteLine($"\nTotal number of '1' bits: {totalOnes}");
            Console.WriteLine($"Number with the most '1' bits: {binaryWithMaxOnes} ({maxOnes} ones)");
        }
        
        public static int CountOnes(string i_BinaryNumber)
        {
            int count = 0;
            foreach (char bit in i_BinaryNumber)
            {
                if (bit == '1')
                {
                    count++;
                }
            }
            return count;
        }
    }
}