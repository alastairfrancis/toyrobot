using System;

namespace ToyRobotLib.Types
{
    /// <summary>
    /// Cartesian coordinate.
    /// </summary>
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinate(Coordinate other)
        {
            X = other.X;
            Y = other.Y;
        }
    }
}
