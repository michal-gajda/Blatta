namespace Blatta.WebApi.Controllers;

using Blatta.Application.Common;
using Blatta.Application.Queries;
using Blatta.Application.QueryResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public sealed class WeatherForecastController(IBus bus) : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> GetAsync(CancellationToken cancellationToken) => await bus.Query<GetWeatherForecasts, List<WeatherForecast>>(new GetWeatherForecasts(), cancellationToken);
}
