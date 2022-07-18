using System;

namespace _04._SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = ReadSquareMatrix();
            char symbol = char.Parse(Console.ReadLine());
            bool isThere = false;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows,cols]==symbol)
                    {
                        isThere = true;
                        Console.WriteLine($"({rows},{cols})");
                        break;
                    }
                }
                if (isThere)
                {
                    break;
                }
            }
            if (!isThere)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
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
    }
}
