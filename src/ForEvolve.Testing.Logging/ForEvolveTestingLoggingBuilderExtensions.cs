using ForEvolve.Testing.Logging;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Microsoft.Extensions.Logging
{
    public static class ForEvolveTestingLoggingBuilderExtensions
    {
        public static ILoggingBuilder AddxUnitTestOutput(this ILoggingBuilder builder, ITestOutputHelper output)
        {
            return builder.AddProvider(new XunitTestOutputLoggerProvider(output));
        }

        public static ILoggingBuilder AddAssertableLogger(this ILoggingBuilder builder, IList<string> output)
        {
            return builder.AddProvider(new AssertableLoggerProvider(output));
        }
    }
}
