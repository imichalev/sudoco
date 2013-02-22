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

            sudoco[0, 0] = '5';
            sudoco[0, 1] = '3';

            PrintResult ( sudoco );

        }
    }
}
