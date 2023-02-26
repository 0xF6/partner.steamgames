using System.Threading.Tasks;
using Newtonsoft.Json;
using Steam.Partner.EconMarketService.Types;
using Steam.Partner.Shared;

namespace Steam.Partner.EconMarketService;

/// <summary>
/// Provides restricted access to the Steam Market for partners.
/// </summary>
public interface IEconMarketService
{
    /// <summary>
    /// Checks whether or not an account is allowed to use the market
    /// </summary>
    /// <param name="steamId">The SteamID of the user to check</param>
    /// <example>
    /// {
    /// "response": {
    /// "allowed": true,
    /// "reason": 0,
    /// "allowed_at_time": 0,
    /// "steamguard_required_days": 15,
    /// "new_device_cooldown_days": 0
    /// }
    /// }
    /// </example>
    public ValueTask<MarketEligibilityEntity> GetMarketEligibility(SteamId steamId);

}



