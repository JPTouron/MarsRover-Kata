using MarsRover.App.Location;
using MarsRover.App.RoverIO;
using System;
using System.Collections.Generic;

namespace MarsRover.App
{
    public class Rover
    {
        private readonly Grid grid;

        public Rover(Grid grid)
        {
            this.grid = grid;
        }

        public RoverOutput Execute(string commands)
        {
            var isNextPositionInTheDirectionBlocked = false;
            var commandsToProcess = new Queue<char>(commands);

            while (isNextPositionInTheDirectionBlocked == false && commandsToProcess.Count > 0)
            {
                var command = commandsToProcess.Dequeue();

                switch (command)
                {
                    case 'L':
                        grid.TurnLeft();
                        break;

                    case 'R':
                        grid.TurnRight();
                        break;

                    case 'F':
                        isNextPositionInTheDirectionBlocked = grid.MoveForwards();
                        break;

                    case 'B':
                        isNextPositionInTheDirectionBlocked = grid.MoveBackwards();
                        break;

                }
            }

            return new RoverOutput(CurrentDirectionAsChar(), grid.CurrentPosition, isNextPositionInTheDirectionBlocked);
        }

        private char CurrentDirectionAsChar()
        {
            return grid.CurrentDirection.ToString()[0];
        }
    }
}