using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Steam.Partner;

public class SteamConfig
{
    public ulong AppId { get; set; }
    public ulong ServerAppId { get; set; }
    public string PartnerApiKey { get; set; }
    public string ClassicApiKey { get; set; }
    public string ApiEndpoint { get; set; }
    public string PartnerEndpoint { get; set; }
}

public static class SteamConfigEx
{
    public static IServiceCollection AddSteamPartnerApi(this IServiceCollection collection, Func<SteamConfig>? setup = null)
    {
        collection.TryAdd(ServiceDescriptor.Singleton<ISteamPartnerApi, SteamPartnerApi>());
        collection.TryAdd(ServiceDescriptor.Singleton<SteamConfig>(provider =>
        {
            if (setup is not null)
                return setup();
            var config = provider.GetRequiredService<IConfiguration>();
            return config.GetSection("Steam").Get<SteamConfig>();
        }));
        return collection;
    }
}