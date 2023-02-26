using Newtonsoft.Json;

namespace Steam.Partner.LobbyApi.Types;

public record SteamLobbyDataEntity(
    [JsonProperty("key_name")] string Key,
    [JsonProperty("key_value")] string Value);