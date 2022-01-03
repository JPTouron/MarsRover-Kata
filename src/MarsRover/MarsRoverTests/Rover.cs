using static MarsRoverTests.Direction;

namespace MarsRoverTests
{
    internal class Rover
    {
        private Direction direction;
        private int x;
        private int y;

        public Rover()
        {
            direction = new Direction() ;
            x = y = 0;
        }


        internal string Execute(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'R':
                        direction.TurnRight();
                        break;

                    case 'L':
                        direction.TurnLeft    ();
                        break;

                    case 'F':
                        Move();
                        break;
                }
            }

            return $"{x},{y}:{direction.DirectionAsText}";
        }

        private void Move()
        {
            switch (direction.currentDirection)
            {
                case Direction.Directions.N:
                    y++;
                    break;
                case Direction.Directions.E:
                    x++;
                    break;
                case Direction.Directions.S:
                    y--;
                    break;
                case Direction.Directions.W:
                    x--;
                    break;
            }
        }

        
    }

    internal class Direction {

        internal Directions currentDirection { get; private set; }
        public Direction()
        {
            currentDirection = Directions.N;
        }
        internal enum Directions
        { N = 1, E, S, W }
        internal char DirectionAsText => currentDirection.ToString()[0];
        internal void TurnLeft()
        {
            if (currentDirection == Directions.N)
                currentDirection = Directions.W;
            else
                currentDirection--;
        }

        internal void TurnRight()
        {
            if (currentDirection == Directions.W)
                currentDirection = Directions.N;
            else
                currentDirection++;
        }
    }
}