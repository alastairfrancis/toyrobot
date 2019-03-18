using System;

namespace ToyRobotLib.Command
{
    /// <summary>
    /// Results of command execution
    /// </summary>
    public class CommandResult
    {
        #region Public Properties

        public bool OK { get; private set; }
        public string Message { get; private set; }

        #endregion

        #region Constrcutors

        public CommandResult(bool ok, string message = "")
        {
            OK = ok;
            Message = message;
        }

        #endregion

        #region Public Methods

        public static CommandResult Success(string message = "")
        {
            return new CommandResult(true, message);
        }

        public static CommandResult Fail(string errorMessage)
        {
            return new CommandResult(false, errorMessage);
        }

        #endregion
    }
}
