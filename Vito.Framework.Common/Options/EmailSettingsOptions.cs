using Vito.Framework.Common.Constants;

namespace Vito.Framework.Common.Options;

public record EmailSettingsOptions
{
    public const string SectionName = FrameworkConstants.AppSettings_SectionName_EmailSettings;
    public string ServerName { get; set; } = string.Empty;
    public string SenderEmail { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Port { get; set; } = 587;
    public bool EnableSsl { get; set; } = true;


}
