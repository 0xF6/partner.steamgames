<!-- Name -->
<h1 align="center">
  🧱 partner.steamgames 🧱
</h1>
<!-- desc -->
<h4 align="center">
  C# bindings for Steam Partner WebApi
</h4>

<!-- classic badges -->
<p align="center">
  <a href="#">
    <img src="http://img.shields.io/:license-MIT-blue.svg">
  </a>
  <a href="https://github.com/0xF6/partner.steamgames/releases">
    <img src="https://img.shields.io/github/release/0xF6/partner.steamgames.svg?logo=github&style=flat">
  </a>
</p>

<!-- popup badges -->
<p align="center">
  <a href="https://t.me/ivysola">
    <img src="https://img.shields.io/badge/Ask%20Me-Anything-1f425f.svg?style=popout-square&logo=telegram">
  </a>
  <a href="https://www.nuget.org/packages/partner.steamgames/">
    <img alt="Nuget" src="https://img.shields.io/nuget/v/partner.steamgames.svg?color=%23884499">
  </a>
</p>

<!-- big badges -->
<p align="center">
  <a href="#">
    <img src="https://forthebadge.com/images/badges/made-with-c-sharp.svg">
    <img src="https://forthebadge.com/images/badges/powered-by-oxygen.svg">
  </a>
</p>

### Usage

```csharp
public class SampleClass 
{
    private readonly ISteamPartnerApi steamApi;
    public SampleClass(ISteamPartnerApi SteamApi) => this.steamApi = SteamApi;


    public async ValueTask CreateLobby(SteamId id)
    {
        await this.steamApi.Matchmaking.CreateLobby(32, ELobbyType.Public, "Test Name", new List<ulong> { steamId });
    }
}

// in DI configure


services.AddSteamPartnerApi();
```

#### in appsettings.json

```json
{
  "Logging": { ... },
  },
  "Steam": {
    "PartnerApiKey": "Your Partner Api Key",
    "ClassicApiKey": "Your Steam Api Key",
    "AppId": 730,
    "ServerAppId": 740,
    "ApiEndpoint": "https://api.steampowered.com",
    "PartnerEndpoint": "https://partner.steam-api.com"
  }
}

```

#### Install

```
Install-Package partner.steamgames
```


## 🧬 Roadmap

#### Legend:

* `📌` To Do
* `⚡️` In Progress
* `☣️` Partial Done
* `✅` Done

|       Feature        | Status    |
|:------------------:	|:------:	|
|      IBroadcastService         |    📌    |
|      ICheatReportingService         |    ✅    |
|      ICloudService          |    📌    |
|      IEconMarketService          |    📌    |
|      IEconService          |    📌    |
|      IGameInventory          |    📌    |
|      IGameNotificationsService          |    📌    |
|      IGameServersService          |    📌    |
|      IInventoryService          |    📌    |
|      ILobbyMatchmakingService          |    ☣️    |
|      IPlayerService          |    📌    |
|      IPublishedFileService          |    📌    |
|      ISiteLicenseService          |    📌    |
|      ISteamApps          |    📌    |
|      ISteamCommunity          |    📌    |
|      ISteamEconomy          |    📌    |
|      ISteamGameServerStats          |    📌    |
|      ISteamLeaderboards          |    📌    |
|      ISteamMicroTxn          |    📌    |
|      ISteamMicroTxnSandbox          |    📌    |
|      ISteamNews          |    📌    |
|      ISteamPublishedItemSearch          |    📌    |
|      ISteamPublishedItemVoting          |    📌    |
|      ISteamUserAuth           |    ☣️    |
|      ISteamUser           |    ☣️    |
|      ISteamUserStats           |    📌    |
|      ISteamWebAPIUtil           |    📌    |
|      IWorkshopService           |    📌    |

