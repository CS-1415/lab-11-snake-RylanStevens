using System;
using System.Collections.Generic;


namespace Lab11SnakeGame
{
    public class Board
    {
        public int Width { get; }
        public int Height { get; }
        public Cell Apple { get; private set; }
        private List<Snake> Snakes { get; } = new List<Snake>();

        public Board(int width, int height)
        {
            Width = width;
            Height = height;

        }
        public void AddSnake(Snake snake)
        {
            Snakes.Add(snake);
        }

        public void PlaceApple()
        {
            var random = new Random();
            Apple = new Cell(random.Next(Height), random.Next(Width));

        }

        public void Render()
        {
            var buffer = new char[Height, Width];
            foreach (var snake in Snakes)
            {
                foreach (var cell in snake.Body)
                {
                    buffer[cell.Row, cell.Column] = '0';
                }
            }
            buffer[Apple.Row, Apple.Column] = 'A';
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Console.Write(buffer[row, col] == '\0' ? '.' : buffer[row, col]);
                }
                Console.WriteLine();
            }
        }
        public bool CheckCollision(Snake snake)
        {
            var head = snake.Body[snake.Body.Count - 1];
            if (head.Row < 0 || head.Row >= Height || head.Column < 0 || head.Column >= Width)
            {
                return true;
            }
            for (int i = 0; i < snake.Body.Count - 1; i++)
            {
                if (snake.Body[i].Equals(head))
                {
                    return true;
                }
            }
            return false;
        }
    }
}