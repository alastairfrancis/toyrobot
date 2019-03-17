using System;
using System.Collections.Generic;
using System.Reflection;
using ToyRobotLib.Command;

namespace ToyRobotLib.Executor
{
    /// <summary>
    /// Factory to create commands.    
    /// </summary>
    public static class CommandFactory
    {
        public static ICommand Create(CommandArgs args)
        {
            ICommand cmd = null;

            switch (args.Command)
            {
                case PlaceCommand.Name:
                    cmd = new PlaceCommand(args);
                    break;

                case MoveCommand.Name:
                    cmd = new MoveCommand(args);
                    break;

                case LeftCommand.Name:
                    cmd = new LeftCommand(args);
                    break;

                case RightCommand.Name:
                    cmd = new RightCommand(args);
                    break;

                case ReportCommand.Name:
                    cmd = new ReportCommand(args);
                    break;
            }

            return cmd;
        }
    }
}
