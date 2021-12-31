using System;

namespace MarsRover.App
{
    internal class RoverOutput
    {
        public readonly char direction;
        public readonly Position position;
        public readonly bool isNextPositionInTheDirectionBlocked;

        public RoverOutput(char direction, Position position, bool isNextPositionInTheDirectionBlocked)
        {
            this.direction = direction;
            this.position = position;
            this.isNextPositionInTheDirectionBlocked = isNextPositionInTheDirectionBlocked;
        }

        public override string ToString()
        {
            if (isNextPositionInTheDirectionBlocked)
                return $"0:{direction}:{position}";
            else
                return $"{direction}:{position}";
        }
    }

    internal class Rover
    {
        private Direction currentDirection;
        private Position currentPosition;

        public Rover()
        {
            currentDirection = Direction.N;
            currentPosition = new Position(0, 0);
        }

        private enum Direction
        {
            N, E, S, W
        }

        internal string Execute(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'L':
                        TurnLeft();
                        break;

                    case 'R':
                        TurnRight();
                        break;

                    case 'F':
                        moveForwards();
                        break;

                    case 'B':
                        moveBackwards();
                        break;

                    default:
                        throw new ArgumentException($"Invalid command: {command}");
                }
            }

            return $"{currentDirection}:{currentPosition}";
        }

        private void moveBackwards()
        {
            switch (currentDirection)
            {
                case Direction.N:
                case Direction.S:
                    currentPosition = currentPosition.DecreaseOneStepOnYAxis();
                    break;

                case Direction.E:
                case Direction.W:
                    currentPosition = currentPosition.DecreaseOneStepOnYAxis();
                    break;
            }
        }

        private void moveForwards()
        {
            switch (currentDirection)
            {
                case Direction.N:
                case Direction.S:
                    currentPosition = currentPosition.IncreaseOneStepOnYAxis();
                    break;

                case Direction.E:
                case Direction.W:
                    currentPosition = currentPosition.IncreaseOneStepOnXAxis();
                    break;
            }
        }

        private void TurnRight()
        {
            if (currentDirection == Direction.W)
                currentDirection = Direction.N;
            else
                currentDirection++;
        }

        private void TurnLeft()
        {
            if (currentDirection == Direction.N)
                currentDirection = Direction.W;
            else
                currentDirection--;
        }
    }
}