namespace Vito.Framework.Common.DTO;

public class PingResponseDTO
{
    public DateTime? PingDate { get; set; }
    public string? PingMessage { get; set; }
    public DeviceInformationDTO? DeviceInformation { get; set; }
}