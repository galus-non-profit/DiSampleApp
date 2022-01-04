namespace DiSampleApp.WebApi;

public sealed record GetWeatherForecasts : IRequest<IReadOnlyList<WeatherForecast>>
{
}
