using System;
using System.Linq;
using System.Numerics;

namespace _09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            char[,] field = ReadMatrix(size);
            int[] startingPosition = FindStartingPosition(field).Split(",").Select(int.Parse).ToArray();
            int positionRow = startingPosition[0];
            int positionCol = startingPosition[1];
            int coalCount = CountCoals(field);
            bool gameOver = false;
            for (int i = 0; i < directions.Length; i++)
            {
                bool positionChanged = false;
                if (directions[i] == "left")
                {
                    if (IsValidCell(positionRow, positionCol - 1, field))
                    {
                        positionCol--;
                        positionChanged = true;
                    }
                }
                else if (directions[i] == "right")
                {
                    if (IsValidCell(positionRow, positionCol + 1, field))
                    {
                        positionCol++;
                        positionChanged = true;
                    }
                }
                else if (directions[i] == "up")
                {
                    if (IsValidCell(positionRow - 1, positionCol, field))
                    {
                        positionRow--;
                        positionChanged = true;
                    }
                }
                else if (directions[i] == "down")
                {
                    if (IsValidCell(positionRow + 1, positionCol, field))
                    {
                        positionRow++;
                        positionChanged = true;
                    }
                }
                if (positionChanged)
                {
                    if (field[positionRow, positionCol] == 'c')
                    {
                        coalCount--;
                        field[positionRow, positionCol] = '*';
                        if (coalCount == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({positionRow}, {positionCol})");
                            gameOver = true;
                            break;
                        }
                    }
                    else if (field[positionRow, positionCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({positionRow}, {positionCol})");
                        gameOver = true;
                        break;
                    }
                }
            }
            if (!gameOver)
            {
                Console.WriteLine($"{coalCount} coals left. ({positionRow}, {positionCol})");
            }


        }
        static public char[,] ReadMatrix(int size)
        {
            char[,] matrix = new char[size, size];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c];
                }
            }
            return matrix;
        }
        static bool IsValidCell(int currRow, int currCol, char[,] matrix)
        {
            if (currRow >= 0 && currRow < matrix.GetLength(0) && currCol >= 0 && currCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        static string FindStartingPosition(char[,] matrix)
        {
            string startingPosition = "";
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 's')
                    {
                        startingPosition += $"{r},{c}";
                        break;
                    }
                }
            }
            return startingPosition;
        }

        static int CountCoals(char[,] matrix)
        {
            int counter = 0;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 'c')
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
    }
}
