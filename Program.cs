// Ian Relecker
// www.ianrelecker.com
// ianrelecker@gmail.com
// 
// What this program does is it prints a 8x8 grid to the screen(Console in C#) 
// of a chessboard where 8 Queens could all fit on the board.
// This takes into account that Queens can attack horozontally, vertically, and diagonally.
// Each board that it creates is made dynamically from random positions for each Queen.
// Each time the program is run it will produce a different board.
// 
// I originally wrote this in Java but have rewritten it in C#.

using System;


namespace _8Queens
{
    class Program
    {
    public static int checkOne(int[] array)
    {
            int total = 0;
            for(int i=0; i<array.Length; i++)
            {
                total += array[i];
            }
            return total;
        }

    public static int checkRC(int[,] array)
    {
        int total = 0;
        for(int i=0; i<8; i++)
        {
            for(int a=0; a<8; a++)
            {
                total += array[i,a];
            }
        }
        return total;
    }

    public static int randNumF()
    {
        Random num = new Random();
        return num.Next(0,8);
    }

    public static bool diaChecker(int x, int y, int[,] chessboardM)
    {
        bool isItThere = false;
        int i =0;
        while(x+i<=7&&y-i>=0)
        {
            if(chessboardM[y-i,x+i] == 1) 
            {
                isItThere = true;
                break;
            }
            i++;
        }
        i=0;
        while(y-i>=0&& x-i>=0)
        {
            if (chessboardM[y-i,x-i] == 1)
            {
                isItThere = true;
                break;
            }
            i++;
        }
        i=0;
        while(y+i<=7&&x+i<=7)
        {
            if(chessboardM[y+i,x+i] ==1)
            {
                isItThere = true;
                break;
            }
            i++;
        }
        i=0;
        while(x-i>=0&&y+i<=7)
        {
            if(chessboardM[y+i,x-i] == 1)
            {
                isItThere = true;
                break;
            }
            i++;
        }
        return isItThere;
    }

    public static void Main(String[] args) 
    {
        int[,] chessboard = new int[8, 8];

        while(checkRC(chessboard) < 8)
        {
            int counter = 0;
            chessboard = new int[8,8];
            int[] columnHolder = new int[8];
            int[] rowHolder = new int[8];
            while(checkRC(chessboard) < 8)
            {
                if(counter == 10000)
                {
                    break;
                }
                int testingNowX = randNumF();
                int testingNowY = randNumF();
                counter++;
                for(int i=0; i<8; i++)
                {
                    for(int a=0; a<8; a++)
                    {
                        rowHolder[a] = chessboard[testingNowY,a];
                    }
                if(checkOne(rowHolder) !=1 && columnHolder[testingNowX] != 1 && !diaChecker(testingNowX, testingNowY, chessboard))
                {
                    chessboard[testingNowY,testingNowX] = 1;
                    columnHolder[testingNowX] = 1;
                }
                }
            }
        }
        Console.WriteLine("Complete! Found spot for all 8 queens!");
        for(int i = 0; i <8; i++)
        {
            for(int a=0; a<8; a++)
            {
                Console.Write(chessboard[i,a]);
            }
            Console.WriteLine();
        }
    }

    }
}
