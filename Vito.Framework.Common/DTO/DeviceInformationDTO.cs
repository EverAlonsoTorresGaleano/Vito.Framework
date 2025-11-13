namespace Vito.Framework.Common.DTO;

public record DeviceInformationDTO
{
    public string Id = string.Empty;
    public string HostName = string.Empty;
    public string IpAddress = string.Empty;
    public string DeviceType = string.Empty;
    public string Browser = string.Empty;
    public string Platform = string.Empty;
    public string Engine = string.Empty;
    public string CultureId = string.Empty;
    public string EndPointPattern = string.Empty;
    public string EndPointUrl = string.Empty;
    public string Method = string.Empty;
    public string QueryString = string.Empty;
    public string UserAgent = string.Empty;
    public string Referer= string.Empty;
    public long ApplicationId;
    public long CompanyId;
    public long RoleId;
    public long UserId;
};

