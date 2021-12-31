namespace MarsRover.App
{
    internal class RoverOutput
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

        public override string ToString()
        {
            if (IsNextPositionInTheDirectionBlocked)
                return $"0:{Direction}:{Position}";
            else
                return $"{Direction}:{Position}";
        }
    }
}