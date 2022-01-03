namespace MarsRoverTests
{
    internal class Rover
    {
        private Direction currentDirection = Direction.N;

        public Rover()
        {
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
                }
            }

            return $"0,0:{currentDirection.ToString()[0]}";
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