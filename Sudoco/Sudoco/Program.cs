﻿using System;
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


        static char[]  PossibleNumber (byte y,byte x ,char [,] sudoco)
        
        {
             byte counter=0;
             char [] Numbers= new char[10] ;
             for (char i = '1'; i <= '9'; i++)
             {
                 if (ValidNumber(y, x, i, sudoco)) Numbers[counter++] = i;

             }
             return Numbers; 
        }

        static bool ValidNumber(byte y, byte x, char number, char[,] sudoco)
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


        static byte EmptyCells(char[,] sudoco)
        {
            byte EmptyCells = 0;
            for (byte y = 0; y < sudoco.GetLength(1) ; y++)
            {
                for (byte x = 0; x < sudoco.GetLength(0) ; x++)
                {

                    if (sudoco[y, x] == '\0') EmptyCells++;  

                }               

            }

            return EmptyCells;
        }




        static char[,] LocateEpmtySpace(char[,] sudocoinput)
        {
            Random  datachar = new  Random();
            char rnddata = Convert.ToChar(datachar.Next(0x31,0x39));
       /*
            for (byte i = 1; i <= 9; i++)
            {

              Console.Write(rnddata = Convert.ToChar(datachar.Next(0x31,0x39)));
            }
            */





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
  


           static bool Emptyspace(byte y,byte x,char [,] sudoco)
           {
               if (sudoco[y, x] == '\0') return true;
               else return false;

           }




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
            PrintResult (sudoco);
            //ValidNumber(2, 6, '0', sudoco)
            Console.WriteLine(EmptyCells(sudoco));
            Console.WriteLine();
            PrintResult(LocateEpmtySpace(sudoco));
            Console.Write(PossibleNumber (0, 2, sudoco));

            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine(EmptyCells(sudoco));
            PrintResult(LocateEpmtySpace(sudoco));
            
        }
    }
}
