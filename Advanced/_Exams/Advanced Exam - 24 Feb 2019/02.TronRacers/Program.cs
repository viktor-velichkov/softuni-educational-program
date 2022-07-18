using System;
using System.Runtime.CompilerServices;

namespace _02.TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            for (int r = 0; r < field.GetLength(0); r++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int c = 0; c < rowData.Length; c++)
                {
                    field[r, c] = rowData[c];
                }
            }
            Player firstPlayer = new Player();
            firstPlayer.SetInitialPosition(field, 'f');
            Player secondPlayer = new Player();
            secondPlayer.SetInitialPosition(field, 's');
            bool gameOver = false;
            while (gameOver == false)
            {
                string[] moves = Console.ReadLine().Split();
                string firstPlayerDirection = moves[0];
                firstPlayer.Move(firstPlayerDirection, field);
                char firstPlayerNewPos = field[firstPlayer.Position[0], firstPlayer.Position[1]];
                if (firstPlayerNewPos == '*')
                {
                    field[firstPlayer.Position[0], firstPlayer.Position[1]] = 'f';
                }
                else if (firstPlayerNewPos == 's')
                {
                    field[firstPlayer.Position[0], firstPlayer.Position[1]] = 'x';
                    firstPlayer.isAlive = false;
                    gameOver = true;
                    continue;
                }
                string secondPlayerDirection = moves[1];
                secondPlayer.Move(secondPlayerDirection, field);
                char secondPlayerNewPos = field[secondPlayer.Position[0], secondPlayer.Position[1]];
                if (secondPlayerNewPos == '*')
                {
                    field[secondPlayer.Position[0], secondPlayer.Position[1]] = 's';
                }
                else if (secondPlayerNewPos == 'f')
                {
                    field[secondPlayer.Position[0], secondPlayer.Position[1]] = 'x';
                    secondPlayer.isAlive = false;
                    gameOver = true;
                    continue;
                }
            }
            PrintMatrix(field);


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


        class Player
        {
            public bool isAlive;
            public int[] Position { get; set; }
            public void Move(string direction, char[,] matrix)
            {
                switch (direction)
                {
                    case "down":
                        if (this.Position[0] + 1 < matrix.GetLength(0))
                        {
                            this.Position[0]++;
                        }
                        else
                        {
                            this.Position[0] = 0;
                        }
                        break;
                    case "up":
                        if (this.Position[0] - 1 >= 0)
                        {
                            this.Position[0]--;
                        }
                        else
                        {
                            this.Position[0] = matrix.GetLength(0) - 1;
                        }
                        break;
                    case "right":
                        if (this.Position[1] + 1 < matrix.GetLength(1))
                        {
                            this.Position[1]++;
                        }
                        else
                        {
                            this.Position[1] = 0;
                        }
                        break;
                    case "left":
                        if (this.Position[1] - 1 >= 0)
                        {
                            this.Position[1]--;
                        }
                        else
                        {
                            this.Position[1] = matrix.GetLength(1) - 1;
                        }
                        break;
                    default:
                        break;
                }

            }
            public void SetInitialPosition(char[,] matrix, char playerIndicator)
            {
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        if (matrix[r, c] == playerIndicator)
                        {
                            this.Position = new int[2] { r, c };
                        }
                    }
                }
            }
        }

    }

}
