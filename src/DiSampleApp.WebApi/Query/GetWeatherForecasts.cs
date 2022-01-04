namespace DiSampleApp.WebApi.Query;

public sealed record GetWeatherForecasts : IRequest<IReadOnlyList<WeatherForecast>>
{
}
