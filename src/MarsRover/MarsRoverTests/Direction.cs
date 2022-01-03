using System.Collections.Generic;

namespace MarsRoverTests
{
    internal class Direction
    {
        

        public Direction()
        {
            currentDirection = Directions.N;
            
        }

        internal enum Directions
        { N = 1, E, S, W }

        internal Directions currentDirection { get; private set; }

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