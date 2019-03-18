using System;
using System.IO;

namespace ToyRobotLib.IO
{
    /// <summary>
    /// Utility to process lines in a file.
    /// </summary>
    public class FileReader
    {
        /// <summary>
        /// Process each line in a file.  To stop processing, return false from function parameter.
        /// </summary>
        /// <returns>True if all lines processed successfully</returns>
        public bool ProcessFile(string path, Func<string, bool> processor)
        {
            bool ok = true;

            using (StreamReader reader = new StreamReader(path))
            {
                while (ok && !reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    ok = processor(line);
                }
            }

            return ok;
        }

    }
}
