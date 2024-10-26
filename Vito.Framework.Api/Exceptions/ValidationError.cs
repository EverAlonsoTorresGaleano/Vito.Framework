using System.Text.Json.Serialization;

namespace Vito.Framework.Api.Exceptions;

public class ValidationError
{
    /// <summary>
    /// The error code
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    /// A message from and to the Developer
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }
}
