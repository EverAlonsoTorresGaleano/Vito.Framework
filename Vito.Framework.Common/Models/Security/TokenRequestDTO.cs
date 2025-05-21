namespace Vito.Framework.Common.Models.Security;


//[JsonSerializable(typeof(TokenGrantTypeEnum))]
public record TokenRequestDTO
{
    public string grant_type { get; set; } = "ClientCredentials";
    public string? scope { get; set; }

    public string application_id { get; set; } = "eb2d4ffc-dc34-435f-8983-ecd42481143f";
    public string application_secret { get; set; } = "";

    public string company_id { get; set; } = "55c26aaf-79b0-42e9-9adc-1f3fcba6d6d8";
    public string company_secret { get; set; } = "ba3a564f-946a-4b07-b44c-bf8ea21e808c";

    public string? user_id { get; set; } = "ever.torresg";
    public string? user_secret { get; set; } = "123";

    public string? refresh_token { get; set; }
}