using Vito.Framework.Common.Constants;
using Vito.Framework.Common.Options;

namespace Vito.Transverse.Identity.Domain.Options;

public record DataBaseSettingsOptions
{
    public const string SectionName = FrameworkConstants.AppSettings_SectionName_DataBaseSettings;

    public ConnectionStringOptions[]? ConnectionStrings { get; set; }
}