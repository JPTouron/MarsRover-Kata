namespace MarsRoverTests
{
    internal class Rover
    {
        private Direction currentDirection;
        private int x;
        private int y;

        public Rover()
        {
            currentDirection = Direction.N;
            x = y = 0;
        }

        private enum Direction
        { N = 1, E, S, W }

        internal string Execute(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'R':
                        TurnRight();
                        break;

                    case 'L':
                        TurnLeft();
                        break;

                    case 'F':
                        Move();
                        break;
                }
            }

            return $"{x},{y}:{currentDirection.ToString()[0]}";
        }

        private void Move()
        {
            switch (currentDirection)
            {
                case Direction.N:
                    y++;
                    break;
                case Direction.E:
                    x++;
                    break;
                case Direction.S:
                    y--;
                    break;
                case Direction.W:
                    x--;
                    break;
            }
        }

        private void TurnLeft()
        {
            if (currentDirection == Direction.N)
                currentDirection = Direction.W;
            else
                currentDirection--;
        }

        private void TurnRight()
        {
            if (currentDirection == Direction.W)
                currentDirection = Direction.N;
            else
                currentDirection++;
        }
    }
}