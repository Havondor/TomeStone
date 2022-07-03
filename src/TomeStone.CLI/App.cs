using System.Text.Json.Nodes;
using Microsoft.Extensions.Options;
using TomeStone.Core;

namespace TomeStone.CLI;

internal interface ITomeStoneCLI
{
    Task Run(string[] args);
}

internal class TomeStoneCLI : ITomeStoneCLI
{
    private readonly TomeStoneOptions _options;
    private readonly IXIVAPIClient _client;

    public TomeStoneCLI(IXIVAPIClient client, IOptions<TomeStoneOptions> options)
    {
        _options = options?.Value ?? throw new ArgumentNullException(nameof(TomeStoneOptions));
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task Run(string[] args)
    {
        JsonNode? response = await _client.GetXIVAPIAsync<JsonNode>($"/character/8451553?private_key={_options.Auth.APIKey}&extended=1");

        Console.WriteLine(response!["Character"]!["Name"]);
    }

}
