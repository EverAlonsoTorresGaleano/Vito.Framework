namespace Vito.Framework.Common.DTO;

public record DeviceInformationDTO
{
    public string? Id;
    public string? Name;
    public string? IpAddress;
    public string? DeviceType;
    public string? Browser;
    public string? Platform;
    public string? Engine;
    public string? CultureId;
    public List<KeyValuePair<string, string>>? AddtionalInfo;
};