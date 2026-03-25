namespace Blatta.Application.QueryResults;

using Blatta.Application.Common;

public sealed record class WeatherForecast
{
    public required DateOnly Date { get; init; }

    public required int TemperatureC { get; init; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; init; }
}
