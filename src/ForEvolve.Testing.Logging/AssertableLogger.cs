using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ForEvolve.Testing.Logging
{
    public class AssertableLogger : ILogger
    {
        public IList<string> Lines { get; }
        public AssertableLogger(IList<string> lines)
        {
            Lines = lines ?? throw new ArgumentNullException(nameof(lines));
        }

        public IDisposable BeginScope<TState>(TState state)
            => throw new NotSupportedException();

        public bool IsEnabled(LogLevel logLevel)
            => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            Lines.Add(message);
        }
    }
}
