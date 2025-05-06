namespace Vito.Framework.Common.Models.SocialNetworks;

public class NotificationTemplateDTO
{
    public long Id { get; set; }

    public long NotificationTemplateGroupId { get; set; }

    public string CultureFk { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string SubjectTemplateText { get; set; } = null!;

    public string? MessageTemplateText { get; set; }

    public bool IsHtml { get; set; }
}
