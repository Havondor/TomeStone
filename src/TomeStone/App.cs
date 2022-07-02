using Microsoft.Extensions.Options;
using TomeStone.Core;

namespace TomeStone;

internal interface IApp
{
    Task Run(string[] args);
}

internal class App : IApp
{
    private readonly TomeStoneOptions _options;
    public App(IOptions<TomeStoneOptions> options)
    {
        _options = options?.Value ?? throw new ArgumentNullException(nameof(TomeStoneOptions));
    }

    public async Task Run(string[] args)
    {
        Console.WriteLine(_options.BaseUrl);
    }

}
