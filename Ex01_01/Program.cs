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

            for (int binaryIndex = 0; binaryIndex < binaryRepresentationNumbers.Length; binaryIndex++)
            {
                binaryRepresentationNumbers[binaryIndex] = GetBinaryNumberFromUser();
            }

            int[] decimalRepresentationNumbers = ConvertBinaryArrayToDecimal(binaryRepresentationNumbers);
            Console.WriteLine();
            Console.WriteLine("The sorted array:");
            SortAndPrint(decimalRepresentationNumbers);
            Console.WriteLine();
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

            for (int charIndex = 0; charIndex < i_legalSize; charIndex++)
            {
                if (i_binaryNumber[charIndex] != '0' && i_binaryNumber[charIndex] != '1')
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
            for (int arrayIndex = 0; arrayIndex < i_NumbersToConvert.Length; arrayIndex++)
            {
                intNumbersArray[arrayIndex] = Convert.ToInt32(i_NumbersToConvert[arrayIndex], 2);
            }
            return intNumbersArray;
        }

        public static void SortAndPrint(int[] i_NumbersArray)
        {
            Array.Sort(i_NumbersArray);
            for (int numberIndex = i_NumbersArray.Length - 1; numberIndex >= 0; numberIndex--)
            {
                Console.Write(string.Format("{0} ", i_NumbersArray[numberIndex]));
            }
            Console.WriteLine();
        }

        public static void CalcAverageAndPrint(int[] i_NumbersArray)
        {
            int sumOfNumbers = 0;
            for (int numberIndex = 0; numberIndex < i_NumbersArray.Length; numberIndex++)
            {
                sumOfNumbers += i_NumbersArray[numberIndex];
            }

            int average = sumOfNumbers / i_NumbersArray.Length;
            Console.WriteLine(string.Format("Average: {0}", average));
        }

        public static void PrintLongestOnesSequence(string[] i_BinaryRepresentationNumbers)
        {
            int currentLongestOnesSequence = 0;
            int countOnes = 0;
            string currentStringWithTheLongestOnesSequence = "";

            for (int binaryIndex = 0; binaryIndex < i_BinaryRepresentationNumbers.Length; binaryIndex++)
            {
                foreach (char binaryChar in i_BinaryRepresentationNumbers[binaryIndex])
                {
                    if (binaryChar == '1')
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
                        currentStringWithTheLongestOnesSequence = i_BinaryRepresentationNumbers[binaryIndex];
                    }
                }

                countOnes = 0;
            }

            Console.WriteLine(string.Format("The longest sequence of ones is {0} in the number {1}", currentLongestOnesSequence, currentStringWithTheLongestOnesSequence));
        }

        public static void CountTransitions(string[] i_BinaryRepresentationNumbers)
        {
            Console.WriteLine();
            Console.WriteLine("Number of transitions (0↔1):");
            for (int binaryIndex = 0; binaryIndex < i_BinaryRepresentationNumbers.Length; binaryIndex++)
            {
                string current = i_BinaryRepresentationNumbers[binaryIndex];
                int transitionCount = 0;

                for (int bitIndex = 0; bitIndex < current.Length - 1; bitIndex++)
                {
                    if (current[bitIndex] != current[bitIndex + 1])
                    {
                        transitionCount++;
                    }
                }

                Console.WriteLine(string.Format("The number {0} has {1} transitions.", current, transitionCount));
            }
        }
        public static void PrintOnesStatistics(string[] i_BinaryRepresentationNumbers)
        {
            int totalOnes = 0;
            int maxOnes = 0;
            string binaryWithMaxOnes = "";

            for (int binaryIndex = 0; binaryIndex < i_BinaryRepresentationNumbers.Length; binaryIndex++)
            {
                int currentOnesCount = CountOnes(i_BinaryRepresentationNumbers[binaryIndex]);
                totalOnes += currentOnesCount;

                if (currentOnesCount > maxOnes)
                {
                    maxOnes = currentOnesCount;
                    binaryWithMaxOnes = i_BinaryRepresentationNumbers[binaryIndex];
                }
            }
            Console.WriteLine();
            Console.WriteLine(string.Format("Total number of '1' bits: {0}", totalOnes));
            Console.WriteLine(string.Format("Number with the most '1' bits: {0} ({1} ones)", binaryWithMaxOnes, maxOnes));
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