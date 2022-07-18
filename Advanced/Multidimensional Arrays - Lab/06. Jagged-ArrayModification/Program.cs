using System;
using System.Linq;

namespace _06._Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = ReadJaggedMatrix(" ");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    PrintMatrix(matrix);
                    break;
                }
                else
                {
                    bool isValid = true;
                    string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string action = command[0];
                    int rowCoord = int.Parse(command[1]);
                    int colCoord = int.Parse(command[2]);
                    int value = int.Parse(command[3]);
                    if ((rowCoord < 0 || rowCoord > matrix.Length - 1) || (colCoord < 0 || colCoord > matrix[rowCoord].Length - 1))
                    {
                        isValid = false;
                    }

                    if (isValid)
                    {
                        switch (action)
                        {
                            case "Add":
                                matrix[rowCoord][colCoord] += value;
                                break;
                            case "Subtract":
                                matrix[rowCoord][colCoord] -= value;
                                break;
                            default:
                                Console.WriteLine("Wrong Command");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }
        }
        static public int[][] ReadJaggedMatrix(string splitterData)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];
            for (int r = 0; r < matrix.Length; r++)
            {
                int[] rowData = Console.ReadLine().Split(splitterData, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[r] = new int[rowData.Length];
                for (int c = 0; c < rowData.Length; c++)
                {
                    matrix[r][c] = rowData[c];
                }
            }

            return matrix;
        }

        static public void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
