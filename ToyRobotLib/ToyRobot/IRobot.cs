using System;
using ToyRobotLib.Types;

namespace ToyRobotLib.ToyRobot
{
    public interface IRobot
    {
        #region Properties

        Vector Position { get; }

        #endregion

        #region Methods

        void Reset();
        bool IsValidState();
        void Place(Vector initalPosition);
        bool MoveTo(Coordinate coord);
        bool TurnLeft();
        bool TurnRight();
        bool Rotate(Direction direction);

        #endregion
    }
}
