using System;
using System.Linq;

namespace _01._SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix(", ");
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(SumMatrixElements(matrix));
        }

        static public int[,] ReadMatrix(string splitter)
        {
            int[] rowsCols = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];
            int[,] matrix = new int[rows, cols];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] rowData = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r,c] = rowData[c];
                }
            }
            return matrix;
        }

        static int SumMatrixElements(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
        }
    }
}
