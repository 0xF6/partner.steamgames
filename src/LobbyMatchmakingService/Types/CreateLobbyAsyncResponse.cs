using Newtonsoft.Json;

namespace Steam.Partner.LobbyApi.Types;

public record CreateLobbyAsyncResponse
{
    [JsonProperty("appid")]
    public long AppId { get; set; }
    [JsonProperty("steamid_lobby")]
    public ulong LobbyID { get; set; }
}