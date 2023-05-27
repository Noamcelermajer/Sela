using System;
class Program
{
    //program that fill 5x5 matrix (2d int array) with random numbers and fill diagonal with 0
    static void Main(string[] args)
    {
        int[,] matrix = new int[5, 5];
        Random rnd = new Random();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrix[i, j] = rnd.Next(0, 10);
            }
        }
        //fill both diagonals with 0
        for (int i = 0; i < 5; i++)
        {
            //left to right
            matrix[i, i] = 0;
            //right to left
            matrix[i, 4 - i] = 0;
        }
        
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

}