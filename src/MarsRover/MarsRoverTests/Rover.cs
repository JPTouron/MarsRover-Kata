namespace MarsRoverTests
{

    //JP: Smell: Bloater on Rover class
    internal class Rover
    {
        private Directions currentDirection;

        //JP: Smell: primitive obsession! - all is a simple int, no coords, no positions, no grids... no modeled business
        private int X;

        private int Y;

        private int maxWidth;

        private int maxHeight;

        public Rover()
        {
            currentDirection = Directions.N;

            X = 0;
            Y = 0;
            maxWidth = 10;
            maxHeight = 10;
        }

        private enum Directions
        { N = 1, E, S, W }

        public void Move()
        {
            //save the current position
            var newX = X;
            var newY = Y;

            switch (currentDirection)
            {
                case Directions.N:
                    newY = (Y + 1) % (maxHeight + 1);
                    break;

                case Directions.S:
                    newY = Y > 0 ? Y - 1 : maxHeight - 1;
                    break;

                case Directions.E:
                    newX = (X + 1) % (maxWidth + 1);
                    break;

                case Directions.W:
                    newX = X > 0 ? X - 1 : maxWidth - 1;
                    break;
            }

            //updte the current position
            X = newX;
            Y = newY;
        }

        //this method returns a coordinate
        //JP: code smell: dispensable on this method
        public override string ToString()
        {
            return $"{X},{Y}";
        }

        internal string Execute(string commands)
        {
            foreach (var command in commands)
            {
                //jp: is this really a code smell? why? when does a switch become smelly?

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
            //we return the output

            return $"{X},{Y}:{currentDirection.ToString()[0]}";
        }
        //This tursn left
        internal void TurnLeft()
        {
            //jp: code smell switch statement
            switch (currentDirection)
            {
                case Directions.N:
                    currentDirection = Directions.W;
                    break;

                case Directions.E:
                    currentDirection = Directions.N;
                    break;

                case Directions.S:
                    currentDirection = Directions.E;
                    break;

                case Directions.W:
                    currentDirection = Directions.S;

                    break;
            }
        }
        //This tursn right

        internal void TurnRight()
        {
            //jp: code smell switch statement

            switch (currentDirection)
            {
                case Directions.N:
                    currentDirection = Directions.E;
                    break;

                case Directions.E:
                    currentDirection = Directions.S;
                    break;

                case Directions.S:
                    currentDirection = Directions.W;
                    break;

                case Directions.W:
                    currentDirection = Directions.N;

                    break;
            }
        }
    }
}