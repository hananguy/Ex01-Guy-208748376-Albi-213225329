using System;


namespace Ex01_02
{
    class Program
    {
        public static void Main()
        {
            int currentNumberToPrint = 1;
            int totalLevels = 5; 
            PrintTree(0, totalLevels,currentNumberToPrint);

            PrintTrunk('F', totalLevels,8);
            PrintTrunk('G', totalLevels, 8);
        }
      
        static void PrintTree(int i_currentLevel, int  i_numberOfTotalLevels,int io_currentNumberToPrint)
        {  
            if (i_currentLevel >= i_numberOfTotalLevels)
            { 
                return;
            }
            int numberOfSpaces = (i_numberOfTotalLevels - 1 - i_currentLevel) * 2;
            string indentInCurrentLine = new string(' ', numberOfSpaces);
            char currentLetterToPrint = (char)('A' + i_currentLevel);
            Console.Write(currentLetterToPrint + " " + indentInCurrentLine);
            int count = 1 + (2 * i_currentLevel); 
            for (int i = 0; i < count; i++)
            {
                Console.Write(io_currentNumberToPrint + " ");
                io_currentNumberToPrint++;
                if (io_currentNumberToPrint > 9)
                    io_currentNumberToPrint = 1;
            }
            Console.WriteLine();
            PrintTree(i_currentLevel + 1, i_numberOfTotalLevels, io_currentNumberToPrint);
        }

        static void PrintTrunk(char letter, int totalLevels,int valueToPrintInTrunk)
        {
            int spaces = (totalLevels - 1) * 2;
            string indent = new string(' ', spaces);
            Console.Write(letter);
            Console.Write(indent);
            Console.WriteLine($"|{valueToPrintInTrunk}|");
        }
    }
}