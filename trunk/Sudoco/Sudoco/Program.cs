using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {



        static int[] Route  ;
        //static byte RouteIndex=0;
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
            Console.ReadLine();
        }

        static char[,] SudocuSolution(byte RouteIndex, char[,] sudoco)
        {
            // Route = x+9*y   y=mod(Route/9) 
            //Find AvailableNumbers for this cell , if null retrun back and find another path.

          

            if (RouteIndex == 7)
            {
                Console.Beep();
            }
            int y = Route[RouteIndex] / 9;
            int x = Route[RouteIndex] -9 * y;
            char[] AvailableNumbers = PossibleNumber(y, x, sudoco);

            //if not available number path is wrong ruturn step back and check another number
            if (AvailableNumbers[0] == '\0')
            {
                sudoco[y, x] = '\0';
                RouteIndex--;
                if (RouteIndex < 0)
                {
                    Console.Beep();
                    return sudoco;
                    // No Solution for this board
                }

                SudocuSolution(RouteIndex, sudoco);
            }

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

            if (RouteIndex > 8)
            {
                return sudoco;
            }

                         
             SudocuSolution(RouteIndex, sudoco);



            // return sudoco;
              
        }
          








/*
        static char[,] SudocuSolution( char[,] sudoco)
        {
            //check for end ; 
              // bool Solution = false;
              // if (EmptyCells (sudoco)==0) Solution=true;
            
            
            bool goodstep ;// good step  
            byte xline = x;
            byte yline = y;
            //find first empty cell  
               while (sudoco[yline, xline] != '\0')
               {
                  xline++;
                  if (xline > sudoco.GetLength(0))
                  {
                    xline = 0;
                    yline++;
                    if (yline > sudoco.GetLength(1)) yline = 0; 
                  }
               }
               Route[RouteIndex++] = xline + 9 * yline;
                  
            //Find AvailableNumbers for this cell , if null retrun back and find another path.

                 char [] AvailableNumbers = PossibleNumber(yline, xline, sudoco);

                 if (AvailableNumbers[0] == '\0')
                 {
                     sudoco[yline, xline] = '\0';
                     goodstep = false;
                     //Return one possition back                 
                 }
                 else goodstep = true;

                 if (goodstep == true)
                 {


                     sudoco[yline, xline] = AvailableNumbers[0];
                 }

                 else
                 {
                     //Check curent number in cell with AvailableNumbers and put next number 
                     //if not return back step and put \0 in cell.
                     byte i=0;
                     do
                     {
                         if (sudoco[yline, xline] == AvailableNumbers[i]) break;
                         if (AvailableNumbers[i] == '\0') break;

                     } while (i > 9);

                     if (i > 9) goodstep = false; // return step back 
                     else
                     {
                         sudoco[yline, xline] = AvailableNumbers[i + 1]; // Next possible number for cell
                     }
                        // Increment x 
                     x = xline++;
                     xline++;
                     if (xline > sudoco.GetLength(0))
                     {
                         xline = 0;
                         yline++;
                         if (yline > sudoco.GetLength(1)) yline = 0;
                     }
                  }

            //     SudocuSolution(y, x, sudoco);

                       

              Console.ReadKey();


           
 
             







            return sudoco;
        }

        */




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


        static void  EmptyCells(char[,] sudoco)
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


          



          //  Console.Beep();
         }



/*
        static char[,] LocateEpmtySpace(char[,] sudocoinput)
        {
            Random  datachar = new  Random();
            char rnddata = Convert.ToChar(datachar.Next(0x31,0x39));

       //
       //     for (byte i = 1; i <= 9; i++)
       //     {

       //       Console.Write(rnddata = Convert.ToChar(datachar.Next(0x31,0x39)));
       //     }
        





            do
            {


                for (byte y = 0; y < 9; y++)
                {

                    for (byte x = 0; x < 9; x++)
                    {

                        if (sudocoinput[y, x] == '\0')
                        {
                            for (char data = '1'; data <= '9'; data++)
                            {
                                rnddata = Convert.ToChar(datachar.Next(0x31,0x39));
                                if (ValidNumber(y, x, rnddata, sudocoinput))
                                {
                                    sudocoinput[y, x] = rnddata;
                                    break;
                                }
                            }
                        }

                    }

                }
                break;
            } while (EmptyCells(sudocoinput) != 0);



             return sudocoinput ;
        }
  
*/

/*
           static bool Emptyspace(byte y,byte x,char [,] sudoco)
           {
               if (sudoco[y, x] == '\0') return true;
               else return false;

           }
        */



        static void Main(string[] args)
        {

            char[,] sudoco = 
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

            


            //InitSudoco();
            PrintResult(sudoco);
            EmptyCells(sudoco);
             //SudocuSolution(0, sudoco);
            PrintResult(SudocuSolution(0, sudoco));
           // Console.Write();

            //PrintResult(LocateEpmtySpace(sudoco));
            //Console.Write(PossibleNumber (0, 2, sudoco));

           // Console.ReadKey();
            //Console.WriteLine();

            //Console.WriteLine(EmptyCells(sudoco));
            //PrintResult(LocateEpmtySpace(sudoco));
            
        }
    }
}
