using System;
using System.Collections.Generic;
using System.Linq;
using ToyRobotLib.Command;
using ToyRobotLib.Extensions;

namespace ToyRobotLib.Executor
{
    /// <summary>
    /// Factory to create commands.    
    /// </summary>
    public class CommandFactory
    {
        #region Private Properties

        /// <summary>
        /// Collection of command names mapped with concrete class types
        /// </summary>
        private readonly Dictionary<string, Type> _commandClasses;

        /// <summary>
        /// Property name on command class with command name
        /// </summary>
        private static readonly string CommandClassPropertyName = "Name";

        /// <summary>
        /// Interface type implemented by concrete commands
        /// </summary>
        private static readonly Type CommandClassInterface = typeof(ICommand);

        #endregion

        #region Constructors

        public CommandFactory()
        {
            _commandClasses = new Dictionary<string, Type>();
            InitCommandClassDefinitions();
        }

        #endregion

        #region Public Methods

        public ICommand Create(CommandArgs args)
        {
            ICommand cmd = null;

            if (_commandClasses.ContainsKey(args.Command))
            {
                // instantiate concrete command class passing command args to constructor for parameter initialisation
                cmd = (ICommand)Activator.CreateInstance(_commandClasses[args.Command], new[] { args });
            }

            // Old school way I used to do it.  Found using reflection makes it easier to create a generic framework for creating command classes.
            //
            //switch (args.Command)
            //{
            //    case PlaceCommand.Name:
            //        cmd = new PlaceCommand(args);
            //        break;
            //    case MoveCommand.Name:
            //        cmd = new MoveCommand(args);
            //        break;
            //    case LeftCommand.Name:
            //        cmd = new LeftCommand(args);
            //        break;
            //    case RightCommand.Name:
            //        cmd = new RightCommand(args);
            //        break;
            //    case ReportCommand.Name:
            //        cmd = new ReportCommand(args);
            //        break;
            //}

            return cmd;
        }

        #endregion

        #region Private Methods

        private void InitCommandClassDefinitions()
        {
            // get all concrete classes implementing the interface
            var classes = CommandClassInterface.GetImplementedClasses();
            foreach (Type clazz in classes)
            {
                // look for the public const string that contains the command name
                var fieldInfos = clazz.GetConstants();

                var constantInfo = fieldInfos.Where(fi => fi.Name == CommandClassPropertyName);
                if (constantInfo.Count() == 1)
                {
                    var commandName = constantInfo.First().GetRawConstantValue() as string;
                    _commandClasses[commandName] = clazz;
                }
            }
        }

        #endregion
    }
}
