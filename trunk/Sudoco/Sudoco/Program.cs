using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {



        static int[] Route  ;
        static  char[] Numbers = new char[10];
        
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

        static void SudocuSolution(byte RouteIndex , char [,] sudoco)
        {
            
            do
            {
                int y = Route[RouteIndex] / 9;
                int x = Route[RouteIndex] - 9 * y;
                char[] AvailableNumbers = PossibleNumber(y, x, sudoco);

                //if not available number path is wrong ruturn step back and check another number
                if (AvailableNumbers[0] == '\0')
                {
                    sudoco[y, x] = '\0';
                    RouteIndex--;
                    if (RouteIndex < 0)
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
                        sudoco[y, x] = AvailableNumbers[0];
                        RouteIndex++;
                    }
                    else
                    {
                        //locate current number in AvailebleNumbers massive
                        int i;
                        for (i = 0; i < AvailableNumbers.GetLength(0); i++)
                        {
                            if (AvailableNumbers[i] == sudoco[y, x] || AvailableNumbers[i] == '\0') break;


                        }
                        // Next number from Available
                        i++;
                        sudoco[y, x] = AvailableNumbers[i];
                        // if number is empty step back
                        if (sudoco[y, x] == 0)
                        {
                            RouteIndex--;
                        }
                        else RouteIndex++;

                    }

                }

            } while (RouteIndex < Route.GetLength(0));
      }
   
          
       static char[]  PossibleNumber (int y,int x ,char [,] sudoco)
        
        {
             byte counter=0;
             char CurrentCell;
             CurrentCell = sudoco[y, x];
             sudoco[y, x] = '\0';
            
             for (char i = '1'; i <= '9'; i++)
             {
                 if (ValidNumber(y, x, i, sudoco)) Numbers[counter++] = i;

             }
             sudoco[y, x] = CurrentCell;
              //counter++;
              Numbers[counter] = '\0';
             return Numbers; 
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
            byte EmptyCells = 0;
            for (byte y = 0; y < sudoco.GetLength(1) ; y++)
            {
                for (byte x = 0; x < sudoco.GetLength(0) ; x++)
                {

                    if (sudoco[y, x] == '\0') EmptyCells ++;  

                }               

            }
           Route = new int[EmptyCells];
             EmptyCells = 0;
            for (byte y = 0; y < sudoco.GetLength(1); y++)
            {
                for (byte x = 0; x < sudoco.GetLength(0); x++)
                {

                    if (sudoco[y, x] == '\0') Route[EmptyCells++]=x+9*y;

                }

            }
                   
         }




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
           
            
        }
    }
}
