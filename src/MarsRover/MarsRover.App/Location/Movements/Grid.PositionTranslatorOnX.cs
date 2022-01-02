using MarsRover.App.Location.Dependencies;

namespace MarsRover.App.Location
{
    internal partial class Grid
    {
        private class PositionTranslatorOnX : PositionTranslator
        {
            public PositionTranslatorOnX(int areaWidth, int areaHeight, IObstacleProvider obstacleProvider) :
                base(areaWidth, areaHeight, obstacleProvider)
            {
            }

            internal MovePositionResult MoveOneStepForward(Position currentPosition)
            {
                var newPos = IncreaseOneStepOnXAxes(currentPosition);

                return new MovePositionResult(newPos, newPos == currentPosition);
            }

            internal MovePositionResult MoveOneStepBack(Position currentPosition)
            {
                var newPos = DecreaseOneStepOnXAxes(currentPosition);

                return new MovePositionResult(newPos, newPos == currentPosition);
            }
        }
    }
}