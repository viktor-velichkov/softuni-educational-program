using System;
using System.Linq;

namespace _2._SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix(", ", " ");
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                int sum = 0;
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    sum += matrix[rows, cols];
                }
                Console.WriteLine(sum);
            }
        }
        static public int[,] ReadMatrix(string splitterSizes,string splitterData)
        {
            int[] rowsCols = Console.ReadLine().Split(splitterSizes, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];
            int[,] matrix = new int[rows, cols];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] rowData = Console.ReadLine().Split(splitterData, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c];
                }
            }
            return matrix;
        }
    }
}
