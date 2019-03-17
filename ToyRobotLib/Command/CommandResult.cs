using System;

namespace ToyRobotLib.Command
{
    /// <summary>
    /// Results of command execution
    /// </summary>
    public class CommandResult
    {
        public bool OK { get; private set; }
        public string Message { get; private set; }

        public CommandResult(bool ok, string message = "")
        {
            OK = ok;
            Message = message;
        }

        public static CommandResult Success(string message = "")
        {
            return new CommandResult(true, message);
        }

        public static CommandResult Fail(string errorMessage)
        {
            return new CommandResult(false, errorMessage);
        }
    }

    public class CommandResult<T>
    {
        public T Value { get; set; }
        public bool OK { get; private set; }
        public string Message { get; private set; }

        public CommandResult(bool ok, string message = "")
        {
            OK = ok;
            Message = message;
        }

        public CommandResult(bool ok, T result, string message = "")
        {
            OK = ok;
            Value = result;
            Message = message;
        }

        public static CommandResult<T> Success(T result, string message = "")
        {
            return new CommandResult<T>(true, result, message);
        }

        public static CommandResult<T> Fail(string errorMessage)
        {
            return new CommandResult<T>(false, errorMessage);
        }
    }
}
