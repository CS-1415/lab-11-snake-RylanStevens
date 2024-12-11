using System;

namespace Lab11SnakeGame
{
    public static class ConsoleHelper
    {
        public static void RenderTextAt(int row, int col, string text)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(text);
        }
    }
}