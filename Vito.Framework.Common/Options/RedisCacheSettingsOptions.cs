using Vito.Framework.Common.Constants;

namespace Vito.Framework.Common.Options;

public record RedisCacheSettingsOptions
{
    public const string SectionName = FrameworkConstants.AppSettings_SectionName_RedisCacheSettings;
    public string ConnectionString { get; set; } = "";
    public string Instance { get; set; } = "";
    public int TokenExpirationInMinutes { get; set; } = FrameworkConstants.RedisCache_DefaultTokenExpirationInMinutes;
    public bool IsCacheEnabled { get; set; } = false;
}
