namespace Vito.Framework.Common.Enums;




//[JsonConverter(typeof(JsonStringEnumConverter<TokenGrantTypeEnum>))]
public enum TokenGrantTypeEnum
{
    AuthorizationCode = 1,
    ClientCredentials = 2,
    RefreshToken = 3
}

//[JsonConverter(typeof(JsonStringEnumConverter<TokenGrantTypeEnum>))]
public enum TokenStatusEnum
{
    Approved = 1,
    Revoked = 2,
}

public enum ConnectionStringTypeEnum
{
    SQLServer
}

public enum CustomClaimTypes
{
    ApplicationOwnerId,
    ApplicationOwnerName,
    ApplicationId,
    ApplicationName,
    CompanyId,
    CompanyName,
    RoleId,
    RoleName
}