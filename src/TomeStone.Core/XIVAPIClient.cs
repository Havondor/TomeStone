using System.Net.Http.Json;
using Microsoft.Extensions.Options;

namespace TomeStone.Core;

public interface IXIVAPIClient
{
    Task<T?> GetXIVAPIAsync<T>(string path);
}

public class XIVAPIClient : IXIVAPIClient
{
    private readonly HttpClient _httpClient;
    private readonly TomeStoneOptions _options;
    private readonly string _apiKey;

    public XIVAPIClient(HttpClient httpClient, IOptions<TomeStoneOptions> options)
    {
        _httpClient = httpClient;
        _options = options?.Value ?? throw new ArgumentNullException(nameof(TomeStoneOptions));
        _apiKey = _options.Auth.APIKey;

        _httpClient.BaseAddress = new Uri(_options.BaseUrl);
    }

    public async Task<T?> GetXIVAPIAsync<T>(string path) =>
        await _httpClient.GetFromJsonAsync<T>(path);

}
