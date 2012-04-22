namespace BridgeSolver.Logging
{
    public interface ILogger
    {
        void Debug(string debugText);
        void DebugFormat(string debugText, params object[] parameters);
        void Info(string infoText);
        void InfoFormat(string infoText, params object[] parameters);
        void Warning(string warningText);
        void WarningFormat(string warningText, params object[] parameters);
        void Error(string errorText);
        void ErrorFormat(string errorText, params object[] parameters);
    }
}