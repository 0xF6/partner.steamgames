namespace Steam.Partner.LobbyApi.Enums;

/// <summary>
/// Specifies the lobby type, this is set from CreateLobby and SetLobbyType.
/// </summary>
public enum ELobbyType
{
    /// <summary>
    /// The only way to join the lobby is from an invite.
    /// </summary>
    Private = 0,
    /// <summary>
    /// Joinable by friends and invitees, but does not show up in the lobby list.
    /// </summary>
    FriendsOnly,
    /// <summary>
    /// Returned by search and visible to friends.
    /// </summary>
    Public,
    /// <summary>
    /// Returned by search, but not visible to other friends.
    /// This is useful if you want a user in two lobbies, for example matching groups together.
    /// A user can be in only one regular lobby, and up to two invisible lobbies.
    /// </summary>
    Invisible
}