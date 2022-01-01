using System;

namespace MarsRover.App
{
    internal class Grid
    {
        //will take in an IObstacleProvider, which provides dimensions and can tell if an obstacle is at a determined position
        public Grid(int width, int height)
        {
            if (width <= 0 && height <= 0 || height < 0 || width < 0)
            {
                throw new ArgumentOutOfRangeException($"Dimensions are incorrect, at least height or width must be greater than zero. Current values are: width:{width},  height:{height}");
            }

            Width = width;
            Height = height;

            CurrentDirection = Direction.N;
            CurrentPosition = new Position(0, 0);
        }

        internal enum Direction
        {
            N, E, S, W
        }

        public Position CurrentPosition { get; internal set; }

        public int Width { get; }

        public int Height { get; }

        public Direction CurrentDirection { get; private set; }

        internal void TurnRight()
        {
            if (CurrentDirection == Direction.W)
                CurrentDirection = Direction.N;
            else
                CurrentDirection++;
        }

        internal void TurnLeft()
        {
            if (CurrentDirection == Direction.N)
                CurrentDirection = Direction.W;
            else
                CurrentDirection--;
        }

        internal void MoveBackwards()
        {
            switch (CurrentDirection)
            {
                case Direction.N:
                    CurrentPosition = CurrentPosition.DecreaseOneStepOnYAxes();

                    if (CurrentPosition.Y < 0)
                        CurrentPosition = new Position(CurrentPosition.X, Height);

                    break;

                case Direction.S:
                    CurrentPosition = CurrentPosition.IncreaseOneStepOnYAxes();

                    if (CurrentPosition.Y > Height)
                        CurrentPosition = new Position(CurrentPosition.X, 0);

                    break;

                case Direction.E:
                    CurrentPosition = CurrentPosition.DecreaseOneStepOnXAxes();

                    if (CurrentPosition.X < 0)
                        CurrentPosition = new Position(Width, CurrentPosition.Y);

                    break;

                case Direction.W:
                    CurrentPosition = CurrentPosition.IncreaseOneStepOnXAxes();

                    if (CurrentPosition.X > Width)
                        CurrentPosition = new Position(0, CurrentPosition.Y);

                    break;
            }
        }

        internal void MoveForwards()
        {
            switch (CurrentDirection)
            {
                case Direction.N:
                    CurrentPosition = CurrentPosition.IncreaseOneStepOnYAxes();

                    if (CurrentPosition.Y > Height)
                        CurrentPosition = new Position(CurrentPosition.X, 0);

                    break;

                case Direction.S:
                    CurrentPosition = CurrentPosition.DecreaseOneStepOnYAxes();

                    if (CurrentPosition.Y < 0)
                        CurrentPosition = new Position(CurrentPosition.X, Height);

                    break;

                case Direction.E:
                    CurrentPosition = CurrentPosition.IncreaseOneStepOnXAxes();
                    if (CurrentPosition.X > Width)
                        CurrentPosition = new Position(0, CurrentPosition.Y);

                    break;

                case Direction.W:
                    CurrentPosition = CurrentPosition.DecreaseOneStepOnXAxes();

                    if (CurrentPosition.X < 0)
                        CurrentPosition = new Position(Width, CurrentPosition.Y);

                    break;
            }
        }
    }
}