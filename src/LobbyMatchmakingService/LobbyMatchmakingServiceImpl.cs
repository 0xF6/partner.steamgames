using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Steam.Partner.LobbyApi.Enums;
using Steam.Partner.LobbyApi.Types;

namespace Steam.Partner.LobbyApi;

internal class LobbyMatchmakingServiceImpl : SteamApiBase, ILobbyMatchmakingService
{
    private readonly SteamConfig _config;
    private readonly ILogger<SteamPartnerApi> _logger;

    public LobbyMatchmakingServiceImpl(SteamConfig config, ILogger<SteamPartnerApi> logger) 
        => (_config, _logger) = (config, logger);

    public async ValueTask<CreateLobbyAsyncResponse?> CreateLobby(int MaxMembers, ELobbyType LobbyType, string LobbyName, List<ulong> UserIds, List<SteamLobbyDataEntity>? metadata = default)
    {
        try
        {
            var result = await $"{_config.PartnerEndpoint}/{nameof(ILobbyMatchmakingService)}/{nameof(CreateLobby)}/v1/"
                .SetQueryParam("appid", _config.AppId)
                .SetQueryParam("key", _config.PartnerApiKey)
                .SetQueryParam("input_json", InputJson(new
                {
                    max_members = MaxMembers,
                    lobby_type = 4,
                    lobby_name = LobbyName,
                    steamid_invited_members = UserIds.ToArray(),
                    lobby_metadata = metadata?.ToArray()
                })).AllowAnyHttpStatus().PostAsync();
            var str = await result.GetStringAsync();
            // the shit
            return JToken.Parse(str)["response"]!.ToObject<CreateLobbyAsyncResponse>();
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "ILobbyMatchmakingService::CreateLobby failed");
            return null;
        }
    }

    public async ValueTask RemoveUserFromLobby(ulong lobbyId, ulong steamId)
    {
        try
        {
            await $"{_config.PartnerEndpoint}/{nameof(ILobbyMatchmakingService)}/{nameof(CreateLobby)}/v1/"
                .SetQueryParam("appid", _config.AppId)
                .SetQueryParam("key", _config.PartnerApiKey)
                .SetQueryParam("input_json", InputJson(new
                {
                    steamid_to_remove = steamId,
                    steamid_lobby = lobbyId
                })).PostAsync();
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "ILobbyMatchmakingService::RemoveUserFromLobby failed");
            throw;
        }
    }
}


public interface ILobbyMatchmakingService
{
    public ValueTask<CreateLobbyAsyncResponse?> CreateLobby(int MaxMembers, ELobbyType LobbyType,
        string LobbyName, List<ulong> UserIds, List<SteamLobbyDataEntity>? metadata = default);

    public ValueTask RemoveUserFromLobby(ulong lobbyId, ulong steamId);
}