using System;
using System.Collections.Generic;

namespace ESAPICommander.Logger
{
    public interface ILog
    {
        void AddInfo(string lineText);

        void AddInfo(IEnumerable<string> lines);

        void AddError(string lineText);

        void AddException(Exception exception);
    }
}