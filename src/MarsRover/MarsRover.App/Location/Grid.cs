using MarsRover.App.Location.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.App.Location
{
    internal class Grid
    {
        private PositionTranslator positionTranslator;

        public Grid(int width, int height, IObstacleProvider obstacleProvider)
        {
            if (width <= 0 && height <= 0 || height < 0 || width < 0)
            {
                throw new ArgumentOutOfRangeException($"Dimensions are incorrect, at least height or width must be greater than zero. Current values are: width:{width},  height:{height}");
            }

            Width = width;
            Height = height;

            CurrentDirection = Direction.N;
            CurrentPosition = new Position(0, 0);

            positionTranslator = new PositionTranslator(width, height, obstacleProvider);
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
            MovePositionResult result = new MovePositionResult { ValidPosition = new Position(0, 0), MoveWasBlocked = false };
            switch (CurrentDirection)
            {
                case Direction.N:
                    result = positionTranslator.MoveOneStepForwardOnYAxes(CurrentPosition);
                    break;

                case Direction.S:
                    result = positionTranslator.MoveOneStepBackOnYAxes(CurrentPosition);
                    break;

                case Direction.E:
                    result = positionTranslator.MoveOneStepForwardOnXAxes(CurrentPosition);
                    break;

                case Direction.W:
                    result = positionTranslator.MoveOneStepBackwardsOnXAxes(CurrentPosition);
                    break;
            }

            CurrentPosition = result.ValidPosition;

            return result.MoveWasBlocked;
        }

        internal bool MoveBackwards()
        {
            MovePositionResult result = new MovePositionResult { ValidPosition = new Position(0, 0), MoveWasBlocked = false };

            switch (CurrentDirection)
            {
                case Direction.N:
                    result = positionTranslator.MoveOneStepBackOnYAxes(CurrentPosition);
                    break;

                case Direction.S:
                    result = positionTranslator.MoveOneStepForwardOnYAxes(CurrentPosition);
                    break;

                case Direction.E:
                    result = positionTranslator.MoveOneStepBackwardsOnXAxes(CurrentPosition);
                    break;

                case Direction.W:
                    result = positionTranslator.MoveOneStepForwardOnXAxes(CurrentPosition);
                    break;
            }
            CurrentPosition = result.ValidPosition;

            return result.MoveWasBlocked;
        }

        private class MovePositionResult
        {
            public Position? ValidPosition = null;
            public bool MoveWasBlocked;
        }

        private class PositionTranslator
        {
            private readonly int areaWidth;
            private readonly int areaHeight;
            private readonly IReadOnlyCollection<Position> obstructions;

            public PositionTranslator(int areaWidth, int areaHeight, IObstacleProvider obstacleProvider)
            {
                this.areaWidth = areaWidth;
                this.areaHeight = areaHeight;
                obstructions = obstacleProvider.GetObstructions();
            }

            internal MovePositionResult MoveOneStepForwardOnXAxes(Position currentPosition)
            {
                Position newPosition;

                if (currentPosition.NextXCoordinate > areaWidth)
                    newPosition = ResetXCoordinateTo(0, currentPosition);
                else
                    newPosition = currentPosition.IncreaseOneStepOnXAxes();

                var wasBlocked = IsNextPositionBlocked(newPosition);
                if (wasBlocked)
                {
                    newPosition = currentPosition;
                }

                return new MovePositionResult { ValidPosition = newPosition, MoveWasBlocked = wasBlocked };
            }

            internal MovePositionResult MoveOneStepForwardOnYAxes(Position currentPosition)
            {
                Position newPosition;
                if (currentPosition.NextYCoordinate > areaHeight)
                    newPosition = ResetYCoordinateTo(0, currentPosition);
                else
                    newPosition = currentPosition.IncreaseOneStepOnYAxes();

                var wasBlocked = IsNextPositionBlocked(newPosition);
                if (wasBlocked)
                {
                    newPosition = currentPosition;
                }

                return new MovePositionResult { ValidPosition = newPosition, MoveWasBlocked = wasBlocked };
            }

            internal MovePositionResult MoveOneStepBackwardsOnXAxes(Position currentPosition)
            {
                Position newPosition;
                if (currentPosition.PreviousXCoordinate < 0)
                    newPosition = ResetXCoordinateTo(areaWidth, currentPosition);
                else
                    newPosition = currentPosition.DecreaseOneStepOnXAxes();

                var wasBlocked = IsNextPositionBlocked(newPosition);
                if (wasBlocked)
                {
                    newPosition = currentPosition;
                }

                return new MovePositionResult { ValidPosition = newPosition, MoveWasBlocked = wasBlocked };
            }

            internal MovePositionResult MoveOneStepBackOnYAxes(Position currentPosition)
            {
                Position newPosition;
                if (currentPosition.PreviousYCoordinate < 0)
                    newPosition = ResetYCoordinateTo(areaHeight, currentPosition);
                else
                    newPosition = currentPosition.DecreaseOneStepOnYAxes();

                var wasBlocked = IsNextPositionBlocked(newPosition);
                if (wasBlocked)
                {
                    newPosition = currentPosition;
                }

                return new MovePositionResult { ValidPosition = newPosition, MoveWasBlocked = wasBlocked };
            }

            private bool IsNextPositionBlocked(Position newPosition)
            {
                return obstructions.Contains(newPosition);
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