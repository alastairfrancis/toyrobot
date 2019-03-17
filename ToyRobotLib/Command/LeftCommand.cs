using System;
using ToyRobotLib.Environment;
using ToyRobotLib.Executor;
using ToyRobotLib.IO;
using ToyRobotLib.ToyRobot;

namespace ToyRobotLib.Command
{
    /// <summary>
    /// Rotate robot left command
    /// </summary>
    public class LeftCommand : ICommand
    {
        public const string Name = "left";

        public LeftCommand(CommandArgs arguments)
        {
        }

        public CommandResult Execute(IRobot robot, IGrid grid, IOutputWriter output)
        {
            if (!robot.IsValidState())
                return CommandResult.Fail("Robot is not accepting commands");

            var result = robot.TurnLeft();
            return new CommandResult(result);
        }
    }
}
