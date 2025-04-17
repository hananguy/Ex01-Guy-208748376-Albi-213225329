using system;
using System.IO;

namespace EX01_02
{
    class Program
    {
        int k_NumOfLines; 
        int K_NumOfLinesInTheRoot = 2;
        public static void main()
        {
            int currentDigit = Tree(k_NumOfLines - k_NumOfLinesInTheRoot);
        }
        int Tree(int i_LineNumber)
        {
            if (i_LineNumber == 0)
            {
                printLine(i_LineNumber, 1);  
                return 2;
            }
            else
            {
                int currentDigit = Tree(i_LineNumber - 1);
                printLine(i_LineNumber, currentDigit);  
            } 
        }
        int printLine(int i_LineNumber, int i_CurrentDigit)
        {
            Console.WriteLine("Line {0}: {1}", i_LineNumber, i_CurrentDigit);
            return i_CurrentDigit;
        }
    }
}