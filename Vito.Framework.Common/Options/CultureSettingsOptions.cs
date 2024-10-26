using Vito.Framework.Common.Constants;

namespace Vito.Framework.Common.Options;

public record CultureSettingsOptions
{
    public const string SectionName = FrameworkConstants.AppSettings_SectionName_CultureSettings;
    public string? DefaultCulture { get; set; } = FrameworkConstants.Culture_DefaultId;

    public string? LocalizationJsonFilePath { get; set; } = string.Empty;

    public bool AutoAddMissingTranslations { get; set; } = false;
}