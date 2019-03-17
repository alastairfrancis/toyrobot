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
        private readonly IRobot _robot;
        private readonly IGrid _grid;
        private readonly IOutputWriter _out;
        private readonly CommandParser _parser;

        public CommandExecutor(IOutputWriter outWriter, IRobot robot, IGrid grid)
        {
            _parser = new CommandParser();
            _out = outWriter;
            _robot = robot;
            _grid = grid;
        }

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
            var file = new FileReader();

            try
            {
                if (file.Open(path))
                {
                    string line = file.ReadLine();
                    while (line != null)
                    {
                        Execute(line);
                        line = file.ReadLine();
                    }
                }
            }
            finally
            {
                file.Close();
            }
        }

        #endregion

        #region Private Methods

        private ICommand Parse(string commandString)
        {
            try
            {
                var args = _parser.Parse(commandString);
                if (args != null)
                {
                    return CommandFactory.Create(args);
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
