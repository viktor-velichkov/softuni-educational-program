using System;
using System.Linq;

namespace BANK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static char[,] ReadMatrix()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rows, cols];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = row[c];
                }
            }
            return matrix;
        }
        static char[,] ReadSquareMatrix()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = row[c];
                }
            }
            return matrix;
        }
        static int[][] ReadJaggedMatrix()
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedMatrix = new int[rows][];
            for (int r = 0; r < jaggedMatrix.Length; r++)
            {
                int[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedMatrix[r] = row;
            }
            return jaggedMatrix;
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
        static void PrintJaggedMatrix(char[][] matrix)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                Console.WriteLine(String.Join(" ",matrix[r]));
            }
        }

        static int[] FindPosition(char[,] matrix, char symbol)
        {
            bool found = false;
            int[] position = new int[2];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r,c]==symbol)
                    {
                        position[0] = r;
                        position[1] = c;
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
            }
            return position;
        }
        static bool AreCoordinatesValid(int row, int col, char[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
