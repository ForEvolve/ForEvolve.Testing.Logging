using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEvolve.Testing.Logging
{
    public class AssertableLoggerProvider : ILoggerProvider
    {
        private readonly IList<string> _lines;
        public AssertableLoggerProvider(IList<string> lines)
        {
            _lines = lines ?? throw new ArgumentNullException(nameof(lines));
        }

        public ILogger CreateLogger(string categoryName)
            => new AssertableLogger(_lines);

        public void Dispose() { }
    }

    public class AssertableLogger : ILogger
    {
        private readonly IList<string> _lines;
        public AssertableLogger(IList<string> lines)
        {
            _lines = lines ?? throw new ArgumentNullException(nameof(lines));
        }

        public IDisposable BeginScope<TState>(TState state)
            => throw new NotSupportedException();

        public bool IsEnabled(LogLevel logLevel)
            => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            _lines.Add(message);
        }
    }
}
