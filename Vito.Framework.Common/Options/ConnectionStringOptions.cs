using Vito.Framework.Common.Enums;

namespace Vito.Framework.Common.Options;

public class ConnectionStringOptions
{
    public string ConnectionName { get; set; } = "";
    public ConnectionStringTypeEnum ConnectionType { get; set; } = ConnectionStringTypeEnum.SQLServer;
    public string ConnectionString { get; set; } = "";
    public int RetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public int TimeOut { get; set; }
}