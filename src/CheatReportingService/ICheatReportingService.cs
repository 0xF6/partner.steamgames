using System.Threading.Tasks;
using System;
using Steam.Partner.Shared;
using Steam.Partner.CheatReportingService.Types;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace Steam.Partner.CheatReportingApi;

/// <summary>
/// ReportPlayerCheating is designed to gather community reports of cheating, where one player reports another player within the game.
///
/// It is intended for unreliable data from peers in the game(semi-trusted sources).
/// The back-end that reports the data should ensure that both parties are authenticated,
/// but the data in itself is treated as hearsay.Optional parameters
/// may be used to encode the type of cheating that is suspected or additional evidence(an identifier pointing to the match/demo for further review)
/// </summary>
public interface ICheatReportingService
{
    /// <param name="range">
    /// The end and the start of the time range. Formatted as Unix epoch time (time since Jan 1st, 1970).
    /// </param>
    /// <param name="reportIdMin">
    /// Minimum reportID to include. (can pass 0 - end of previous report range)
    /// </param>
    /// <param name="includeReports">
    /// (Optional) Include reports. If false includebans must be true.
    /// </param>
    /// <param name="includeBans">
    /// (Optional) Include ban requests? If false includereports must be true.
    /// </param>
    /// <param name="steamId">
    /// (Optional) Query just for this Steam ID.
    /// </param>
    [Obsolete("Not completed api, do not use")]
    public ValueTask GetCheatingReports(DateTimeOffsetRange range, uint reportIdMin, bool? includeReports = null, bool? includeBans = null, SteamId? steamId = null);

    /// <summary>
    /// Requests a game ban on a specific player.
    /// This is designed to be used after the incidents from ReportPlayerCheating have been reviewed and cheating has been confirmed.
    /// </summary>
    /// <param name="user"> Steam ID of the user who is reported as cheating. </param>
    /// <param name="report"> The reportid originally used to report cheating. </param>
    /// <param name="desc"> Text describing cheating infraction. </param>
    /// <param name="duration"> Ban duration requested in seconds. (duration null will issue infinite - less than a year is a suspension and not visible on profile) </param>
    /// <param name="isDelay"> Delay the ban according to default ban delay rules. </param>
    /// <param name="flags"> Additional information about the ban request. (Unused) </param>
    /// <returns>if banned - true</returns>
    public ValueTask<bool> RequestPlayerGameBan(SteamId user, ReportId report, string desc, TimeSpan? duration, bool isDelay,
        uint flags);

    /// <summary>
    /// Remove a game ban on a player.
    /// This is used if a Game ban is determined to be a false positive.
    /// </summary>
    /// <param name="user">The Steam ID of the user to remove the game ban on.</param>
    /// <returns>if ban removed - true</returns>
    public ValueTask<bool> RemovePlayerGameBan(SteamId user);
}

internal class CheatReportingServiceImpl : SteamApiBase, ICheatReportingService
{
    private readonly SteamConfig _config;
    private readonly ILogger<SteamPartnerApi> _logger;

    public CheatReportingServiceImpl(SteamConfig config, ILogger<SteamPartnerApi> logger)
        => (_config, _logger) = (config, logger);

    public ValueTask GetCheatingReports(DateTimeOffsetRange range, uint reportIdMin, bool? includeReports = null,
        bool? includeBans = null, SteamId? steamId = null)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> RequestPlayerGameBan(SteamId steamid, ReportId reportid, string cheatdescription, TimeSpan? duration, bool delayban,
        uint flags)
    {
        try
        {
            var result = await $"{_config.PartnerEndpoint}/{nameof(ICheatReportingService)}/{nameof(RequestPlayerGameBan)}/v1/"
                .SetQueryParam("appid", _config.AppId)
                .SetQueryParam("key", _config.PartnerApiKey)
                .SetQueryParam(nameof(steamid), steamid)
                .SetQueryParam(nameof(reportid), reportid)
                .SetQueryParam(nameof(cheatdescription), cheatdescription)
                .SetQueryParam(nameof(duration), duration == null ? 0 : (int)duration.Value.TotalSeconds)
                .SetQueryParam(nameof(delayban), delayban)
                .SetQueryParam(nameof(flags), flags)
                .AllowAnyHttpStatus().PostAsync();
            var str = await result.GetStringAsync();
            // the shit
            return JToken.Parse(str)["response"]?["steamid"]?.HasValues ?? false;
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "ICheatReportingService::RequestPlayerGameBan failed");
            return false;
        }
    }

    public async ValueTask<bool> RemovePlayerGameBan(SteamId steamid)
    {
        try
        {
            var result = await $"{_config.PartnerEndpoint}/{nameof(ICheatReportingService)}/{nameof(RemovePlayerGameBan)}/v1/"
                .SetQueryParam("appid", _config.AppId)
                .SetQueryParam("key", _config.PartnerApiKey)
                .SetQueryParam(nameof(steamid), steamid)
                .AllowAnyHttpStatus().PostAsync();
            var str = await result.GetStringAsync();
            // the shit
            return JToken.Parse(str)["response"]?["steamid"]?.HasValues ?? false;
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "ICheatReportingService::RequestPlayerGameBan failed");
            return false;
        }
    }
}