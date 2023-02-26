namespace Steam.Partner.LobbyApi.Enums;

/// <summary>
/// Lobby search filter options.
/// These can be set with AddRequestLobbyListStringFilter and AddRequestLobbyListNearValueFilter.
/// </summary>
public enum ELobbyComparison
{
    EqualToOrLessThan = -2,
    LessThan,
    Equal,
    GreaterThan,
    EqualToOrGreaterThan,
    NotEqual
}