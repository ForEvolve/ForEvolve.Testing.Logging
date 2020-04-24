using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ForEvolve.Testing.Logging
{
    public class AssertableLoggerProviderTest
    {
        public class CreateLogger
        {
            [Fact]
            public void Should_return_an_AssertableLogger()
            {
                // Arrange
                var lines = new List<string>();
                var sut = new AssertableLoggerProvider(lines);

                // Act
                var logger = sut.CreateLogger("Test");

                // Assert
                var assertableLogger = Assert.IsType<AssertableLogger>(logger);
                Assert.Same(lines, assertableLogger.Lines);
            }
        }
    }
}
