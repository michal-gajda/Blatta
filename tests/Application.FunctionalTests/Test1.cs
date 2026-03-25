namespace Blatta.Application.FunctionalTests;

using Blatta.Application.Common;
using Blatta.Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

[TestClass]
public sealed class Test1 : TestBase
{
    [TestMethod]
    public async Task TestMethod1()
    {
        var bus = Provider.GetRequiredService<IBus>();
        var query = new GetWeatherForecasts();
        var result = await bus.Query<GetWeatherForecasts, List<Blatta.Application.QueryResults.WeatherForecast>>(query);
        result.ShouldNotBeEmpty();
    }
}
