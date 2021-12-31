using System;

namespace MarsRover.App
{
    internal class Position
    {
        public readonly int x;
        public readonly int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{x},{y}";
        }

        public Position IncreaseOneStepOnYAxis()
        {
            return new Position(x, y + 1);
        }
        public Position IncreaseOneStepOnXAxis()
        {
            return new Position(x + 1, y);
        }

        public Position DecreaseOneStepOnYAxis()
        {
            return new Position(x, y - 1);
        }
        public Position DecreaseOneStepOnXAxis()
        {
            return new Position(x - 1, y);
        }
    }
}