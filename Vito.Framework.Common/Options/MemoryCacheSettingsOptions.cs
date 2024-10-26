using Vito.Framework.Common.Constants;

namespace Vito.Framework.Common.Options;

public record MemoryCacheSettingsOptions
{

    public const string SectionName = FrameworkConstants.AppSettings_SectionName_MemoryCacheSettings;
    public int ExpirationScanFrequencyInSeconds { get; set; } = FrameworkConstants.MemoryCache_DefaultExpirationScanFrequencyInSeconds;

    public int CacheExpirationInMinutes { get; set; } = FrameworkConstants.MemoryCache_DefaultCacheExpirationInMinutes;


}
