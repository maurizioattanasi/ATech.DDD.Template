using System.Globalization;
using ATech.DDD.Template.Api;
using ATech.DDD.Template.Application;
using ATech.DDD.Template.Infrastructure;
using FastEndpoints;
using Serilog;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

var configurationBuilder = new ConfigurationBuilder();

if (environment.ToLower() == "development")
{
    configurationBuilder.AddUserSecrets<Program>();
}

var configuration = configurationBuilder
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));

{
    builder
        .Services
        .AddPresentation()
        .AddApplication(configuration)
        .AddInfrastructure(configuration)
        ;
}

var app = builder.Build();

{
    app
        .UseFastEndpoints()
        // .UseSwaggerGen()
        ;
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();
