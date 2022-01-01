using System;

namespace MarsRover.App.Location
{
    internal class Position : IEquatable<Position>
    {
        public readonly int X;
        public readonly int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int NextXCoordinate => X + 1;

        public int NextYCoordinate => Y + 1;

        public int PreviousXCoordinate => X - 1;

        public int PreviousYCoordinate => Y - 1;

        public override string ToString()
        {
            return $"{X},{Y}";
        }

        public Position IncreaseOneStepOnYAxes()
        {
            return new Position(X, Y + 1);
        }

        public Position IncreaseOneStepOnXAxes()
        {
            return new Position(X + 1, Y);
        }

        public Position DecreaseOneStepOnYAxes()
        {
            return new Position(X, Y - 1);
        }

        public Position DecreaseOneStepOnXAxes()
        {
            return new Position(X - 1, Y);
        }

        public bool Equals(Position? other)
        {
            var isOtherNotNull = other != null;

            return isOtherNotNull && X == other?.X && Y == other.Y;
        }
    }
}