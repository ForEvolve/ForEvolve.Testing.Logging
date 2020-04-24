using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace ForEvolve.Testing.Logging
{
    public class XunitTestOutputLoggerProvider : ILoggerProvider
    {
        private readonly ITestOutputHelper _output;
        public XunitTestOutputLoggerProvider(ITestOutputHelper output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public ILogger CreateLogger(string categoryName)
            => new XunitTestOutputLogger(_output);

        public void Dispose() { }

    }
}
