using System.Threading.Tasks;
using Steam.Partner.BroadcastService.Types;
using Steam.Partner.Shared;

namespace Steam.Partner.BroadcastService;

public interface IBroadcastService
{
    /// <summary>
    /// Add a game meta data frame to broadcast
    /// </summary>
    public ValueTask PostGameDataFrame(SteamId sid, BroadcastId bid, string FrameData);
}