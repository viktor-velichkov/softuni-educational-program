using System;
using System.Linq;

namespace _10._RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] lair = ReadMatrix(" ");
            char[] directions = Console.ReadLine().ToCharArray();
            int[] startingPosition = FindStartingPosition(lair).Split(",").Select(int.Parse).ToArray();
            int positionRow = startingPosition[0];
            int positionCol = startingPosition[1];
            lair[positionRow, positionCol] = '.';
            bool isDead = false;
            bool won = false;
            for (int i = 0; i < directions.Length; i++)
            {
                bool positionChanged = false;
                if (directions[i] == 'L')
                {
                    if (IsValidCell(positionRow, positionCol - 1, lair))
                    {
                        positionCol--;
                        positionChanged = true;
                    }
                }
                else if (directions[i] == 'R')
                {
                    if (IsValidCell(positionRow, positionCol + 1, lair))
                    {
                        positionCol++;
                        positionChanged = true;
                    }
                }
                else if (directions[i] == 'U')
                {
                    if (IsValidCell(positionRow - 1, positionCol, lair))
                    {
                        positionRow--;
                        positionChanged = true;
                    }
                }
                else if (directions[i] == 'D')
                {
                    if (IsValidCell(positionRow + 1, positionCol, lair))
                    {
                        positionRow++;
                        positionChanged = true;
                    }
                }
                lair = BunniesMultiplier(lair);
                if (positionChanged)
                {                    
                    if (lair[positionRow, positionCol] == 'B')
                    {
                        isDead = true;
                    }
                }
                else
                {
                    won = true;
                }

                if (isDead || won)
                {
                    break;
                }

            }
            PrintMatrix(lair);
            if (isDead == true)
            {
                Console.WriteLine($"dead: {positionRow} {positionCol}");
            }
            else if (won == true)
            {
                Console.WriteLine($"won: {positionRow} {positionCol}");
            }

        }
        static public char[,] ReadMatrix(string splitter)
        {
            int[] rowsCols = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];
            char[,] matrix = new char[rows, cols];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c];
                }
            }
            return matrix;
        }
        static string FindStartingPosition(char[,] matrix)
        {
            string startingPosition = "";
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 'P')
                    {
                        startingPosition += $"{r},{c}";
                        break;
                    }
                }
            }
            return startingPosition;
        }
        static bool IsValidCell(int currRow, int currCol, char[,] matrix)
        {
            if (currRow >= 0 && currRow < matrix.GetLength(0) && currCol >= 0 && currCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        static char[,] BunniesMultiplier(char[,] matrix)
        {
            char[,] newMatrix = (char[,])matrix.Clone();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 'B')
                    {
                        if (IsValidCell(r - 1, c, matrix) && matrix[r - 1, c] != 'B')
                        {
                            newMatrix[r - 1, c] = 'B';
                        }
                        if (IsValidCell(r, c - 1, matrix) && matrix[r, c - 1] != 'B')
                        {
                            newMatrix[r, c - 1] = 'B';
                        }
                        if (IsValidCell(r + 1, c, matrix) && matrix[r + 1, c] != 'B')
                        {
                            newMatrix[r + 1, c] = 'B';
                        }
                        if (IsValidCell(r, c + 1, matrix) && matrix[r, c + 1] != 'B')
                        {
                            newMatrix[r, c + 1] = 'B';
                        }
                    }
                }
            }
            return newMatrix;
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
