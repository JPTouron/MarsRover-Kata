namespace MarsRoverTests
{
    internal class Rover
    {
        private Direction direction;
        private Position position;

        public Rover()
        {
            direction = new Direction();
            position = new Position(0, 0);
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
                        direction.TurnLeft();
                        break;

                    case 'F':
                        position = position.Move(direction);
                        break;
                }
            }

            return $"{position}:{direction.DirectionAsText}";
        }
    }
}