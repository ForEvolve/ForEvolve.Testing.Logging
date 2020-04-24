using ForEvolve.Testing.Logging;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Microsoft.Extensions.Logging
{
    public static class XunitTestOutputLoggingBuilderExtensions
    {
        public static ILoggingBuilder AddxUnitTestOutput(this ILoggingBuilder builder, ITestOutputHelper output)
        {
            return builder.AddProvider(new XunitTestOutputLoggerProvider(output));
        }
    }
}
