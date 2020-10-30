using System;
using System.Collections.Generic;

namespace ESAPICommander.Logger
{
    public class LogConsole : ILog
    {
        public Action<string> ConsoleOutput { get; internal set; }

        public LogConsole(Action<string> consoleOutput = null)
        {
            ConsoleOutput = consoleOutput ?? (Console.WriteLine);
        }

        public void AddInfo(string lineText)
        {
            ConsoleOutput(lineText);
        }

        public void AddInfo(IEnumerable<string> lines)
        {
            throw new NotImplementedException();
        }

        public void AddError(string lineText)
        {
            throw new NotImplementedException();
        }

        public void AddException(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}