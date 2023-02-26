namespace Steam.Partner.LobbyApi.Enums;

/// <summary>
/// Lobby search distance filters when requesting the lobby list.
/// Lobby results are sorted from closest to farthest.
/// This can be set with AddRequestLobbyListDistanceFilter.
/// </summary>
public enum ELobbyDistanceFilter
{
    /// <summary>
    /// Only lobbies in the same immediate region will be returned.
    /// </summary>
    Close = 0,
    /// <summary>
    /// Only lobbies in the same region or nearby regions will be returned.
    /// </summary>
    Default,
    /// <summary>
    /// For games that don't have many latency requirements, will return lobbies about half-way around the globe.
    /// </summary>
    Far,
    /// <summary>
    /// No filtering, will match lobbies as far as India to NY (not recommended, expect multiple seconds of latency between the clients).
    /// </summary>
    Worldwide
}