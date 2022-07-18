using System;
using System.Linq;

namespace _04._MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matrix = ReadMatrix(" ");
            while (true)
            {
                bool isValid = true;
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                else
                {
                    string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (command[0] == "swap" && command.Length == 5)
                    {
                        string swapper = "0";
                        int row1 = int.Parse(command[1]);
                        int col1 = int.Parse(command[2]);
                        int row2 = int.Parse(command[3]);
                        int col2 = int.Parse(command[4]);
                        if ((row1 < 0 || row1 >= matrix.GetLength(0)) || (col1 < 0 || col1 >= matrix.GetLength(1))
                            || (row2 < 0 || row2 >= matrix.GetLength(0)) || (col2 < 0 || col2 >= matrix.GetLength(1)))
                        {
                            isValid = false;
                            Console.WriteLine("Invalid input!");
                            continue;
                        }
                        else
                        {
                            swapper = matrix[row1, col1];
                            matrix[row1, col1] = matrix[row2, col2];
                            matrix[row2, col2] = swapper;
                        }
                    }
                    else
                    {
                        isValid = false;
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    if (isValid == true)
                    {
                        PrintMatrix(matrix);
                    }
                }
            }
        }
        static public string[,] ReadMatrix(string splitter)
        {
            int[] rowsCols = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];
            string[,] matrix = new string[rows, cols];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string[] rowData = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowData[c];
                }
            }
            return matrix;
        }

        static void PrintMatrix(string[,] matrix)
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
    }
}
