namespace MarsRoverTests
{
    internal class Position
    {
        public readonly int X;

        public readonly int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position Move(Direction direction)
        {
            switch (direction.currentDirection)
            {
                default:
                case Direction.Directions.N:
                    return new Position(X, Y + 1);

                case Direction.Directions.E:
                    return new Position(X + 1, Y);

                case Direction.Directions.S:
                    return new Position(X, Y - 1);

                case Direction.Directions.W:
                    return new Position(X - 1, Y);
            }
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}