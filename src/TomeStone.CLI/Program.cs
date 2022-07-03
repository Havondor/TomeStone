using TomeStone.CLI;
using TomeStone.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;


static void ConfigureServices(IServiceCollection services)
{
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .AddEnvironmentVariables();
        

    if (env == "Development")
    {
        builder.AddUserSecrets<Program>();
    }


    IConfigurationRoot? config = builder.Build();

    services.AddHttpClient<IXIVAPIClient, XIVAPIClient>();

    services.Configure<TomeStoneOptions>(config.GetSection("XIVAPI"));

    services.AddTransient<ITomeStoneCLI, TomeStoneCLI>();
}


var Services = new ServiceCollection();
ConfigureServices(Services);

using var ServiceProvider = Services.BuildServiceProvider();

await ServiceProvider.GetService<ITomeStoneCLI>()!.Run(args);
