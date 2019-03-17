using System;
using System.IO;

namespace ToyRobotLib.IO
{
    /// <summary>
    /// Wrapper to read lines from a file.
    /// </summary>
    public class FileReader
    {
        private StreamReader _reader;

        public FileReader()
        {
        }

        public bool Open(string path)
        {
            bool ok = false;

            try
            {
                _reader = new StreamReader(path);
                ok = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message}");
            }

            return ok;
        }

        public string ReadLine()
        {
            return _reader.ReadLine();
        }

        public void Close()
        {
            if (_reader != null)
            {
                _reader.Close();
            }
        }


    }
}
