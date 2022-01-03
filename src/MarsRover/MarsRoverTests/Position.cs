using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverTests
{
    internal class MoveResult
    {
        internal readonly Position position;
        internal readonly bool obstacleFound;

        public MoveResult(Position position, bool obstacleFound)
        {
            this.position = position;
            this.obstacleFound = obstacleFound;
        }
    }

    internal class Position : IEquatable<Position>
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

        public bool Equals(Position? other)
        {
            return other != null && X == other.X && Y == other.Y;
        }

        public MoveResult Move(Direction direction, IReadOnlyCollection<Position> obstacles)
        {
            var newX = X;
            var newY = Y;

            switch (direction.currentDirection)
            {
                case Direction.Directions.N:
                    newY = (Y + 1) % (gridMaxHeight + 1);
                    break;

                case Direction.Directions.S:
                    newY = Y > 0 ? Y - 1 : gridMaxHeight - 1;
                    break;

                case Direction.Directions.E:
                    newX = (X + 1) % (gridMaxWidth + 1);
                    break;

                case Direction.Directions.W:
                    newX = X > 0 ? X - 1 : gridMaxWidth - 1;
                    break;
            }

            return MoveToNewPositionIfClear(obstacles, newX, newY);
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }

        private MoveResult MoveToNewPositionIfClear(IReadOnlyCollection<Position> obstacles, int newX, int newY)
        {
            Position newPosition;
            var obstacleFound = obstacles.Any(p => p.X == newX && p.Y == newY);

            if (obstacleFound)
                newPosition = this;
            else
                newPosition = new Position(newX, newY);

            return new MoveResult(newPosition, obstacleFound);
        }
    }
}