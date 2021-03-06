﻿using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace ForEvolve.Testing.Logging
{
    public class XunitTestOutputLogger : ILogger
    {
        public ITestOutputHelper Output { get; }
        public XunitTestOutputLogger(ITestOutputHelper output)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public IDisposable BeginScope<TState>(TState state)
            => throw new NotSupportedException();

        public bool IsEnabled(LogLevel logLevel)
            => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            Output.WriteLine(message);
        }
    }
}
