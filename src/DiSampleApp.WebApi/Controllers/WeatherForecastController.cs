namespace DiSampleApp.WebApi.Controllers;

using DiSampleApp.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController, Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMyScopedService myScopedService;
    private readonly IMySingletonService mySingletonService;
    private readonly IMyTransientService myTransientService;
    private readonly IMediator mediator;
    private readonly ILogger<WeatherForecastController> logger;

    public WeatherForecastController(IMediator mediator, ILogger<WeatherForecastController> logger, IMyScopedService myScopedService, IMySingletonService mySingletonService, IMyTransientService myTransientService)
    {
        this.mediator = mediator;
        this.logger = logger;
        this.myScopedService = myScopedService;
        this.mySingletonService = mySingletonService;
        this.myTransientService = myTransientService;//https://localhost:7256/swagger/index.html
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IReadOnlyList<WeatherForecast>> Get()
    {
        this.logger.LogInformation("Scoped: {TimeScoped}, Singleton: {TimeSingleton}, Transient: {TimeTransient}", this.myScopedService.Now, this.mySingletonService.Now, this.myTransientService.Now);

        Thread.Sleep(1000);

        var result = await this.mediator.Send(new GetWeatherForecasts());

        this.logger.LogInformation("Scoped: {TimeScoped}, Singleton: {TimeSingleton}, Transient: {TimeTransient}", this.myScopedService.Now, this.mySingletonService.Now, this.myTransientService.Now);

        return await Task.FromResult(result);
    }
}
