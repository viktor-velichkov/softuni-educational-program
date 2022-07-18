using System;
using System.Linq;

namespace _06._JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            float[][] matrix = ReadJaggedMatrix(" ");
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (int k = i; k < i+2; k++)
                    {
                        for (int j = 0; j < matrix[k].Length; j++)
                        {
                            matrix[k][j] *= 2;
                        }
                    }
                }
                else
                {
                    for (int k = i; k < i + 2; k++)
                    {
                        for (int j = 0; j < matrix[k].Length; j++)
                        {
                            matrix[k][j] /= 2;
                        }
                    }
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
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
                    float value = int.Parse(command[3]);
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
                    
                }
            }
        }
        static public float[][] ReadJaggedMatrix(string splitterData)
        {
            int rows = int.Parse(Console.ReadLine());
            float[][] matrix = new float[rows][];
            for (int r = 0; r < matrix.Length; r++)
            {
                int[] rowData = Console.ReadLine().Split(splitterData, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[r] = new float[rowData.Length];
                for (int c = 0; c < rowData.Length; c++)
                {
                    matrix[r][c] = rowData[c];
                }
            }

            return matrix;
        }

        static public void PrintMatrix(float[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }

}
