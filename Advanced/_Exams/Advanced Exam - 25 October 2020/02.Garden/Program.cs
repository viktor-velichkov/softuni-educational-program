using System;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] garden = ReadMatrix();
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "Bloom Bloom Plow")
                {
                    int[] coordinates = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    int row = coordinates[0];
                    int col = coordinates[1];
                    if (AreCoordinatesValid(row, col, garden))
                    {
                        Bloom(row, col, garden);
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates.");
                    }
                }
                else
                {
                    break;
                }
            }
            PrintMatrix(garden);
        }
        static int[,] ReadMatrix()
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int[,] matrix = new int[rows, rows];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = 0;
                }
            }
            return matrix;
        }
        static void Bloom(int row, int col, int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                matrix[r, col]++;
            }
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                matrix[row, c]++;
            }
            matrix[row, col]--;
        }
        static bool AreCoordinatesValid(int row, int col, int[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write($"{matrix[r, c]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
