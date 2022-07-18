using System;
using System.Linq;

namespace _02._SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = ReadMatrix(" ");
            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentsum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if ((matrix[row, col] == matrix[row, col + 1]) && (matrix[row, col] == matrix[row + 1, col]) && (matrix[row + 1, col] == matrix[row + 1, col + 1]))
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
        static public char[,] ReadMatrix(string splitter)
        {
            int[] rowsCols = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];
            char[,] matrix = new char[rows, cols];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] rowData = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c];
                }
            }
            return matrix;
        }
    }
}
