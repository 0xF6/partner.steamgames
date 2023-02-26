using Newtonsoft.Json;

namespace Steam.Partner;

internal class SteamApiBase
{
    protected static string InputJson(dynamic any) => JsonConvert.SerializeObject(any, Formatting.None);
}