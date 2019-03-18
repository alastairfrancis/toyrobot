using System;
using System.Collections.Generic;
using System.Linq;
using ToyRobotLib.IO;
using ToyRobotLib.Types;

namespace ToyRobotLib.Environment
{
    /// <summary>
    /// Defines a 2 dimensional rectangular grid
    /// </summary>
    public class Grid2D : IGrid
    {
        #region Private Properties

        private GridCell[,] _grid;

        #endregion

        #region Public Properties

        public int Width
        {
            get
            {
                return (_grid != null) ? _grid.GetUpperBound(0) + 1 : -1;
            }
        }

        public int Height
        {
            get
            {
                return (_grid != null) ? _grid.GetUpperBound(1) + 1 : -1;
            }
        }

        #endregion

        #region Constructors

        public Grid2D()
        {
        }

        public Grid2D(int width, int height)
        {
            CreateGrid(width, height);
        }

        #endregion

        #region IGrid

        /// <summary>
        /// Returns cell at position, or null if the position is out of bounds
        /// </summary>
        public GridCell GetCell(Coordinate coord)
        {
            if (IsPositionValid(coord))
            {
                return _grid[coord.X, coord.Y];
            }

            return null;
        }

        /// <summary>
        /// Return true if cell position is within bounds
        /// </summary>
        public bool IsPositionValid(Coordinate coord)
        {
            return (coord.X >= 0) && (coord.X < Width) && (coord.Y >= 0) && (coord.Y < Height);
        }

        /// <summary>
        /// Return true if cell position is within bounds, and cell is empty
        /// </summary>
        public bool IsCellValid(Coordinate coord)
        {
            var cell = GetCell(coord);

            if (cell != null)
            {
                return cell.IsClear;
            }

            return false;
        }

        /// <summary>
        /// Create new rectangular grid
        /// </summary>
        public bool CreateGrid(int width, int height)
        {
            bool result;

            try
            {
                _grid = new GridCell[width, height];

                for (int y = _grid.GetLowerBound(0); y <= _grid.GetUpperBound(0); ++y)
                {
                    for (int x = _grid.GetLowerBound(1); x <= _grid.GetUpperBound(1); ++x)
                    {
                        _grid[x, y] = new GridCell();
                    }
                }

                result = true;
            }
            catch (Exception)
            {
                _grid = null;
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Load grid definition from file
        /// </summary>
        public bool CreateGridFromFile(string path)
        {
            bool result = false;
            var rows = new List<string>();

            try
            {
                var reader = new FileReader();
                reader.ProcessFile(path, (line) =>
                {
                    rows.Insert(0, line);
                    return true;
                });

                int height = rows.Count;
                int width = rows.First().Length;

                GridCell [,] newGrid = new GridCell[width, height];

                for (int y = newGrid.GetLowerBound(0); y <= newGrid.GetUpperBound(0); ++y)
                {
                    var cells = rows[y].ToCharArray();
                    for (int x = newGrid.GetLowerBound(1); x <= newGrid.GetUpperBound(1); ++x)
                    {
                        bool isClear = (rows[y][x] == 'o');
                        newGrid[x, y] = new GridCell(isClear);
                    }
                }

                _grid = newGrid;
                result = true;
            }
            catch (Exception)
            {
                // creation failed, the old grid will remain unchanged
                _grid = null;
                result = false;
            }

            return result;
        }

        #endregion
    }
}
