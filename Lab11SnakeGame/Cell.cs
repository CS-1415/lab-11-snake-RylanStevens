using System.Diagnostics.CodeAnalysis;

namespace Lab11_SnakeGame
{
    public struct Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object obj)
        {
            return obj is Cell cell && Row == cell.Row && Column == cell.Column;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }
    }
}
