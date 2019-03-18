using System;

namespace ToyRobotLib.IO
{
    /// <summary>
    /// Output writer to console
    /// </summary>
    public class ConsoleWriter : IOutputWriter
    {
        #region IOutputWriter

        public void Write(string message)
        {
            Console.WriteLine("Output: " + message);
        }

        public void WriteInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void WriteFail(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void WriteFail(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exception: " + ex.Message);
            Console.ResetColor();
        }

        #endregion
    }
}
