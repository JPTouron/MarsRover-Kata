using System;

namespace MarsRover.App
{
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

        internal RoverOutput Execute(string commands)
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

            return new RoverOutput(CurrentDirectionAsChar(), currentPosition, isNextPositionInTheDirectionBlocked: false);
        }

        private char CurrentDirectionAsChar()
        {
            return currentDirection.ToString()[0];
        }

        private void moveBackwards()
        {
            switch (currentDirection)
            {
                case Direction.N:
                case Direction.S:
                    currentPosition = currentPosition.DecreaseOneStepOnYAxes();
                    break;

                case Direction.E:
                case Direction.W:
                    currentPosition = currentPosition.DecreaseOneStepOnYAxes();
                    break;
            }
        }

        private void moveForwards()
        {
            switch (currentDirection)
            {
                case Direction.N:
                case Direction.S:
                    currentPosition = currentPosition.IncreaseOneStepOnYAxes();
                    break;

                case Direction.E:
                case Direction.W:
                    currentPosition = currentPosition.IncreaseOneStepOnXAxes();
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