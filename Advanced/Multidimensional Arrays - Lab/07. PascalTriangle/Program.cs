using System;

namespace _07._PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long rows = long.Parse(Console.ReadLine());
            long[][] matrix = new long[rows][];
            for (long r = 0; r < matrix.Length; r++)
            {
                matrix[r] = new long[r+1];
                matrix[r][0] = 1;
                matrix[r][matrix[r].Length - 1] = 1;
                if (r>1)
                {
                    for (long c = 1; c <matrix[r].Length-1; c++)
                    {
                        matrix[r][c] = matrix[r - 1][c] + matrix[r - 1][c - 1];
                    }
                }
            }
            foreach (var row in matrix)
            {
                Console.WriteLine(String.Join(" ",row));
            }
        }
    }
}
