using System;
using System.Collections.Generic;

namespace ToyRobotLib.Executor
{
    /// <summary>
    /// Parse command name, and positional arguments from string
    /// Commands are in the form:
    /// 
    /// name [arg, arg, ...]
    /// </summary>
    public static class CommandParser
    {
        #region Public Static Methods

        public static CommandArgs Parse(string commandString)
        {
            try
            {
                string cmd;
                var args = new List<string>();

                commandString = commandString.Trim();

                // look for the command
                int pos = commandString.IndexOf(" ");
                if (pos > 0)
                {
                    cmd = commandString.Substring(0, pos).ToLower();
                }
                else
                {
                    cmd = commandString;
                    pos = cmd.Length - 1;
                }

                if (!string.IsNullOrEmpty(cmd))
                {
                    // get all comma seperated args
                    var argarray = commandString.Substring(pos + 1).Split(",");
                    foreach (var a in argarray)
                    {
                        string arg = a.Trim();
                        if (!string.IsNullOrEmpty(arg))
                        {
                            args.Add(arg);
                        }
                    }

                    return new CommandArgs(cmd, args);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        #endregion
    }
}
