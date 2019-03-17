using System;
using ToyRobotLib.Environment;
using ToyRobotLib.Executor;
using ToyRobotLib.IO;
using ToyRobotLib.ToyRobot;
using ToyRobotLib.Types;

namespace ToyRobotLib
{
    /// <summary>
    /// Wrapper class for testing, and using in a console.
    /// 
    /// This could be done through a services instantiated with the (IRobot, IGrid, and IOutputWriter), 
    /// however I'm keeping the scope to a console application only.
    /// </summary>
    public class RobotSimulator
    {
        private readonly CommandExecutor _executor;
        private readonly IRobot _robot;
        private readonly IGrid _grid;
        private readonly IOutputWriter _out;

        public RobotSimulator()
        {
            _robot = new Robot();
            _grid = new Grid2D();
            _out = new ConsoleWriter();
            _executor = new CommandExecutor(_out, _robot, _grid);
        }

        public void RobotReset()
        {
            _robot.Reset();
        }

        public Vector RobotPosition()
        {
            return _robot.Position;
        }

        public void Execute(string command)
        {
            _executor.Execute(command);
        }

        public void ExecuteFile(string scriptPath)
        {
            _executor.ExecuteFile(scriptPath);
        }

        public void CreateGrid(int width, int height)
        {
            _grid.CreateGrid(width, height);
        }

        public void CreateGridFromFile(string filePath)
        {
            _grid.CreateGridFromFile(filePath);
        }

    }
}
