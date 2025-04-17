using System;


namespace Ex01_02
{
    public class Program
    {
        static int s_StartingLevel = 0;
        static int s_TotalLevels = 5;
        static int s_TrunkLength = 2;
        public static void Main()
        {
            int currentNumberToPrint = 1;
            PrintTree(s_StartingLevel, s_TotalLevels, ref currentNumberToPrint);
            PrintTrunk(s_TotalLevels, currentNumberToPrint, s_TrunkLength);
        }
        
        public static void PrintTree(int i_CurrentLevel, int  i_NumberOfTotalLevels, ref int io_CurrentNumberToPrint)
        {  
            if (i_CurrentLevel >= i_NumberOfTotalLevels)
            { 
                return;
            }
            int numberOfSpaces = (i_NumberOfTotalLevels - 1 - i_CurrentLevel) * 2;
            string indentInCurrentLine = new string(' ', numberOfSpaces);
            char currentLetterToPrint = (char)('A' + i_CurrentLevel);
            Console.Write(currentLetterToPrint + " " + indentInCurrentLine);
            int numOfDigitsToPrintInCurrentRow = 1 + (2 * i_CurrentLevel); 
            PrintTreeRow(numOfDigitsToPrintInCurrentRow, ref io_CurrentNumberToPrint);
            PrintTree(i_CurrentLevel + 1, i_NumberOfTotalLevels, ref io_CurrentNumberToPrint);
        }
        public static void PrintTreeRow(int i_NumberOfDigitsToPrint, ref int io_FirstDigitToPrint)
        {
            for (int i = 0; i < i_NumberOfDigitsToPrint; i++)
            {
                Console.Write(io_FirstDigitToPrint + " ");
                io_FirstDigitToPrint++;
                if (io_FirstDigitToPrint > 9)
                    io_FirstDigitToPrint = 1;
            }
            Console.WriteLine();
        }
        public static void PrintTrunk(int i_NumberOfRowsInTree,int i_ValueToPrintInTrunk,int i_TrunkLength)
        {
            int spacesNeededForTrunkRow = (i_NumberOfRowsInTree - 1) * 2;
            string indentFromLeft = new string(' ', spacesNeededForTrunkRow);
            char currentLetterToPrint = (char)('A' + i_NumberOfRowsInTree);
            for(int i = 0;i < i_TrunkLength; i++)
            {
                Console.Write(currentLetterToPrint);
                Console.Write(indentFromLeft);
                Console.WriteLine($"|{i_ValueToPrintInTrunk}|");
                currentLetterToPrint++;
            }
            
        }
    }
}