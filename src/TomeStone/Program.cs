using TomeStone;
using TomeStone.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


static void ConfigureServices(IServiceCollection services)
{
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONNMENT");

    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .AddEnvironmentVariables();

    if (env == "Development")
    {
        builder.AddUserSecrets<Program>();
    }

    var config = builder.Build();

    services.Configure<TomeStoneOptions>(config.GetSection("XIVAPI"));

    services.AddTransient<IApp, App>();
}


var Services = new ServiceCollection();
ConfigureServices(Services);

using var ServiceProvider = Services.BuildServiceProvider();

await ServiceProvider.GetService<IApp>()!.Run(args);