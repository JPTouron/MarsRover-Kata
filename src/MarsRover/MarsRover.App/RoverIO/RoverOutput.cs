using MarsRover.App.Location;
using System;

namespace MarsRover.App.RoverIO
{
    public class RoverOutput : IEquatable<RoverOutput>

    {
        public readonly char Direction;
        public readonly Position Position;
        public readonly bool IsNextPositionInTheDirectionBlocked;

        public RoverOutput(char direction, Position position, bool isNextPositionInTheDirectionBlocked)
        {
            Direction = direction;
            Position = position;
            IsNextPositionInTheDirectionBlocked = isNextPositionInTheDirectionBlocked;
        }

        public bool Equals(RoverOutput? other)
        {
            var isOtherNotNull = other != null;

            return isOtherNotNull &&
                   Direction == other?.Direction &&
                   Position.Equals(other.Position) &&
                   IsNextPositionInTheDirectionBlocked == other.IsNextPositionInTheDirectionBlocked;
        }

        public override string ToString()
        {
            if (IsNextPositionInTheDirectionBlocked)
                return $"0:{Direction}:{Position}";
            else
                return $"{Direction}:{Position}";
        }
    }
}