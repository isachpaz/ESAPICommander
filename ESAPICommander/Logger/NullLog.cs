using System;
using System.Collections.Generic;

namespace ESAPICommander.Logger
{
    public class NullLog : ILog
    {
        public void AddInfo(string lineText)
        {
            
        }

        public void AddInfo(IEnumerable<string> lines)
        {
            
        }

        public void AddError(string lineText)
        {
            
        }

        public void AddException(Exception exception)
        {
            
        }
    }
}