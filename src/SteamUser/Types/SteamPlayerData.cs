using Newtonsoft.Json;
using Steam.Partner.Shared;

namespace Steam.Partner.SteamUser.Types;

public record SteamPlayerData
{
    [JsonProperty("steamid")]
    public SteamId SteamID { get; set; }
    [JsonProperty("personaname")]
    public string Name { get; set; }
    [JsonProperty("profileurl")]
    public string ProfileUrl { get; set; }
    [JsonProperty("avatar")]
    public string Avatar { get; set; }
}