using System;

namespace BridgeSolver.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Debug(string debugText)
        {
            Write(ConsoleColor.Gray, debugText);
        }

        public void DebugFormat(string debugText, params object[] parameters)
        {
            Write(ConsoleColor.Gray, debugText, parameters);
        }

        public void Info(string infoText)
        {
            Write(ConsoleColor.White, infoText);
        }

        public void InfoFormat(string infoText, params object[] parameters)
        {
            Write(ConsoleColor.White, infoText, parameters);
        }

        public void Warning(string warningText)
        {
            Write(ConsoleColor.Yellow, warningText);
        }

        public void WarningFormat(string warningText, params object[] parameters)
        {
            Write(ConsoleColor.Yellow, warningText, parameters);
        }

        public void Error(string errorText)
        {
            Write(ConsoleColor.Red, errorText);
        }

        public void ErrorFormat(string errorText, params object[] parameters)
        {
            Write(ConsoleColor.Red, errorText, parameters);
        }

        private void Write(ConsoleColor colour, string text, params object[] parameters)
        {
            var oldColour = Console.ForegroundColor;
            Console.ForegroundColor = colour;

            Console.WriteLine(parameters == null ? text : string.Format(text, parameters));

            Console.ForegroundColor = oldColour;
        }
    }
}