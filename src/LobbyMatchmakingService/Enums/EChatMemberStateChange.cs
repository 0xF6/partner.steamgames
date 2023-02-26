using System;

namespace Steam.Partner.LobbyApi.Enums;

/// <summary>
/// Flags describing how a users lobby state has changed.
/// This is provided from LobbyChatUpdate_t.
/// </summary>
[Flags]
public enum EChatMemberStateChange
{
    /// <summary>
    /// This user has joined or is joining the lobby.
    /// </summary>
    Entered = 0x0001,
    /// <summary>
    /// This user has left or is leaving the lobby.
    /// </summary>
    Left = 0x0002,
    /// <summary>
    /// User disconnected without leaving the lobby first.
    /// </summary>
    Disconnected = 0x0004,
    /// <summary>
    /// The user has been kicked.
    /// </summary>
    Kicked = 0x0008,
    /// <summary>
    /// The user has been kicked and banned.
    /// </summary>
    Banned = 0x0010
}