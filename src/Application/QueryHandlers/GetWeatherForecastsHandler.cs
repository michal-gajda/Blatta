namespace Blatta.Application.QueryHandlers;

using Blatta.Application.Common;
using Blatta.Application.Queries;
using Blatta.Application.QueryResults;

public sealed class GetWeatherForecastsHandler : IQueryHandler<GetWeatherForecasts, List<WeatherForecast>>
{
    public Task<List<WeatherForecast>> Handle(GetWeatherForecasts request, CancellationToken cancellationToken)
    {
        var rng = new Random();
        var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        }).ToList();

        return Task.FromResult(forecasts);
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
}