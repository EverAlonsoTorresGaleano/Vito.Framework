namespace Vito.Framework.Common.Models.Security;

public record TokenDTO
{
    public TokenDTO(string keyId, string issuer, List<string> audience, List<(string Type, string Value)> claims, DateTime validTo, string signatureAlgorithm, string rawData, string subject, DateTime validFrom, string encodedHeader, string encodedPayload)
    {
        KeyId = keyId;
        Issuer = issuer;
        Audience = audience;
        Claims = claims;
        ValidTo = validTo;
        SignatureAlgorithm = signatureAlgorithm;
        RawData = rawData;
        Subject = subject;
        ValidFrom = validFrom;
        EncodedHeader = encodedHeader;
        EncodedPayload = encodedPayload;
    }

    public string KeyId { get; }
    public string Issuer { get; }
    public List<string> Audience { get; }
    public List<(string Type, string Value)> Claims { get; }
    public DateTime ValidTo { get; }
    public string SignatureAlgorithm { get; }
    public string RawData { get; }
    public string Subject { get; }
    public DateTime ValidFrom { get; }
    public string EncodedHeader { get; }
    public string EncodedPayload { get; }
}

