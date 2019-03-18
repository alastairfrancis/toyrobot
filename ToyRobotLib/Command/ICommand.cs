using System;
using ToyRobotLib.Environment;
using ToyRobotLib.IO;
using ToyRobotLib.ToyRobot;

namespace ToyRobotLib.Command
{
    public interface ICommand
    {
        #region Methods

        CommandResult Execute(IRobot robot, IGrid grid, IOutputWriter output);

        #endregion
    }
}
