using System;

namespace MarsRover.App
{
    internal class Grid
    {
        private PositionTranslator positionTranslator;

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

            positionTranslator = new PositionTranslator(width, height);
        }

        //Refactor: Possible refactor, extracing knowledge of the direction from the grid, would allow to have different types of rotations and directions (ie: a more fine grained rotation)
        //          this would require to inject this new dependency into the grid, could be simply done, but I'm lazy and is not required
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

        internal void MoveForwards()
        {
            switch (CurrentDirection)
            {
                case Direction.N:
                    CurrentPosition = positionTranslator.MoveOneStepForwardOnYAxes(CurrentPosition);
                    break;

                case Direction.S:
                    CurrentPosition = positionTranslator.MoveOneStepBackOnYAxes(CurrentPosition);
                    break;

                case Direction.E:
                    CurrentPosition = positionTranslator.MoveOneStepForwardOnXAxes(CurrentPosition);
                    break;

                case Direction.W:
                    CurrentPosition = positionTranslator.MoveOneStepBackwardsOnXAxes(CurrentPosition);
                    break;
            }
        }

        internal void MoveBackwards()
        {
            switch (CurrentDirection)
            {
                case Direction.N:
                    CurrentPosition = positionTranslator.MoveOneStepBackOnYAxes(CurrentPosition);
                    break;

                case Direction.S:
                    CurrentPosition = positionTranslator.MoveOneStepForwardOnYAxes(CurrentPosition);
                    break;

                case Direction.E:
                    CurrentPosition = positionTranslator.MoveOneStepBackwardsOnXAxes(CurrentPosition);
                    break;

                case Direction.W:
                    CurrentPosition = positionTranslator.MoveOneStepForwardOnXAxes(CurrentPosition);
                    break;
            }
        }

        private class PositionTranslator
        {
            private readonly int areaWidth;
            private readonly int areaHeight;

            public PositionTranslator(int areaWidth, int areaHeight)
            {
                this.areaWidth = areaWidth;
                this.areaHeight = areaHeight;
            }

            internal Position MoveOneStepForwardOnXAxes(Position currentPosition)
            {
                Position newPosition;
                newPosition = currentPosition.IncreaseOneStepOnXAxes();
                if (newPosition.X > areaWidth)
                    newPosition = ResetXCoordinateTo(0, currentPosition);
                return newPosition;
            }

            internal Position MoveOneStepForwardOnYAxes(Position currentPosition)
            {
                Position newPosition;
                newPosition = currentPosition.IncreaseOneStepOnYAxes();

                if (newPosition.Y > areaHeight)
                    newPosition = ResetYCoordinateTo(0, currentPosition);
                return newPosition;
            }

            internal Position MoveOneStepBackwardsOnXAxes(Position currentPosition)
            {
                Position newPosition;
                newPosition = currentPosition.DecreaseOneStepOnXAxes();

                if (newPosition.X < 0)
                    newPosition = ResetXCoordinateTo(areaWidth, currentPosition);

                return newPosition;
            }

            internal Position MoveOneStepBackOnYAxes(Position currentPosition)
            {
                Position newPosition;
                newPosition = currentPosition.DecreaseOneStepOnYAxes();

                if (newPosition.Y < 0)
                    newPosition = ResetYCoordinateTo(areaHeight, currentPosition);
                return newPosition;
            }

            private Position ResetXCoordinateTo(int newXCoordinate, Position CurrentPosition)
            {
                return new Position(newXCoordinate, CurrentPosition.Y);
            }

            private Position ResetYCoordinateTo(int newYCoordinate, Position CurrentPosition)
            {
                return new Position(CurrentPosition.X, newYCoordinate);
            }
        }
    }
}