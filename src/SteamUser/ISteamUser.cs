using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Steam.Partner.Shared;
using Steam.Partner.SteamUser.Types;

namespace Steam.Partner.SteamUser;

public interface ISteamUser
{
    ValueTask<GetPlayerSummariesResponse> GetPlayerSummaries(List<SteamId> steamIds);
    ValueTask<SteamPlayerData> GetPlayerSummaries(SteamId steamId);
}

internal class SteamUserImpl : ISteamUser
{
    private readonly SteamConfig _config;
    private readonly ILogger<SteamPartnerApi> _logger;

    public SteamUserImpl(SteamConfig config, ILogger<SteamPartnerApi> logger)
        => (_config, _logger) = (config, logger);

    public async ValueTask<GetPlayerSummariesResponse> GetPlayerSummaries(List<SteamId> steamIds)
    {
        try
        {
            var result = await $"{_config.PartnerEndpoint}/{nameof(ISteamUser)}/{nameof(GetPlayerSummaries)}/v2/"
                .SetQueryParam("key", _config.PartnerApiKey)
                .SetQueryParam("steamids", string.Join(',', steamIds)).GetAsync();
            var str = await result.GetStringAsync();
            return JToken.Parse(str)["response"].ToObject<GetPlayerSummariesResponse>();
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "ISteamUser::GetPlayerSummaries failed");
            throw;
        }
    }


    public async ValueTask<SteamPlayerData> GetPlayerSummaries(SteamId steamId)
    {
        var result = await GetPlayerSummaries(new List<SteamId> { steamId });

        return result.Players.First();
    }
}