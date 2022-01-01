using System;

namespace MarsRover.App
{
    internal class Rover
    {
        private readonly Grid grid;

        public Rover(Grid grid)
        {
            this.grid = grid;
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
                        grid.TurnLeft();
                        break;

                    case 'R':
                        grid.TurnRight();
                        break;

                    case 'F':
                        grid.MoveForwards();
                        break;

                    case 'B':
                        grid.MoveBackwards();
                        break;

                    default:
                        throw new ArgumentException($"Invalid command: {command}");
                }
            }

            return new RoverOutput(CurrentDirectionAsChar(), grid.CurrentPosition, isNextPositionInTheDirectionBlocked: false);
        }

        private char CurrentDirectionAsChar()
        {
            return grid.CurrentDirection.ToString()[0];
        }
    }
}