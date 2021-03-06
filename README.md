# ForEvolve.Testing.Logging

![Build, Test, and Deploy master to feedz.io](https://github.com/ForEvolve/ForEvolve.Testing.Logging/workflows/Build,%20Test,%20and%20Deploy%20master%20to%20feedz.io/badge.svg)
[![feedz.io](https://img.shields.io/badge/endpoint.svg?url=https%3A%2F%2Ff.feedz.io%2Fforevolve%2Ftesting%2Fshield%2FForEvolve.Testing.Logging%2Flatest)](https://f.feedz.io/forevolve/testing/packages/ForEvolve.Testing.Logging/latest/download)
[![NuGet.org](https://img.shields.io/nuget/vpre/ForEvolve.Testing.Logging)](https://www.nuget.org/packages/ForEvolve.Testing.Logging/)

Contains xUnit logging utilities, like:

-   Adds and `AssertableLoggerProvider` that forward logs to an `IList<string>` object, making it easy to assert its content.
-   Adds an `XunitTestOutputLoggerProvider` that forward logs to xUnit `ITestOutputHelper`.

# Install

```
dotnet add package ForEvolve.Testing.Logging
```

# How to use

## AssertableLoggerProvider

In your test method, create a `IList<string>` then register the logging provider, with your `IHostBuilder` like:

```csharp
public class BaseAbstractions
{
    [Fact]
    public void Should_log_the_Service_Execute_line()
    {
        // Arrange
        var lines = new List<string>();
        var args = new string[0];
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddAssertableLogger(lines);
            })
            .ConfigureServices(services =>
            {
                services.AddSingleton<IService, Service>();
            })
            .Build();
        var service = host.Services.GetRequiredService<IService>();

        // Act
        service.Execute();

        // Assert
        Assert.Collection(lines,
            line => Assert.Equal("Service.Execute()", line)
        );
    }

    public interface IService
    {
        void Execute();
    }

    public class Service : IService
    {
        private readonly ILogger _logger;
        public Service(ILogger<Service> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Execute()
        {
            _logger.LogInformation("Service.Execute()");
        }
    }
}
```

Take into consideration that in more complex tests, more logs could be sent to the logger (like system logs). Filtering logs could be a good strategy there.

## XunitTestOutputLoggerProvider

In your test class, you must inject an `ITestOutputHelper`, then register the logging provider, with your `IHostBuilder` like:

```csharp
public class ProvidersTest
{
    private readonly ITestOutputHelper _output;
    public Providers(ITestOutputHelper output)
    {
        _output = output ?? throw new ArgumentNullException(nameof(output));
    }

    [Fact]
    public async Task CustomizeProvidersAsync()
    {
        var args = new string[0];
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureLogging(loggingBuilder =>
            {
                loggingBuilder.AddxUnitTestOutput(_output);
            })
            .Build();
        var tokenSource = new CancellationTokenSource(1000);
        await host.RunAsync(tokenSource.Token);
    }
}
```

Running that test should output something like:

```
Application started. Press Ctrl+C to shut down.
Hosting environment: Production
Content root path: [the path of your project]\bin\Debug\net5.0
Application is shutting down...
```

# Found a bug or have a feature request?

Please open an issue and be as clear as possible; see _How to contribute?_ for more information.

# How to contribute?

If you would like to contribute to the project, first, thank you for your interest, and please read [Contributing to ForEvolve open source projects](https://github.com/ForEvolve/ForEvolve.DependencyInjection/tree/master/CONTRIBUTING.md) for more information.

## Contributor Covenant Code of Conduct

Also, please read the [Contributor Covenant Code of Conduct](https://github.com/ForEvolve/ForEvolve.DependencyInjection/tree/master/CODE_OF_CONDUCT.md) that applies to all ForEvolve repositories.
