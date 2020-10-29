using System;

namespace ESAPICommander.Commands
{
    public abstract class BaseCommandDirector : IDisposable
    {
        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        protected virtual void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseCommandDirector()
        {
            Dispose(false);
        }
    }
}