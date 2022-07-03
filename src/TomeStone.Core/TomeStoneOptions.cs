namespace TomeStone.Core;

public class TomeStoneOptions
{
    public string BaseUrl { get; set; } = string.Empty;

    public XIVAPIAuth Auth { get; set; } = default!;

}

public class XIVAPIAuth
{
    public string APIKey { get; set; } = string.Empty;
}
