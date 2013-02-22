using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void PrintResult(char [,] sudoco)
        {
            for (byte y = 0; y < 9; y++)
            {
                for (byte x = 0; x < 9; x++)
                {
                    Console.Write(sudoco[y, x]+" ");

                }
                Console.WriteLine();
            }

            //Pause 
            Console.ReadKey();
        }




     
   


        static void Main(string[] args)
        {
            char[,] sudoco = new char [9,9];

            sudoco[0, 0] = '5'; sudoco[0, 1] = '3'; sudoco[0, 4] = '7';
            sudoco[1, 1] = '6'; sudoco[1, 3] = '1'; sudoco[1, 4] = '9';sudoco[1, 5] = '5';
            sudoco[2, 1] = '9'; sudoco[2, 2] = '8'; sudoco[2, 7] = '6';
            sudoco[3, 0] = '8'; sudoco[3, 4] = '6'; sudoco[3, 8] = '3';
            sudoco[4, 0] = '4'; sudoco[4, 3] = '8'; sudoco[4, 5] = '3'; sudoco[4, 8] = '1';
            sudoco[5, 0] = '7'; sudoco[5, 4] = '2'; sudoco[5, 8] = '6';



            PrintResult ( sudoco );

        }
    }
}
