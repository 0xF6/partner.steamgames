using Newtonsoft.Json;
using System.Collections.Generic;

namespace Steam.Partner.SteamUser.Types;

public record GetPlayerSummariesResponse
{
    [JsonProperty("players")]
    public List<SteamPlayerData> Players { get; set; }
}