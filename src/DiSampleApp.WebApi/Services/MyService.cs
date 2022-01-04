namespace DiSampleApp.WebApi.Services;

using System;
using DiSampleApp.WebApi.Interfaces;

public sealed class MyService : IMyScopedService, IMySingletonService, IMyTransientService
{
    private readonly DateTime dateTime;
    private readonly ILogger<MyService> logger;

    public MyService(ILogger<MyService> logger)
    {
        this.logger = logger;
        this.dateTime = DateTime.Now;
        this.logger.LogInformation("[C] Time: {Time}", DateTime.Now);
    }

    public DateTime Now => this.dateTime;
}
