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
        #region Private Properties

        private readonly Vector _position;

        #endregion

        #region Public Properties

        public const string Name = "place";

        #endregion

        #region Constructors

        public PlaceCommand(Vector position)
        {
            _position = position;
        }

        public  PlaceCommand(CommandArgs args)
        {
            _position = new Vector(args.GetInt(0), args.GetInt(1), args.GetHeading(2));
        }

        #endregion

        #region ICommand

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

        #endregion
    }
}
