namespace Blatta.Application.FunctionalTests;

using Blatta.Application.Common;
using Blatta.Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

[TestClass]
public sealed class GetWeatherForecastsTests : TestBase
{
    [TestMethod]
    public async Task Query_returns_forecasts()
    {
        using var scope = Provider.CreateScope();
        var bus = scope.ServiceProvider.GetRequiredService<IBus>();

        var result = await bus.Query<GetWeatherForecasts, List<Blatta.Application.QueryResults.WeatherForecast>>(new GetWeatherForecasts());

        result.ShouldNotBeEmpty();
    }
}