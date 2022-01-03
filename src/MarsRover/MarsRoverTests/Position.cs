namespace MarsRoverTests
{
    internal class Position
    {
        public readonly int X;

        public readonly int Y;

        private int gridMaxWidth;

        private int gridMaxHeight;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
            gridMaxWidth = 10;
            gridMaxHeight = 10;
        }

        public Position Move(Direction direction)
        {
            var newX = X;
            var newY = Y;

            switch (direction.currentDirection)
            {
                case Direction.Directions.N:
                    newY = (Y + 1) % (gridMaxHeight + 1);
                    break;

                case Direction.Directions.S:
                    newY = (Y - 1) % (gridMaxHeight - 1);
                    break;

                case Direction.Directions.E:
                    newX = (X + 1) % (gridMaxWidth + 1);
                    break;

                case Direction.Directions.W:
                    newX = (X - 1) % (gridMaxWidth - 1);
                    break;
            }

            return new Position(newX, newY);
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}