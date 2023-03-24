using Template.Api.Modules.Abstractions;
using Template.Dto;
using Template.Entities;

namespace Template.Api.Modules;

public class WeatherForecastModule : Module<WeatherForecastModule>
{
    private readonly string[] summaries = new[]
    {
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching"
    };

    public WeatherForecastModule(ILogger<WeatherForecastModule> logger)
        : base(logger) { }

    public override void MapEndpoints(IEndpointRouteBuilder builder)
    {
        builder
            .MapGet("/weather-forecast", GetWeatherForecast)
            .WithName("GetWeatherForecast")
            .WithOpenApi();

        builder.MapGet("ping", Pong).WithName("PingPong").WithOpenApi();
    }

    private WeatherForecastDto[] GetWeatherForecast()
    {
        return Enumerable
            .Range(1, 5)
            .Select(index =>
            {
                WeatherForecast wf =
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.UtcNow,
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Summary = summaries[Random.Shared.Next(summaries.Length)],
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Updated = DateTime.UtcNow
                    };

                return new WeatherForecastDto(wf.Date, wf.TemperatureC, wf.Summary);
            })
            .ToArray();
    }

    private IResult Pong()
    {
        return Results.Ok(new { Pong = "pong" });
    }
}
