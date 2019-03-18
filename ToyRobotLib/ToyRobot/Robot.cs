using System;
using ToyRobotLib.Types;
using ToyRobotLib.Extensions;

namespace ToyRobotLib.ToyRobot
{
    /// <summary>
    /// Maintain state of the robot
    /// </summary>
    public class Robot : IRobot
    {
        #region Public Properties

        public Vector Position { get; private set; }

        #endregion

        #region Constructors

        public Robot()
        {
            Reset();
        }

        public Robot(Vector initialPosition)
        {
            Position = initialPosition;
        }

        #endregion

        #region IRobot

        public void Reset()
        {
            Position = null;
        }

        public bool IsValidState()
        {
            return Position != null;
        }

        public void Place(Vector initialPosition)
        {
            Position = initialPosition;
        }

        public bool MoveTo(Coordinate coord)
        {
            if (!IsValidState())
                return false;

            Position.SetPosition(coord);
            return true;
        }

        public bool TurnLeft()
        {
            if (!IsValidState())
                return false;

            Position.Heading = Position.Heading.Previous();
            return true;
        }

        public bool TurnRight()
        {
            if (!IsValidState())
                return false;

            Position.Heading = Position.Heading.Next();
            return true;
        }

        public bool Rotate(Direction direction)
        {
            var result = false;

            switch (direction)
            {
                case Direction.Left:
                    result = TurnLeft();
                    break;

                case Direction.Right:
                    result = TurnRight();
                    break;
            }

            return result;
        }

        #endregion
    }
}
