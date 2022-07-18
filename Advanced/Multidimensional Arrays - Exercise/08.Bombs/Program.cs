using System;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix(" ");
            string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int aliveCells = 0;
            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] currentBombCoordinates = coordinates[i].Split(",").Select(int.Parse).ToArray();
                int currentBombRow = currentBombCoordinates[0];
                int currentBombCol = currentBombCoordinates[1];
                int value = matrix[currentBombRow, currentBombCol];
                if (value > 0)
                {
                    for (int r = currentBombRow - 1; r <= currentBombRow + 1; r++)
                    {
                        for (int c = currentBombCol - 1; c <= currentBombCol + 1; c++)
                        {
                            if (IsValidCell(r, c, matrix) && matrix[r, c] > 0)
                            {
                                matrix[r, c] -= value;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"Alive cells: {CountPositiveMatrixElements(matrix)}");
            Console.WriteLine($"Sum: {SumPositiveMatrixElements(matrix)}");
            PrintMatrix(matrix);
        }
        static public int[,] ReadMatrix(string splitter)
        {
            int[] rowsCols = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rows;
            int[,] matrix = new int[rows, cols];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] rowData = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c];
                }
            }
            return matrix;
        }
        static bool IsValidCell(int currRow, int currCol, int[,] matrix)
        {
            if (currRow >= 0 && currRow < matrix.GetLength(0) && currCol >= 0 && currCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int SumPositiveMatrixElements(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }
            }
            return sum;
        }
        static int CountPositiveMatrixElements(int[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
