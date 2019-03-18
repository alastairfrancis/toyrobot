using System;
using System.Collections.Generic;
using ToyRobotLib.Types;

namespace ToyRobotLib.Executor
{
    /// <summary>
    /// Command, and command arguments.
    /// </summary>
    public class CommandArgs
    {
        #region Public Properties

        /// <summary>
        /// Command name
        /// </summary>
        public string Command { get; }
        /// <summary>
        /// Arguments in positional order
        /// </summary>
        public List<string> Arguments { get; }

        #endregion

        #region Constructors

        public CommandArgs(string cmd, List<string> args)
        {
            Command = cmd;
            Arguments = args;
        }

        #endregion

        #region Public Methods

        public int GetInt(int argPosition)
        {
            return int.Parse(Arguments[argPosition]);
        }

        public string GetString(int argPosition)
        {
            return Arguments[argPosition];
        }

        public Heading GetHeading(int argPosition)
        {
            return Enum.Parse<Heading>(Arguments[argPosition]);
        }

        #endregion
    }
}
