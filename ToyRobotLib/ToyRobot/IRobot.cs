using System;
using ToyRobotLib.Types;

namespace ToyRobotLib.ToyRobot
{
    public interface IRobot
    {
        Vector Position { get; }

        void Reset();
        bool IsValidState();
        void Place(Vector initalPosition);
        bool MoveTo(Coordinate coord);
        bool TurnLeft();
        bool TurnRight();
        bool Rotate(Direction direction);        
    }
}
