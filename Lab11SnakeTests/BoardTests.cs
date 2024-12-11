

using System.Reflection;
using System.Runtime.CompilerServices;

namespace Lab11SnakeTests
{
    [Test]
    public void Board_PlacesAppleCorrectly()
    {
        var board = new Board(10, 10);
        board.PlaceApple();
        Assert.That(board.Apple.Row, Is.InRange(0, 9));
        Assert.That(board.Apple.Column, Is.InRange(0, 9));
    }
}
