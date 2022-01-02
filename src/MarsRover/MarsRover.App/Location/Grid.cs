using MarsRover.App.Location.Dependencies;
using System;

namespace MarsRover.App.Location
{
    internal partial class Grid
    {
        private PositionTranslatorOnX positionTranslatorOnX;
        private PositionTranslatorOnY positionTranslatorOnY;

        public Grid(int width, int height, IObstacleProvider obstacleProvider)
        {
            ValidateGridDimensionsAreAtLeastSizeOne(width, height);

            Width = width;
            Height = height;

            CurrentDirection = Direction.N;
            CurrentPosition = new Position(0, 0);

            positionTranslatorOnX = new PositionTranslatorOnX(width, height, obstacleProvider);
            positionTranslatorOnY = new PositionTranslatorOnY(width, height, obstacleProvider);
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

        internal bool MoveForwards()
        {
            MovePositionResult result;

            switch (CurrentDirection)
            {
                default:
                case Direction.N:
                    result = positionTranslatorOnY.MoveOneStepForward(CurrentPosition);
                    break;

                case Direction.S:
                    result = positionTranslatorOnY.MoveOneStepBack(CurrentPosition);
                    break;

                case Direction.E:
                    result = positionTranslatorOnX.MoveOneStepForward(CurrentPosition);
                    break;

                case Direction.W:
                    result = positionTranslatorOnX.MoveOneStepBack(CurrentPosition);
                    break;
            }

            CurrentPosition = result.ValidPosition;

            return result.MoveWasBlocked;
        }

        internal bool MoveBackwards()
        {
            MovePositionResult result;

            switch (CurrentDirection)
            {
                default:
                case Direction.N:
                    result = positionTranslatorOnY.MoveOneStepBack(CurrentPosition);
                    break;

                case Direction.S:
                    result = positionTranslatorOnY.MoveOneStepForward(CurrentPosition);
                    break;

                case Direction.E:
                    result = positionTranslatorOnX.MoveOneStepBack(CurrentPosition);
                    break;

                case Direction.W:
                    result = positionTranslatorOnX.MoveOneStepForward(CurrentPosition);
                    break;
            }
            CurrentPosition = result.ValidPosition;

            return result.MoveWasBlocked;
        }

        private static void ValidateGridDimensionsAreAtLeastSizeOne(int width, int height)
        {
            if (width <= 0 && height <= 0 || height < 0 || width < 0)
                throw new ArgumentOutOfRangeException($"Dimensions are incorrect, at least height or width must be greater than zero. Current values are: width:{width},  height:{height}");
        }

        private class MovePositionResult
        {
            public readonly Position ValidPosition;

            public readonly bool MoveWasBlocked;

            public MovePositionResult(Position validPosition, bool moveWasBlocked)
            {
                ValidPosition = validPosition;
                MoveWasBlocked = moveWasBlocked;
            }
        }
    }
}