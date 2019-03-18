using System;
using ToyRobotLib.Environment;
using ToyRobotLib.Executor;
using ToyRobotLib.IO;
using ToyRobotLib.ToyRobot;
using ToyRobotLib.Types;

namespace ToyRobotLib
{
    /// <summary>
    /// Facade implementing a robot in a console.
    /// 
    /// This could be done through a services instantiated with the (IRobot, IGrid, and IOutputWriter), 
    /// however I'm keeping the scope to a console application only.
    /// </summary>
    public class RobotSimulator
    {
        #region Private Properties

        private readonly CommandExecutor _executor;
        private readonly IRobot _robot;
        private readonly IGrid _grid;
        private readonly IOutputWriter _out;

        #endregion

        #region Constructors

        public RobotSimulator()
        {
            _robot = new Robot();
            _grid = new Grid2D();
            _out = new ConsoleWriter();
            _executor = new CommandExecutor(_out, _robot, _grid);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Remove robot from grid
        /// </summary>
        public void RobotReset()
        {
            _robot.Reset();
        }

        /// <summary>
        /// Return the current robot position, or null if not placed on grid
        /// </summary>
        public Vector RobotPosition()
        {
            return _robot.Position;
        }

        /// <summary>
        /// Execute robot command
        /// </summary>
        public void Execute(string command)
        {
            _executor.Execute(command);
        }

        /// <summary>
        /// Execute all commands in file
        /// </summary>
        public void ExecuteFile(string scriptPath)
        {
            _executor.ExecuteFile(scriptPath);
        }

        /// <summary>
        /// Create new grid, any existing grid will be replaced
        /// </summary>
        public void CreateGrid(int width, int height)
        {
            _grid.CreateGrid(width, height);
        }

        /// <summary>
        /// Create grid from definition in file
        /// </summary>
        public void CreateGridFromFile(string filePath)
        {
            _grid.CreateGridFromFile(filePath);
        }

        #endregion
    }
}
