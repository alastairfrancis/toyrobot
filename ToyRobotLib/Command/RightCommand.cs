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
        #region Public Properties

        public const string Name = "right";

        #endregion

        #region Constructors

        public RightCommand(CommandArgs arguments)
        {
        }

        #endregion

        #region ICommand

        public CommandResult Execute(IRobot robot, IGrid grid, IOutputWriter output)
        {
            if (!robot.IsValidState())
                return CommandResult.Fail("Robot is not accepting commands");

            var result = robot.TurnRight();
            return new CommandResult(result);
        }

        #endregion
    }
}
