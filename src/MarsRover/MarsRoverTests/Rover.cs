using System.Collections.Generic;

namespace MarsRoverTests
{
    internal class Rover
    {
        private readonly IReadOnlyCollection<Position> obstacles;
        private Direction direction;
        private Position position;

        public Rover(IReadOnlyCollection<Position>? obstacles = null)
        {
            direction = new Direction();
            position = new Position(0, 0);
            this.obstacles = obstacles ?? new List<Position>();
        }

        internal string Execute(string commands)
        {
            var obstacleIndicator = "";
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'R':
                        direction.TurnRight();
                        obstacleIndicator = "";
                        break;

                    case 'L':
                        direction.TurnLeft();
                        obstacleIndicator = "";
                        break;

                    case 'F':
                        var moveResult = position.Move(direction, obstacles);
                        if (moveResult.obstacleFound)
                            obstacleIndicator = "O:";

                        position = moveResult.position;
                        break;
                }
            }
            return $"{obstacleIndicator}{position}:{direction.DirectionAsText}";
        }
    }
}