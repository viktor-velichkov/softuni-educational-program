using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] field = ReadSquareMatrix();
            int[] snakePosition = FindPosition(field, 'S');
            Snake snake = new Snake(snakePosition);
            bool gameOver = false;
            int foodCount = 0;
            while (gameOver == false)
            {
                int[] currentPosition = snake.Position;
                string moveDirection = Console.ReadLine();
                if (snake.Move(field, moveDirection))
                {
                    if (field[snake.Row, snake.Column] == '*')
                    {
                        foodCount++;
                        if (foodCount == 10)
                        {
                            gameOver = true;
                        }
                    }
                    else if (field[snake.Row, snake.Column] == 'B')
                    {
                        field[snake.Row, snake.Column] = '.';
                        snake.Position = FindPosition(field, 'B');
                    }
                    field[snake.Row, snake.Column] = 'S';
                }
                else
                {
                    gameOver = true;
                }
            }
            if (foodCount == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else
            {
                Console.WriteLine("Game over!");
            }
            Console.WriteLine($"Food eaten: {foodCount}");
            PrintMatrix(field);
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
        static int[] FindPosition(char[,] matrix, char symbol)
        {
            bool found = false;
            int[] position = new int[2];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == symbol)
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
        public class Snake
        {
            public Snake(int[] position)
            {
                this.Position = position;
            }
            public int[] Position { get; set; }
            public int Row
            {
                get
                {
                    return this.Position[0];
                }
                set
                {
                    this.Position[0] = value;
                }
            }
            public int Column
            {
                get
                {
                    return this.Position[1];
                }
                set
                {
                    this.Position[1] = value;
                }
            }
            public bool Move(char[,] matrix, string moveDirection)
            {
                bool isMoving = false;
                matrix[this.Row, this.Column] = '.';
                switch (moveDirection)
                {
                    case "down":
                        if (AreCoordinatesValid(this.Row + 1, this.Column, matrix))
                        {
                            this.Row++;
                            isMoving = true;
                        }
                        break;
                    case "up":
                        if (AreCoordinatesValid(this.Row - 1, this.Column, matrix))
                        {
                            this.Row--;
                            isMoving = true;
                        }

                        break;
                    case "right":
                        if (AreCoordinatesValid(this.Row, this.Column + 1, matrix))
                        {
                            this.Column++;
                            isMoving = true;
                        }

                        break;
                    case "left":
                        if (AreCoordinatesValid(this.Row, this.Column - 1, matrix))
                        {
                            this.Column--;
                            isMoving = true;
                        }
                        break;
                    default:
                        break;
                }
                return isMoving;
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
}
