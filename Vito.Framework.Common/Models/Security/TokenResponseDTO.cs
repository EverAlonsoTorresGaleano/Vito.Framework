namespace Vito.Framework.Common.Models.Security;


//[JsonSerializable(typeof(TokenStatusEnum))]
public class TokenResponseDTO
{
    public string? access_token { get; set; }
    public string? token_type { get; set; }
    public long? issued_at { get; set; }
    public int? expires_in { get; set; }
    public string? status { get; set; }
    public string? scope { get; set; }
    public string? application_id { get; set; }
    public string? company_id { get; set; }
    public string? user_id { get; set; }
    public byte[]? user_avatar { get; set; }
}