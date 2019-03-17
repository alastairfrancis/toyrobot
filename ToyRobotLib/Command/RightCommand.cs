using System;
using ToyRobotLib.Environment;
using ToyRobotLib.Executor;
using ToyRobotLib.IO;
using ToyRobotLib.ToyRobot;

namespace ToyRobotLib.Command
{
    /// <summary>
    /// Rotate robot right command
    /// </summary>
    public class RightCommand : ICommand
    {
        public const string Name = "right";

        public RightCommand(CommandArgs arguments)
        {
        }

        public CommandResult Execute(IRobot robot, IGrid grid, IOutputWriter output)
        {
            if (!robot.IsValidState())
                return CommandResult.Fail("Robot is not accepting commands");

            var result = robot.TurnRight();
            return new CommandResult(result);
        }
    }
}
