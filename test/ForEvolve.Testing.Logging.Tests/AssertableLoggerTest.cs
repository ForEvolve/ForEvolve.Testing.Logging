using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ForEvolve.Testing.Logging
{
    public class AssertableLoggerTest
    {
        public class Log
        {
            [Fact]
            public void Should_add_log_entry_to_Lines()
            {
                // Arrange
                var lines = new List<string>();
                var sut = new AssertableLogger(lines);

                // Act
                sut.Log(
                    logLevel: LogLevel.Error,
                    eventId: 1,
                    state: "Some message",
                    exception: new Exception("Exception message"),
                    formatter: (s, e) => "Output"
                );

                // Assert
                Assert.Collection(lines,
                    line => Assert.Equal("Output", line)
                );
            }
        }

        public class IsEnabled
        {
            [Fact]
            public void Should_return_true()
            {
                var lines = new List<string>();
                var sut = new AssertableLogger(lines);
                Assert.True(sut.IsEnabled(LogLevel.None));
            }
        }

        public class BeginScope
        {
            [Fact]
            public void Should_throw_a_NotSupportedException()
            {
                var lines = new List<string>();
                var sut = new AssertableLogger(lines);
                Assert.Throws<NotSupportedException>(() => sut.BeginScope(default(object)));
            }
        }
    }
}
