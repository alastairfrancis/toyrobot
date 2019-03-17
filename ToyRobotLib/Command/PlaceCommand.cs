using System;
using ToyRobotLib.Types;
using ToyRobotLib.ToyRobot;
using ToyRobotLib.Environment;
using ToyRobotLib.Executor;
using ToyRobotLib.IO;

namespace ToyRobotLib.Command
{
    /// <summary>
    /// Placement of robot on grid command
    /// </summary>
    public class PlaceCommand : ICommand
    {
        private readonly Vector _position;

        public const string Name = "place";

        public PlaceCommand(Vector position)
        {
            _position = position;
        }

        public  PlaceCommand(CommandArgs args)
        {
            _position = new Vector(args.GetInt(0), args.GetInt(1), args.GetHeading(2));
        }

        public CommandResult Execute(IRobot robot, IGrid grid, IOutputWriter output)
        {
            // only place the robot if the position is valid
            if (grid.IsCellValid(_position))
            {
                robot.Place(_position);
                return CommandResult.Success();
            }

            return CommandResult.Fail($@"Invalid position [{ _position.X}, {_position.Y}]");
        }

    }
}
