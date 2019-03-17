using System;
using ToyRobotLib.Environment;
using ToyRobotLib.IO;
using ToyRobotLib.ToyRobot;

namespace ToyRobotLib.Command
{
    public interface ICommand
    {
        CommandResult Execute(IRobot robot, IGrid grid, IOutputWriter output);
    }
}
