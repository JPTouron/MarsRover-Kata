using System;
using System.Collections.Generic;
using Xunit;
using static MarsRover.App.Grid;

namespace MarsRover.App
{
    public class GridTests
    {
        [Fact]
        public void WhenCreated_GridInitializesAtPositionZeroAndDirectionN()
        {
            var grid = new Grid(1, 1);
            var expectedCoordinates = 0;
            var expectedDirection = Direction.N;
            var pos = grid.CurrentPosition;

            Assert.Equal(pos.x, expectedCoordinates);
            Assert.Equal(pos.y, expectedCoordinates);
            Assert.Equal(grid.CurrentDirection, expectedDirection);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(-1, 1, true)]
        [InlineData(1, -1, true)]
        [InlineData(-10, -10, true)]
        [InlineData(1, 0, false)]
        [InlineData(0, 1, false)]
        [InlineData(10, 10, false)]
        public void WhenCreated_DimensionsHaveToBeAMinimumOfOneForHeightOrWidthOrElseItThrowsException(int width, int height, bool expectedToThrow)
        {
            if (expectedToThrow)
                Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(width, height));
            else
            {
                var grid = new Grid(width, height);
                Assert.NotNull(grid);
                Assert.Equal(0, grid.CurrentPosition.x);
                Assert.Equal(0, grid.CurrentPosition.y);
                Assert.Equal(Direction.N, grid.CurrentDirection);
            }
        }

        [Theory]
        [MemberData(nameof(MovementCombinationTests.MultipleCombinationsOfMovementOutsideBorders), MemberType = typeof(MovementCombinationTests))]
        [MemberData(nameof(MovementCombinationTests.BackAndForwardMovementsWithinGridBorders), MemberType = typeof(MovementCombinationTests))]
        [MemberData(nameof(MovementCombinationTests.MultipleCombinationsOfMovementsWithinBorders), MemberType = typeof(MovementCombinationTests))]
        [MemberData(nameof(MovementCombinationTests.TurningRightAndLeftWithinGridBorders), MemberType = typeof(MovementCombinationTests))]
        [MemberData(nameof(MovementCombinationTests.TurningRightAndWrappingOutsideGridBordersOnXAxes), MemberType = typeof(MovementCombinationTests))]
        [MemberData(nameof(MovementCombinationTests.WrappingOutsideGridBordersOnYAxes), MemberType = typeof(MovementCombinationTests))]
        internal void WhenACombinationOfMovementsIsDone_PositionAndDirectionChangeAccordinglyResetingPositionCoordinateWhenMovingOutsideOfGridOnAnyOfTheAxis(
            int gridWidth,
            int gridHeight,
            string movementsAndTurns,
            Direction expectedResultingDirection,
            int xCoordinate,
            int yCoordinate
            )
        {
            var expectedResultingPosition = new Position(xCoordinate, yCoordinate);

            var grid = new Grid(gridWidth, gridHeight);

            foreach (char command in movementsAndTurns)
            {
                switch (command)
                {
                    case 'L':
                        grid.TurnLeft();
                        break;

                    case 'R':
                        grid.TurnRight();
                        break;

                    case 'F':
                        grid.MoveForwards();
                        break;

                    case 'B':
                        grid.MoveBackwards();
                        break;
                }
            }

            Assert.Equal(expectedResultingDirection, grid.CurrentDirection);
            Assert.Equal(expectedResultingPosition, grid.CurrentPosition);
        }

        public static class MovementCombinationTests
        {
            public static IEnumerable<object> MultipleCombinationsOfMovementOutsideBorders()
            {
                // multiple combinations of movements outside borders
                yield return new object[] { 20, 20, "RBBBRBBBLFFF", Direction.E, 0, 3 };
                yield return new object[] { 20, 20, "BBBBRFFFRFFF", Direction.S, 3, 14 };
                yield return new object[] { 4, 4, "FFFF", Direction.N, 0, 4 };
                yield return new object[] { 4, 4, "FFFFF", Direction.N, 0, 0 };
                yield return new object[] { 4, 4, "RFFFF", Direction.E, 4, 0 };
                yield return new object[] { 4, 4, "RFFFFF", Direction.E, 0, 0 };
            }

            public static IEnumerable<object[]> WrappingOutsideGridBordersOnYAxes()
            {
                // wrapping outside grid borders on Y axis
                yield return new object[] { 20, 20, "B", Direction.N, 0, 20 };
                yield return new object[] { 20, 20, "BB", Direction.N, 0, 19 };
            }

            public static IEnumerable<object[]> TurningRightAndLeftWithinGridBorders()
            { // Turning right and moving right within grid borders
                yield return new object[] { 20, 20, "RF", Direction.E, 1, 0 };
                yield return new object[] { 20, 20, "RFF", Direction.E, 2, 0 };
            }

            public static IEnumerable<object[]> TurningRightAndWrappingOutsideGridBordersOnXAxes()
            {
                // Turning right and wrapping outside grid borders on X axis
                yield return new object[] { 20, 20, "RB", Direction.E, 20, 0 };
                yield return new object[] { 20, 20, "RBB", Direction.E, 19, 0 };
            }

            public static IEnumerable<object[]> MultipleCombinationsOfMovementsWithinBorders()
            {
                // multiple combinations of movements within borders
                yield return new object[] { 20, 20, "FFRFFFLFBL", Direction.W, 3, 2 };
                yield return new object[] { 20, 20, "RFFFFLFFFFLBBLFF", Direction.S, 6, 2 };
            }

            public static IEnumerable<object[]> BackAndForwardMovementsWithinGridBorders()
            {
                // regular back and forward movements on Y axis within grid borders
                yield return new object[] { 20, 20, "FFF", Direction.N, 0, 3 };
                yield return new object[] { 20, 20, "FFFBB", Direction.N, 0, 1 };
            }
        }
    }
}