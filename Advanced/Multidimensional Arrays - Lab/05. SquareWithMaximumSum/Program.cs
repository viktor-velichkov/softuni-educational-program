using System;
using System.Linq;
namespace _05._SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix(", ", ", ");
            int maxSum = int.MinValue;
            int resultRow = 0;
            int resultCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentsum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (currentsum > maxSum)
                    {
                        resultRow = row;
                        resultCol = col;
                        maxSum = currentsum;
                    }
                }
            }
            Console.WriteLine($"{matrix[resultRow, resultCol]} {matrix[resultRow, resultCol + 1]}");
            Console.WriteLine($"{matrix[resultRow + 1, resultCol]} {matrix[resultRow + 1, resultCol + 1]}");
            Console.WriteLine(maxSum);
        }
        static public int[,] ReadMatrix(string splitterSizes, string splitterData)
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
