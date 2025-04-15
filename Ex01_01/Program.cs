using System;
using System.Linq;

namespace Ex01_01
{
    class Program
    {
        private const int k_NumberOfBinaryInputs = 4;

        public static void Main()
        {
            Console.WriteLine("Please enter four 7-digit binary numbers:");

            BinaryNumber[] binaryNumbers = new BinaryNumber[k_NumberOfBinaryInputs];

            for (int i = 0; i < k_NumberOfBinaryInputs; i++)
            {
                string userBinaryInput;
                do
                {
                    Console.Write($"Enter binary number #{i + 1}: ");
                    userBinaryInput = Console.ReadLine();
                } while (!BinaryNumber.IsLegalBinaryNumber(userBinaryInput));

                binaryNumbers[i] = new BinaryNumber(userBinaryInput);
            }

            Console.WriteLine("\nSorted by decimal value (descending):");
            PrintSortedByDecimalDescending(binaryNumbers);

            Console.WriteLine($"\nAverage decimal value: {CalculateAverageDecimal(binaryNumbers):F2}");

            var numberWithLongestOnesSequence = binaryNumbers.OrderByDescending(i_Binary => i_Binary.LongestOnesSequence).First();
            Console.WriteLine($"Longest sequence of 1's: {numberWithLongestOnesSequence.LongestOnesSequence} in {numberWithLongestOnesSequence.BinaryRepresentation}");

            Console.WriteLine("\nTransitions from 0 to 1 or 1 to 0:");
            foreach (var i_Binary in binaryNumbers)
            {
                Console.WriteLine($"{i_Binary.BinaryRepresentation} → {i_Binary.TransitionsCount} transitions");
            }

            int totalOnesCount = binaryNumbers.Sum(i_Binary => i_Binary.OnesCount);
            var numberWithMostOnes = binaryNumbers.OrderByDescending(i_Binary => i_Binary.OnesCount).First();
            Console.WriteLine($"\nTotal number of '1's: {totalOnesCount}");
            Console.WriteLine($"Number with most '1's: {numberWithMostOnes.BinaryRepresentation} ({numberWithMostOnes.OnesCount} ones)");
        }

        public static void PrintSortedByDecimalDescending(BinaryNumber[] i_BinaryNumbers)
        {
            foreach (var i_Binary in i_BinaryNumbers.OrderByDescending(i_Binary => i_Binary.DecimalRepresentation))
            {
                Console.WriteLine($"{i_Binary.DecimalRepresentation} ({i_Binary.BinaryRepresentation})");
            }
        }

        public static double CalculateAverageDecimal(BinaryNumber[] i_BinaryNumbers)
        {
            return i_BinaryNumbers.Average(i_Binary => i_Binary.DecimalRepresentation);
        }
    }

    class BinaryNumber
    {
        private const int k_LegalBinaryLength = 7;

        public string BinaryRepresentation { get; private set; }
        public int DecimalRepresentation { get; private set; }
        public int TransitionsCount { get; private set; }
        public int LongestOnesSequence { get; private set; }
        public int OnesCount { get; private set; }

        public BinaryNumber(string i_BinaryInput)
        {
            BinaryRepresentation = i_BinaryInput;
            DecimalRepresentation = Convert.ToInt32(i_BinaryInput, 2);
            TransitionsCount = calculateTransitions();
            LongestOnesSequence = calculateLongestSequenceOfOnes();
            OnesCount = calculateTotalOnes();
        }

        public static bool IsLegalBinaryNumber(string i_BinaryInput)
        {
            return i_BinaryInput.Length == k_LegalBinaryLength && i_BinaryInput.All(i_Char => i_Char == '0' || i_Char == '1');
        }

        private int calculateTransitions()
        {
            int transitions = 0;
            for (int i = 0; i < BinaryRepresentation.Length - 1; i++)
            {
                if (BinaryRepresentation[i] != BinaryRepresentation[i + 1])
                {
                    transitions++;
                }
            }
            return transitions;
        }

        private int calculateLongestSequenceOfOnes()
        {
            int maxStreak = 0, currentStreak = 0;
            foreach (char i_Bit in BinaryRepresentation)
            {
                if (i_Bit == '1')
                {
                    currentStreak++;
                    maxStreak = Math.Max(maxStreak, currentStreak);
                }
                else
                {
                    currentStreak = 0;
                }
            }
            return maxStreak;
        }

        private int calculateTotalOnes()
        {
            return BinaryRepresentation.Count(i_Char => i_Char == '1');
        }
    }
}
