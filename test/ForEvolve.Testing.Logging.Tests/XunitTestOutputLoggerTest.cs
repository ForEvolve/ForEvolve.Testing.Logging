using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ForEvolve.Testing.Logging
{
    public class XunitTestOutputLoggerTest
    {
        public class Log
        {
            [Fact]
            public void Should_WriteLine_to_ITestOutputHelper()
            {
                // Arrange
                var outputMock = new Mock<ITestOutputHelper>();
                var sut = new XunitTestOutputLogger(outputMock.Object);

                // Act
                sut.Log(
                    logLevel: LogLevel.Error,
                    eventId: 1,
                    state: "Some message",
                    exception: new Exception("Exception message"),
                    formatter: (s, e) => "Output"
                );

                // Assert
                outputMock.Verify(x => x.WriteLine("Output"));
            }
        }

        public class IsEnabled
        {
            [Fact]
            public void Should_return_true()
            {
                var outputMock = new Mock<ITestOutputHelper>();
                var sut = new XunitTestOutputLogger(outputMock.Object);
                Assert.True(sut.IsEnabled(LogLevel.None));
            }
        }

        public class BeginScope
        {
            [Fact]
            public void Should_throw_a_NotSupportedException()
            {
                var outputMock = new Mock<ITestOutputHelper>();
                var sut = new XunitTestOutputLogger(outputMock.Object);
                Assert.Throws<NotSupportedException>(() => sut.BeginScope(default(object)));
            }
        }
    }
}
