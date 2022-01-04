namespace DiSampleApp.WebApi.Handlers;

using DiSampleApp.WebApi.Interfaces;
using DiSampleApp.WebApi.Query;

internal sealed class GetWeatherForecastsHandler : IRequestHandler<GetWeatherForecasts, IReadOnlyList<WeatherForecast>>
{
    private readonly IMyScopedService myScopedService;
    private readonly IMySingletonService mySingletonService;
    private readonly IMyTransientService myTransientService;
    private readonly ILogger<GetWeatherForecastsHandler> logger;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public GetWeatherForecastsHandler(ILogger<GetWeatherForecastsHandler> logger, IMyScopedService myScopedService, IMySingletonService mySingletonService, IMyTransientService myTransientService)
    {
        this.logger = logger;
        this.myScopedService = myScopedService;
        this.mySingletonService = mySingletonService;
        this.myTransientService = myTransientService;
    }

    public async Task<IReadOnlyList<WeatherForecast>> Handle(GetWeatherForecasts request, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("[H] Scoped: {TimeScoped}, Singleton: {TimeSingleton}, Transient: {TimeTransient}", this.myScopedService.Now, this.mySingletonService.Now, this.myTransientService.Now);

        var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList()
        .AsReadOnly();

        return await Task.FromResult(result);
    }
}