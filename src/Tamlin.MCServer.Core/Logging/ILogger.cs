﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCServer.Core.Logging
{
    public interface ILogger
    {
        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);
        void Error(Exception x);
        void Error(Exception x, string message);
        void Fatal(string message);
        void Fatal(Exception x);
        void Fatal(Exception x, string message);
    }
}
