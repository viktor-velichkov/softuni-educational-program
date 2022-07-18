using System;
using System.Linq;
namespace _05._SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix(" ", " ");
            int maxSum = int.MinValue;
            int[,] resultMatrix = new int[3, 3];
            
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int[,] currentMatrix = new int[3, 3];
                    
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            currentMatrix[i, j] = matrix[row + i, col + j];
                        }
                    }
                    int currentSum = SumMatrixElements(currentMatrix);
                    if (currentSum > maxSum)
                    {
                        resultMatrix = currentMatrix;
                        maxSum = currentSum;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            PrintMatrix(resultMatrix);
            
            
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
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
