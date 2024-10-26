using Vito.Framework.Common.Constants;

namespace Vito.Framework.Common.Options;

public record IdentityServiceServerSettingsOptions
{
    public const string SectionName = FrameworkConstants.AppSettings_SectionName_IdentityServiceServerSettings;
    public string Key { get; set; } = "";
    public string Issuer { get; set; } = "";
    public string Audience { get; set; } = "";
    public int TokenLifeTimeMinutes { get; set; } = FrameworkConstants.IdentityServer_DefaultTokenLifeTimeMinutes;

    public int MaxUserFailRetrys { get; set; } = FrameworkConstants.IdentityServer_MaxUserFailRetrys;
    public string[]? AuthorizedUrls { get; set; }
}
