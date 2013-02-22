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


        static bool ValidNumber(byte y ,byte x,  char number, char [,] sudoco)
        {
            
             
          //Check x
            for (byte i = 0; i < 9; i++)
            {
              if (number == sudoco[y,i]) return false;
            }

          //Check Y
            for (byte i = 0; i < 9; i++)
            {
                if (number == sudoco[i, x]) return false;
            }

         // Check Cube
            for (byte i = 0; i < 9; i++)
            {
               
               
                sudoco[y,x] = 'a';
                if ((y == 2 && x==2 ) || (y == 5 && x==5) || (y == 8 && x==8)) y -= 2;
                if (x == 2 || x == 5 || x == 8)
                {
                    x -= 2;
                    y++;
                }
                else
                {
                    x++;
                }
                // if (sudoco[ x++;x, y] == number) return false;

            }











            return true ;

        }


   


        static void Main(string[] args)
        {
            char[,] sudoco = new char[9, 9];
            //Init Sudoco massive 
            sudoco[0, 0] = '5'; sudoco[0, 1] = '3'; sudoco[0, 4] = '7';
            sudoco[1, 0] = '6'; sudoco[1, 3] = '1'; sudoco[1, 4] = '9'; sudoco[1, 5] = '5';
            sudoco[2, 1] = '9'; sudoco[2, 2] = '8'; sudoco[2, 7] = '6';
            sudoco[3, 0] = '8'; sudoco[3, 4] = '6'; sudoco[3, 8] = '3';
            sudoco[4, 0] = '4'; sudoco[4, 3] = '8'; sudoco[4, 5] = '3'; sudoco[4, 8] = '1';
            sudoco[5, 0] = '7'; sudoco[5, 4] = '2'; sudoco[5, 8] = '6';
            sudoco[6, 1] = '6'; sudoco[6, 6] = '2'; sudoco[6, 7] = '8';
            sudoco[7, 3] = '4'; sudoco[7, 4] = '1'; sudoco[7, 5] = '9'; sudoco[7, 8] = '5';
            sudoco[8, 4] = '8'; sudoco[8, 7] = '7'; sudoco[8, 8] = '9';
   

            PrintResult (sudoco);

            ValidNumber(2, 4, '0', sudoco);

            Console.WriteLine();

            PrintResult(sudoco);

        }
    }
}
