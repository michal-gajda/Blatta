namespace Blatta.Application.Queries;

using Blatta.Application.Common;
using Blatta.Application.QueryResults;

public sealed record class GetWeatherForecasts : IQuery<List<WeatherForecast>>
{
}
