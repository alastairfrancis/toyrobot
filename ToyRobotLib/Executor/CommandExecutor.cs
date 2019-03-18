using System;
using ToyRobotLib.ToyRobot;
using ToyRobotLib.Command;
using ToyRobotLib.Environment;
using ToyRobotLib.IO;

namespace ToyRobotLib.Executor
{
    /// <summary>
    /// Engine to execute robot commands.
    /// </summary>
    public class CommandExecutor
    {
        #region Private Properties

        private readonly IRobot _robot;
        private readonly IGrid _grid;
        private readonly IOutputWriter _out;
        private readonly CommandFactory _factory;

        #endregion

        #region Constructors

        public CommandExecutor(IOutputWriter outWriter, IRobot robot, IGrid grid)
        {
            _out = outWriter;
            _robot = robot;
            _grid = grid;
            _factory = new CommandFactory();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Execute command string.  The command can not span multiple lines.  Empty lines are ignored.
        /// </summary>
        public bool Execute(string line)
        {
            var command = Parse(line);

            if (command != null)
            {
                _out.WriteInfo(line);
                return Execute(command);
            }
            else
            {
                _out.WriteFail($"Unknown command: {line}");
            }

            return false;
        }

        /// <summary>
        /// Execute all command in the file.  Each command should be on a seperate line.
        /// </summary>
        public void ExecuteFile(string path)
        {
            try
            {
                var reader = new FileReader();
                reader.ProcessFile(path, Execute);
            }
            catch (Exception ex)
            {
                _out.WriteFail(ex);
            }
        }

        #endregion

        #region Private Methods

        private ICommand Parse(string commandString)
        {
            try
            {
                var args = CommandParser.Parse(commandString);
                if (args != null)
                {
                    return _factory.Create(args);
                }
            }
            catch (Exception ex)
            {
                _out.WriteFail($"Parse command failed, Exception: {ex.Message}");
            }

            return null;
        }

        private bool Execute(ICommand command)
        {
            bool result = false;

            try
            {
                var executionResult = command.Execute(_robot, _grid, _out);
                if (!executionResult.OK)
                {
                    _out.WriteFail($"Command failed: {executionResult.Message}");
                }

                result = executionResult.OK;
            }
            catch (Exception ex)
            {
                _out.WriteFail(ex);
            }

            return result;
        }

        #endregion
    }
}
