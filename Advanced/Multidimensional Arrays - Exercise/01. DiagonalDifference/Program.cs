using System;
using System.Linq;

namespace _01._DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadSquareMatrix(" ");
            int sum1 = SumPrimaryDiagonal(matrix);
            int sum2 = SumSecondaryDiagonal(matrix);
            Console.WriteLine(Math.Abs(sum1 - sum2));
        }
        static public int[,] ReadSquareMatrix(string splitterData)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
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

        static public int SumPrimaryDiagonal(int[,] matrix)
        {
            int sum = 0;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                sum += matrix[r, r];
            }
            return sum;
        }
        static public int SumSecondaryDiagonal(int[,] matrix)
        {
            int sum = 0;
            int c = 0;
            for (int r = matrix.GetLength(0) - 1; r >= 0; r--)
            {
                sum += matrix[r, c];
                c++;
            }
            return sum;
        }
    }
}
