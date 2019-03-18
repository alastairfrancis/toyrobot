using System;

namespace ToyRobotLib.Types
{
    /// <summary>
    /// Holds position, and heading.
    /// </summary>
    public class Vector : Coordinate
    {
        #region Public Properties

        public Heading Heading { get; set; }

        #endregion

        #region Constructors

        public Vector(int x, int y, Heading direction)
            : base (x, y)
        {
            Heading = direction;
        }

        public Vector(Vector other)
            : base(other.X, other.Y)
        {
            Heading = other.Heading;
        }

        #endregion

        #region Public Methods

        public void SetPosition(Coordinate coord)
        {
            X = coord.X;
            Y = coord.Y;
        }

        #endregion
    }
}
