namespace Vito.Framework.Common.DTO;

public record DeviceInformationDTO
{
    public string? Id;
    public string? HostName;
    public string? IpAddress;
    public string? DeviceType;
    public string? Browser;
    public string? Platform;
    public string? Engine;
    public string? CultureId;
    public string? EndPointPattern;
    public string? EndPointUrl;
    public string? Method;
    public string? QueryString;
    public string? UserAgent;
    public string? Referer;
    public long? ApplicationId;
    public long? CompanyId;
    public long? RoleId;
    public long? UserId;
};

