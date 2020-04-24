using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace ForEvolve.Testing.Logging
{
    public static class XunitTestOutputLoggingBuilderExtensions
    {
        public static ILoggingBuilder AddxUnitTestOutput(this ILoggingBuilder builder, ITestOutputHelper output)
        {
            return builder.AddProvider(new XunitTestOutputLoggerProvider(output));
        }
    }
}
