using System;

namespace _8Queens
{
    class Program
    {
public static int checkOne(int[] array){
        int total = 0;
        for(int i=0; i<array.Length; i++){
            total += array[i];
        }
        return total;
    }
    public static int checkRC(int[][] array){
        int total = 0;
        for(int i=0; i<array.Length; i++){
            for(int a=0; a<array.Length; a++){
                total += array[i][a];
            }
        }
        return total;
    }
    public static int randNumF(){
        return (int) Math.round(Math.random()* 7);
    }
    public static void Main(string[] args){
        Console.WriteLine(randNumF());
    }
    }
}
