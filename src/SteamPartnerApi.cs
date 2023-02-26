using System;
using Microsoft.Extensions.Logging;
using Steam.Partner.BroadcastService;
using Steam.Partner.CheatReportingApi;
using Steam.Partner.CloudService;
using Steam.Partner.EconMarketService;
using Steam.Partner.LobbyApi;
using Steam.Partner.SteamUser;

namespace Steam.Partner;

public class SteamPartnerApi : ISteamPartnerApi
{
    private readonly ILogger<SteamPartnerApi> _logger;
    private readonly SteamConfig _config;

    public SteamPartnerApi(ILogger<SteamPartnerApi> logger, SteamConfig config)
    {
        _logger = logger;
        _config = config;
    }

    public IBroadcastService Broadcast => throw new NotImplementedException();
    public ICheatReportingService CheatReporting => throw new NotImplementedException();
    public ILobbyMatchmakingService Matchmaking => new LobbyMatchmakingServiceImpl(_config, _logger);
    public ICloudService Cloud => throw new NotImplementedException();
    public ISteamUser User => new SteamUserImpl(_config, _logger);
    public IEconMarketService EconMarket => throw new NotImplementedException();
}

public interface ISteamPartnerApi
{
    IBroadcastService Broadcast { get; }
    ICheatReportingService CheatReporting { get; }
    ILobbyMatchmakingService Matchmaking { get; }
    ICloudService Cloud { get; }
    ISteamUser User { get; }
    IEconMarketService EconMarket { get; }
}