using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtilityBelt.Core.Services
{
    public class TextBoxLoggerProvider : ILoggerProvider
    {
        private readonly Action<string> _logAction;

        public TextBoxLoggerProvider(Action<string> logAction)
        {
            _logAction = logAction;
        }

        public ILogger CreateLogger(string categoryName) => new TextBoxLogger(_logAction);

        public void Dispose() { }

        private class TextBoxLogger : ILogger
        {
            private readonly Action<string> _logAction;

            public TextBoxLogger(Action<string> logAction)
            {
                _logAction = logAction;
            }

            public IDisposable BeginScope<TState>(TState state) => null;
            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(LogLevel logLevel, EventId eventId,
                                    TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                if (formatter != null)
                {

                    string message = formatter(state, exception);
                    _logAction?.Invoke($"[{DateTime.Now.ToString()}] [{logLevel}] {message}");
                }
            }
        }
    }
}
