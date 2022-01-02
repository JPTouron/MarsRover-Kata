using MarsRover.App.Location.Dependencies;

namespace MarsRover.App.Location
{
    public partial class Grid
    {
        private class PositionTranslatorOnY : PositionTranslator
        {
            public PositionTranslatorOnY(int areaWidth, int areaHeight, IObstacleProvider obstacleProvider) :
                    base(areaWidth, areaHeight, obstacleProvider)
            {
            }

            internal MovePositionResult MoveOneStepForward(Position currentPosition)
            {
                var newPos = IncreaseOneStepOnYAxes(currentPosition);

                return new MovePositionResult(newPos, newPos == currentPosition);
            }

            internal MovePositionResult MoveOneStepBack(Position currentPosition)
            {
                var newPos = DecreaseOneStepOnYAxes(currentPosition);

                return new MovePositionResult(newPos, newPos == currentPosition);
            }
        }
    }
}