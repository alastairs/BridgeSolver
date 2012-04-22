using BridgeSolver.Logging;

namespace BridgeSolver.Tests.Helpers
{
    internal class NoopLogger : ILogger
    {
        public void Debug(string debugText)
        {
            return;
        }

        public void DebugFormat(string debugText, params object[] parameters)
        {
            return;
        }

        public void Info(string infoText)
        {
            return;
        }

        public void InfoFormat(string infoText, params object[] parameters)
        {
            return;
        }

        public void Warning(string warningText)
        {
            return;
        }

        public void WarningFormat(string warningText, params object[] parameters)
        {
            return;
        }

        public void Error(string errorText)
        {
            return;
        }

        public void ErrorFormat(string errorText, params object[] parameters)
        {
            return;
        }
    }
}