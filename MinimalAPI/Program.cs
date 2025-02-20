using ProjectManagement.Contracts;
using ProjectManagement.LoggingService;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration));
builder.Services.AddSingleton<ICustomLogger, CustomLogger>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("test/", delegate (ICustomLogger logger)
{
    logger.LogInformation("Test log information");
    logger.LogWarning("Test log warning");
    logger.LogError("Test log error");
    logger.LogDebug("Test log debug");
    return Results.Ok();
});

app.Run();