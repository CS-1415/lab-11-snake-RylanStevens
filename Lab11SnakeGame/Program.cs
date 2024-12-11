using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab11_SnakeGame{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Snake Game");
            var board = new Board(20, 20);
            var snake = new Snake("Player1", board, new Cell(10, 10), Direction.Right);
            board.AddSnake(snake);

            board.PlaceApple();

            while(true)
            {
                Console.Clear();
                board.Render();

                var key1 = Console.ReadKey(intercept: true).Key;
                player1.ChangeDirection(key1);

                var key2 = Console.ReadKey(intercept: true).Key;
                player2.ChangeDirection(key2);


                if (!player1.Move() || !player2.Move())
                {
                    Console.WriteLine("Game over you hit a wall or yourself");
                    break;
                }
            }
        }
    }
}