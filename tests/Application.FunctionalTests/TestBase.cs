namespace Blatta.Application.FunctionalTests;

using Blatta.Application;
using Blatta.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public abstract class TestBase : IDisposable
{
    protected ServiceProvider Provider { get; init; }

    public TestBase()
    {
        var collation = new Dictionary<string, string?>
        {
            {"Logging:LogLevel:Default","Information"},
        };
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(collation)
            .Build();
        var services = new ServiceCollection();
        services.AddSingleton(configuration);
        services.AddApplication();
        services.AddInfrastructure(configuration);
        this.Provider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
        Provider?.Dispose();
        GC.SuppressFinalize(this);
    }
}
