﻿using System;

namespace ToyRobotLib.Environment
{
    /// <summary>
    /// Cell grid.  The clear status indicates the robot is free to occupy the cell.
    /// Eventually this could be expanded to allow multiple robots on the grid, and each would have to request 
    /// access to the grid cell to avoid collisions.
    /// </summary>
    public class GridCell
    {
        public bool IsClear { get; set; }

        public GridCell()
        {
            IsClear = true;
        }

        public GridCell(bool clear)
        {
            IsClear = clear;
        }
    }
}
