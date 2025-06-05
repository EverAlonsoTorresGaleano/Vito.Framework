using Vito.Framework.Common.Enums;
using Vito.Framework.Common.Extensions;

namespace Vito.Framework.Common.Options;

public class ConnectionStringOptions
{
    public string ConnectionName { get; set; } = "";
    public ConnectionStringTypeEnum ConnectionType { get; set; } = ConnectionStringTypeEnum.SQLServer;
    public string ConnectionString { get; set; } = "";

    public string FullConnectionString
    {
        get
        {
            List<KeyValuePair<string, string>> emailTemplateParams = new()
            {
                    new (nameof(UserName),UserName),
                    new (nameof(Password),Password),
            };
            return ConnectionString.ReplaceParameterOnString(emailTemplateParams);
        }
    }
    public string UserName { get; set; } = "";
    public string Password { get; set; } = "";
    public int RetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public int TimeOut { get; set; }
}