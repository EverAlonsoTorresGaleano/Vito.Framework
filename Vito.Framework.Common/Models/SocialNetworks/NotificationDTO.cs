namespace Vito.Framework.Common.Models.SocialNetworks;

public class NotificationDTO
{
    public long CompanyFk { get; set; }

    public long NotificationTemplateGroupFk { get; set; }

    public string CultureFk { get; set; } = null!;

    public long NotificationTypeFk { get; set; }

    public long Id { get; set; }

    public DateTime CreationDate { get; set; }

    public string Sender { get; set; } = null!;

    public List<string>? Receiver { get; set; } = null!;

    public List<string>? Cc { get; set; }

    public List<string>? Bcc { get; set; }

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;

    public bool IsSent { get; set; }

    public DateTime? SentDate { get; set; }

    public bool IsHtml { get; set; }



    public string CompanyNameTranslationKey { get; set; }
    public string CompanyDescriptionTranslationKey { get; set; } = null!;
    public string NotificationTypeNameTranslationKey { get; set; }
    public string NotificationTemplateName { get; set; }
    public string CultureNameTranslationKey { get; set; }
}