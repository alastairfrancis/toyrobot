using System;
using ToyRobotLib.Environment;
using ToyRobotLib.Executor;
using ToyRobotLib.IO;
using ToyRobotLib.ToyRobot;
using ToyRobotLib.Types;

namespace ToyRobotLib.Command
{
    /// <summary>
    /// Move robot forward command
    /// </summary>
    public class MoveCommand : ICommand
    {
        public const string Name = "move";

        public MoveCommand(CommandArgs arguments)
        {
        }

        public CommandResult Execute(IRobot robot, IGrid grid, IOutputWriter output)
        {
            if (!robot.IsValidState())
                return CommandResult.Fail("Robot is not accepting commands");

            var currPos = robot.Position;
            var newPos = new Coordinate(currPos.X, currPos.Y);

            // work out the new position
            switch (currPos.Heading)
            {
                case Heading.North:
                    newPos.Y = currPos.Y + 1;
                    break;

                case Heading.East:
                    newPos.X = currPos.X + 1;
                    break;

                case Heading.South:
                    newPos.Y = currPos.Y - 1;
                    break;

                case Heading.West:
                    newPos.X = currPos.X - 1;
                    break;
            }

            // check with grid if the new position is valid
            if (grid.IsCellValid(newPos))
            {
                var result = robot.MoveTo(newPos);
                return new CommandResult(result);
            }

            return CommandResult.Fail("Position is not valid");
        }
    }
}
