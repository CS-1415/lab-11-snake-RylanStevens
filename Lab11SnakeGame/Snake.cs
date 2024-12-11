using System;
using System.Collections.Generic;
using Lab11_SnakeGame;

namespace Lab11SnakeGame
{
    public class Snake
    {
        public string Name { get; }
        public List<Cell> Body { get; }
        public Direction CurrentDirection { get; private set; }
        private Board Board { get; }

        public Snake(string name, Board board, Cell start, Direction initialDirection)
        {
            Name = name;
            Board = board;
            CurrentDirection = initialDirection;
            Body = new List<Cell> { start };
        }

        public void ChangeDirection(ConsoleKey key)
        {
            Direction newDirection = CurrentDirection;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    newDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    newDirection = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    newDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    newDirection = Direction.Right;
                    break;
            }

            if (!IsOppositeDirection(newDirection))
            {
                CurrentDirection = newDirection;
            }
        }

        private bool IsOppositeDirection(Direction newDirection)
        {
            return (CurrentDirection == Direction.Up && newDirection == Direction.Down) ||
            (CurrentDirection == Direction.Down && newDirection == Direction.Up) ||
            (CurrentDirection == Direction.Left && newDirection == Direction.Right) ||
            (CurrentDirection == Direction.Right && newDirection == Direction.Left);
        }

        public bool Move()
        {
            var head = Body[^1];
            Cell newHead = head;

            switch (CurrentDirection)
            {
                case Direction.Up:
                    newHead = new Cell(head.Row - 1, head.Column);
                    break;
                case Direction.Down:
                    newHead = new Cell(head.Row + 1, head.Column);
                    break;
                case Direction.Left:
                    newHead = new Cell(head.Row, head.Column - 1);
                    break;
                case Direction.Right:
                    newHead = new Cell(head.Row, head.Column + 1);
                    break;
            }
            if (Board.CheckCollision(this))
            {
                return false;
            }
            Body.Add(newHead);

            if (newHead.Equals(Board.Apple))
            {
                Board.PlaceApple();
            }
            else
            {
                Body.RemoveAt(0);
            }
            return true;
        }
    }
}