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
    public class XunitTestOutputLoggerProviderTest
    {
        public class CreateLogger
        {
            [Fact]
            public void Should_return_an_XunitTestOutputLogger()
            {
                // Arrange
                var outputMock = new Mock<ITestOutputHelper>();
                var sut = new XunitTestOutputLoggerProvider(outputMock.Object);

                // Act
                var logger = sut.CreateLogger("Test");

                // Assert
                var assertableLogger = Assert.IsType<XunitTestOutputLogger>(logger);
                Assert.Same(outputMock.Object, assertableLogger.Output);
            }
        }

    }
}
