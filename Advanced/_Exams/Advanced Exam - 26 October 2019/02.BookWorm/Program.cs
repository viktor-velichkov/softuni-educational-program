using System;
using System.Linq;
using System.Text;

namespace _02.BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder(Console.ReadLine());
            char[,] field = ReadSquareMatrix();
            int playerRow = 0;
            int playerCol = 0;

            for (int r = 0; r < field.GetLength(0); r++)
            {
                bool found = false;
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    if (field[r, c] == 'P')
                    {
                        playerRow = r;
                        playerCol = c;
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "end")
                {
                    bool positionChanged = false;
                    switch (input)
                    {
                        case "down":
                            if (AreCoordinatesValid(playerRow + 1, playerCol, field))
                            {
                                field[playerRow, playerCol] = '-';
                                playerRow++;
                                positionChanged = true;
                            }
                            break;
                        case "up":
                            if (AreCoordinatesValid(playerRow - 1, playerCol, field))
                            {
                                field[playerRow, playerCol] = '-';
                                playerRow--;
                                positionChanged = true;
                            }
                            break;
                        case "right":
                            if (AreCoordinatesValid(playerRow, playerCol + 1, field))
                            {
                                field[playerRow, playerCol] = '-';
                                playerCol++;
                                positionChanged = true;
                            }
                            break;
                        case "left":
                            if (AreCoordinatesValid(playerRow, playerCol - 1, field))
                            {
                                field[playerRow, playerCol] = '-';
                                playerCol--;
                                positionChanged = true;
                            }
                            break;
                        default:
                            break;
                    }
                    if (!positionChanged)
                    {
                        if (result.Length > 0)
                        {
                            result.Remove(result.Length - 1, 1);
                        }
                    }
                    else
                    {
                        char charAtNewPos = field[playerRow, playerCol];
                        if (char.IsLetter(charAtNewPos))
                        {
                            result.Append(charAtNewPos);
                        }
                        field[playerRow, playerCol] = 'P';
                    }
                }
                else
                {
                    Console.WriteLine(result.ToString().Trim());
                    PrintField(field);
                    break;
                }
            }
        }
        static public char[,] ReadSquareMatrix()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
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
        static bool AreCoordinatesValid(int currRow, int currCol, char[,] matrix)
        {
            bool valid = false;
            if (currRow >= 0 && currRow < matrix.GetLength(0) && currCol >= 0 && currCol < matrix.GetLength(1))
            {
                valid = true;
            }
            return valid;
        }
        static void PrintField(char[,] matrix)
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
    }
}
