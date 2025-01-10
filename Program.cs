

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Write logs to console 
    .WriteTo.File("Logs/log-.txt",  // Logs to file
    rollingInterval: RollingInterval.Day)
    .CreateLogger();

// 2. Replace default .NET logger with Serilog
builder.Host.UseSerilog(Log.Logger);

var app = builder.Build();

// 3. Add a simple endpoint to test logging
app.MapGet("/", () =>
{
    // Using the built-in logging abstraction (Ilogger<Program>)
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Hello from ASP.NET Core with Serilog!");
    return "Hello from ASP.NET Core with Serilog!";
});

// 4. Test an error log
app.MapGet("/error", () =>
{
    throw new Exception("Test exception to be logged by Serilog");
});

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionHandlerPathFeature = 

        context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();

        // Injecting the logger instance
        var logger = app.Services.GetRequiredService<ILogger<Program>>();

        logger.LogError(exceptionHandlerPathFeature.Error, "An error occurred while processing your request.");

        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("An error occurred while processing your request.");
    });

});

app.Run();
