using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {



        static int[] route  ;
        static readonly char[] numbers = new char[10];
        static char[] availableNumbers;
        
        static void PrintResult(char [,] sudoco)
        {
            for (byte y = 0; y < sudoco.GetLength (1); y++)
            {
                for (byte x = 0; x < sudoco.GetLength(0); x++)
                {
                    Console.Write(sudoco[y, x]);

                }
                Console.WriteLine();
            }

            //Pause 
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        static void SudocuSolution(byte routeIndex , char [,] sudoco)
        {
            
            do
            {
                int y = route[routeIndex] / 9;
                int x = route[routeIndex] - 9 * y;
                 availableNumbers = PossibleNumber(y, x, sudoco);

                //if not available number path is wrong ruturn step back and check another number
                if (availableNumbers[0] == '\0')
                {
                    sudoco[y, x] = '\0';
                    routeIndex--;
                    if (routeIndex < 0)
                    {
                        Console.Beep();
                        return;
                        // No Solution for this board
                    }

                    //SudocuSolution(RouteIndex);
                }
                else
                {
                    //if cell is empty set first number else set next number untill \0 and then step back,put \0 to cell 

                    if (sudoco[y, x] == '\0')
                    {
                        sudoco[y, x] = availableNumbers[0];
                        routeIndex++;
                    }
                    else
                    {
                        //locate current number in AvailebleNumbers massive
                        int i;
                        for (i = 0; i < availableNumbers.GetLength(0); i++)
                        {
                            if (availableNumbers[i] == sudoco[y, x] || availableNumbers[i] == '\0') break;


                        }
                        // Next number from Available
                        i++;
                        sudoco[y, x] = availableNumbers[i];
                        // if number is empty step back
                        if (sudoco[y, x] == 0)
                        {
                            routeIndex--;
                        }
                        else routeIndex++;

                    }

                }

            } while (routeIndex < route.GetLength(0));
      }
   
          
       static char[]  PossibleNumber (int y,int x ,char [,] sudoco)
        
        {
             byte counter=0;
             char currentCell;
             currentCell = sudoco[y, x];
             sudoco[y, x] = '\0';
            
             for (char i = '1'; i <= '9'; i++)
             {
                 if (ValidNumber(y, x, i, sudoco)) numbers[counter++] = i;

             }
             sudoco[y, x] = currentCell;
              //counter++;
              numbers[counter] = '\0';
             return numbers; 
        }

        static bool ValidNumber(int y, int x, char number, char[,] sudoco)
        {                      
          //Check x
            for (byte i = 0; i < 9; i++)
            {
              if (number == sudoco[y,i]) return false;
             // sudoco[y, i] = 'x';
            }
          //Check Y
            for (byte i = 0; i < 9; i++)
            {
                if (number == sudoco[i, x]) return false;
               // sudoco[i, x] = 'y';
            }
         // Check Cube
            
            for (byte i = 0; i < 9; i++)
            {                         
                //sudoco[y,x] = 'c';
                if (sudoco[y,x] == number) return false;
                if (x == 2 || x == 5 || x == 8)
                {
                    x -= 2;
                    if (y == 2 || y == 5 || y == 8) y -= 2;
                    else  y++;                
                }
                else x++;                             
            }
           return true ;
         }


        static void  EmptyCells(char [,] sudoco)
        {
            byte emptyCells = 0;
            for (byte y = 0; y < sudoco.GetLength(1) ; y++)
            {
                for (byte x = 0; x < sudoco.GetLength(0) ; x++)
                {

                    if (sudoco[y, x] == '\0') emptyCells ++;  

                }               

            }
           route = new int[emptyCells];
             emptyCells = 0;
            for (byte y = 0; y < sudoco.GetLength(1); y++)
            {
                for (byte x = 0; x < sudoco.GetLength(0); x++)
                {

                    if (sudoco[y, x] == '\0') route[emptyCells++]=x+9*y;

                }

            }
                   
         }

  /*
        static void PrintResultAvailableNumbers ()
        {
            for (int i = 0; i < availableNumbers.GetLength(0); i++)
            {
                Console.WriteLine(availableNumbers[i]);

            }







        }
 */

        static void Main(string[] args)


        {

            char[,] sudoco1 = 
            //Init Sudoco massive 
            { {'5','3','\0','\0','7','\0','\0','\0','\0'},
              {'6','\0','\0','1','9','5','\0','\0','\0'},
              {'\0','9','8','\0','\0','\0','\0','6','\0'},
              {'8','\0','\0','\0','6','\0','\0','\0','3'},
              {'4','\0','\0','8','\0','3','\0','\0','1'},
              {'7','\0','\0','\0','2','\0','\0','\0','6'},
              {'\0','6','\0','\0','\0','\0','2','8','\0'},
              {'\0','\0','\0','4','1','9','\0','\0','5'},
              {'\0','\0','\0','\0','8','\0','\0','7','9'}
            };

            char[,] sudoco = 
            //Init Sudoco massive 
            { {'\0','\0','\0','2','\0','\0','\0','6','3'},
              {'3','\0','\0','\0','\0','5','4','\0','1'},
              {'\0','\0','1','\0','\0','3','9','8','\0'},
              {'\0','\0','\0','\0','\0','\0','\0','9','\0'},
              {'\0','\0','\0','5','3','8','\0','\0','\0'},
              {'\0','3','\0','\0','\0','\0','\0','\0','\0'},
              {'\0','2','6','3','\0','\0','5','\0','\0'},
              {'5','\0','3','7','\0','\0','\0','\0','8'},
              {'4','7','\0','\0','\0','1','\0','\0','\0'}
            };
         


            PrintResult(sudoco);
            EmptyCells(sudoco);
             SudocuSolution(0,sudoco);
            PrintResult(sudoco);
           //PrintResultAvailableNumbers();

           
            
        }
    }
}
