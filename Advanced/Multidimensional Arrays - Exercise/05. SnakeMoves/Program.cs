using System;
using System.Linq;

namespace _05._SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] matrix = new char[rows, cols];
            string direction = "right";
            char[] input = Console.ReadLine().ToCharArray();
            int j = 0;
            int row = 0;
            int col = 0;
            for (int i = 0; i < rows * cols; i++)
            {
                matrix[row, col] = input[j];
                j++;
                if (j == input.Length)
                {
                    j = 0;
                }
                if (direction == "right")
                {
                    col++;
                    if (col == matrix.GetLength(1))
                    {
                        row++;
                        col--;
                        direction = "left";
                    }
                }
                else if (direction == "left")
                {
                    col--;
                    if (col < 0)
                    {
                        row++;
                        col++;
                        direction = "right";
                    }
                }
            }
            PrintMatrix(matrix);
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
