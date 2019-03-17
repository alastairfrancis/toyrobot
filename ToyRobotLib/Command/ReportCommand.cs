using System;
using ToyRobotLib.Environment;
using ToyRobotLib.Executor;
using ToyRobotLib.Extensions;
using ToyRobotLib.IO;
using ToyRobotLib.ToyRobot;

namespace ToyRobotLib.Command
{
    /// <summary>
    /// Report robot position command
    /// </summary>
    public class ReportCommand : ICommand
    { 
        public const string Name = "report";

        public ReportCommand(CommandArgs args)
        {
        }

        public CommandResult Execute(IRobot robot, IGrid grid, IOutputWriter output)
        {
            if (!robot.IsValidState())
                return CommandResult.Fail("Robot is not accepting commands");

            var pos = robot.Position;
            output.Write(string.Format("Position [{0}, {1}, {2}]", pos.X, pos.Y, pos.Heading.NameOf()));

            return CommandResult.Success();
        }
    }
}
