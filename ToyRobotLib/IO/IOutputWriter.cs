﻿using System;

namespace ToyRobotLib.IO
{
    public interface IOutputWriter
    {
        #region Methods

        void Write(string message);
        void WriteInfo(string message);
        void WriteWarning(string message);
        void WriteFail(string message);
        void WriteFail(Exception ex);

        #endregion
    }
}
