namespace Vito.Framework.Common.Models.SocialNetworks;

public class NotificationDTO
{
    public string NotificationTemplateFk { get; set; } = null!;

    public string? CultureFk { get; set; }

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

    public long NotificationTypeFk { get; set; }
}