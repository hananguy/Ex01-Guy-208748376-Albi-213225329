using System;

namespace Ex01_03
{
     class Program
    {
        static int s_TrunkSize = 2;
      public static void Main()
        {
            Console.WriteLine("Please enter the height of the tree (a number between 4 to 15):  ");
            int treeHeight = int.Parse(Console.ReadLine());
            int currentNumberToPrint = 1;
            int numberOfRows = treeHeight - s_TrunkSize;
            Ex01_02.Program.PrintTree(0, numberOfRows, ref currentNumberToPrint);
            Ex01_02.Program.PrintTrunk(numberOfRows, currentNumberToPrint, s_TrunkSize);
            

        }

    }
}
