namespace Lab11SnakeTests
{
    public class SnakeTests
    {
        [Test]
        public void Snake_ChangesDirectionCorrectly()
        {
            var board = new Board(10, 10);
            var snake = new Snake("Player1", board, new Cell(5, 5), Direction.Right);

            snake.ChangeDirection(ConsoleKey.UpArrow);
            Assert.That(snake.CurrentDirection, Is.EqualTo(Direction.Up));
        }

        [Test]
        public void Snake_MovesSuccessfully()
        {
            var board = new Board(10, 10);
            var snake = new Snake("Player1", board, new Cell(5, 5), Direction.Right);

            // Initial body should contain one cell at (5,5)
            Assert.That(snake.Body.Count, Is.EqualTo(1));
            Assert.That(snake.Body[0], Is.EqualTo(new Cell(5, 5)));

            // Move snake right
            bool moveResult = snake.Move();

            // Snake should move to the right, new head at (5,6)
            Assert.That(moveResult, Is.True);
            Assert.That(snake.Body.Count, Is.EqualTo(2));
            Assert.That(snake.Body[0], Is.EqualTo(new Cell(5, 6)));  // New head
            Assert.That(snake.Body[1], Is.EqualTo(new Cell(5, 5)));  // Tail, should remain at the initial position

            // Move snake right again
            moveResult = snake.Move();
            Assert.That(moveResult, Is.True);
            Assert.That(snake.Body[0], Is.EqualTo(new Cell(5, 7)));  // New head
            Assert.That(snake.Body[1], Is.EqualTo(new Cell(5, 6)));
        }

        [Test]
        public void Snake_HitsWallAndGameOver()
        {
            var board = new Board(10, 10);
            var snake = new Snake("Player1", board, new Cell(0, 0), Direction.Up);

            // Attempt to move the snake up, which should hit the top wall
            bool moveResult = snake.Move();
            Assert.That(moveResult, Is.False); // Snake should hit the wall
        }

        [Test]
        public void Snake_EatsAppleAndGrows()
        {
            var board = new Board(10, 10);
            var snake = new Snake("Player1", board, new Cell(5, 5), Direction.Right);
            
            // Place apple at (5, 6)
            board.PlaceApple();
            board.Apple = new Cell(5, 6);

            // Move snake towards the apple
            bool moveResult = snake.Move();
            Assert.That(moveResult, Is.True); // Snake moves to (5, 6), eats the apple

            // Snake should grow in length
            Assert.That(snake.Body.Count, Is.EqualTo(2));
            Assert.That(snake.Body[0], Is.EqualTo(new Cell(5, 6)));  // New head at apple's position
        }

        [Test]
        public void Snake_DoesNotMoveIntoItself()
        {
            var board = new Board(10, 10);
            var snake = new Snake("Player1", board, new Cell(5, 5), Direction.Right);

            // Move snake to create a body of length 3
            snake.Move(); // (5,6)
            snake.Move(); // (5,7)

            // Change direction to left
            snake.ChangeDirection(ConsoleKey.LeftArrow);
            
            // Move snake to collide with its own body
            bool moveResult = snake.Move();
            Assert.That(moveResult, Is.False); // Snake should collide with itself
        }
    }
}
