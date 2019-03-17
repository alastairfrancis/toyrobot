using System;
using ToyRobotLib.Types;

namespace ToyRobotLib.Environment
{
    public interface IGrid
    {
        int Width { get; }
        int Height { get; }
        bool CreateGrid(int width, int height);
        bool CreateGridFromFile(string path);
        bool IsPositionValid(Coordinate coord);
        bool IsCellValid(Coordinate coord);
        GridCell GetCell(Coordinate coord);

    }
}
