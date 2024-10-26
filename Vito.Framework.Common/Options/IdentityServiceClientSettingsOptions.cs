using Vito.Framework.Common.Constants;

namespace Vito.Framework.Common.Options;

public record IdentityServiceClientSettingsOptions
{

    public const string SectionName = FrameworkConstants.AppSettings_SectionName_IdentityServiceClientSettings;
    public string ServerKey { get; set; } = "";
    public string ServerIssuer { get; set; } = "";
    public string ServerAudience { get; set; } = "";
    public string[]? LocalAuthorizedUrls { get; set; }

}
