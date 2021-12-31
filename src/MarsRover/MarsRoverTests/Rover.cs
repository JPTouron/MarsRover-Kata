using System;

namespace MarsRover.App
{


    internal class Rover
    {
        private enum Direction
        {
            N, E, S, W
        }
        Direction currentDirection;
        public Rover()
        {
            currentDirection = Direction.N;
        }
        internal string Execute(string commands)
        {
            var output = "";

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


                    default:
                        throw new ArgumentException($"Invalid command: {command}");
                }
            }

            output = $"{currentDirection}"; 

            return output;
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