using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEvolve.Testing.Logging
{
    public class AssertableLoggerProvider : ILoggerProvider
    {
        private readonly IList<string> _lines;
        public AssertableLoggerProvider(IList<string> lines)
        {
            _lines = lines ?? throw new ArgumentNullException(nameof(lines));
        }

        public ILogger CreateLogger(string categoryName)
            => new AssertableLogger(_lines);

        public void Dispose() { }
    }
}
