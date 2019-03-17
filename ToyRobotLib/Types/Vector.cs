using System;

namespace ToyRobotLib.Types
{
    /// <summary>
    /// Holds position, and heading.
    /// </summary>
    public class Vector : Coordinate
    {
        public Heading Heading { get; set; }

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

        public void SetPosition(Coordinate coord)
        {
            X = coord.X;
            Y = coord.Y;
        }
    }
}
