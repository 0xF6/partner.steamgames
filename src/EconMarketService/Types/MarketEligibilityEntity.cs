using Newtonsoft.Json;

namespace Steam.Partner.EconMarketService.Types;

public class MarketEligibilityEntity
{
    [JsonProperty("allowed")]
    public bool IsAllowed { get; set; }
    [JsonProperty("reason")]
    public int Reason { get; set; } // TODO
    [JsonProperty("allowed_at_time")]
    public long AllowedAtTime { get; set; }
    [JsonProperty("steamguard_required_days")]
    public long SteamGuardRequiredDays { get; set; }
    [JsonProperty("new_device_cooldown_days")]
    public long NewDeviceCooldownDays { get; set; }
}