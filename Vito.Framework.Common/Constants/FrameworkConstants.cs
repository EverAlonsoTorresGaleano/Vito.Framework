namespace Vito.Framework.Common.Constants;

public class FrameworkConstants
{
    //Defaults
    public const int MemoryCache_DefaultExpirationScanFrequencyInSeconds = 30;
    public const int MemoryCache_DefaultCacheExpirationInMinutes = 30;

    public const int RedisCache_DefaultTokenExpirationInMinutes = 30;
    public const string Culture_DefaultId = "es-CO";
    public const string Culture_TranslationKey_MessageNotFound = "TranslationKey_MessageNotFound";
    public const string Culture_TranslationMessage_MessageNotFound = "Culture: [{0}] ~Message: ({1}) -Not Found";

    public const int IdentityServer_DefaultTokenLifeTimeMinutes = 30;
    public const int IdentityServer_MaxUserFailRetrys = 3;

    //App Settings Section

    public const string AppSettings_SectionName_CultureSettings = "CultureSettings";
    public const string AppSettings_SectionName_DataBaseSettings = "DataBaseSettings";
    public const string AppSettings_SectionName_EmailSettings = "EmailSettings";
    public const string AppSettings_SectionName_FeatureFlagSettings = "FeatureFlagsSettings";
    public const string AppSettings_SectionName_IdentityServiceClientSettings = "IdentityServiceClientSettings";
    public const string AppSettings_SectionName_IdentityServiceServerSettings = "IdentityServiceServerSettings";
    public const string AppSettings_SectionName_MemoryCacheSettings = "MemoryCacheSettings";
    public const string AppSettings_SectionName_RedisCacheSettings = "RedisCacheSettings";


    //Exception
    public const string ApiExceptionHandling_ExceptionHandlingType = "Vito.Framework.Common.ExceptionsHandling";


    //Header
    public const string Header_CultureId = "CultureId";
    public const string Header_ApplicationId = "ApplicationId";
    public const string Header_CompanyId = "CompanyId";



    //User Name
    public const string Username_UserApi = "api-user";
    public const long UserId_UserUnknown = 2;
    public const long RoleId_UserUnknown=2;


    //Company
    public const long Company_DefaultId = 1;

    //HttpContext
    public const string HttpContext_DeviceInformationList = "DeviceInformacionList";


    public const string TokenBearerPrefix = "Bearer";

    public const int MinuteOnSeconds = 60;

    //Validation
    public const string ValidatorNotEmpty = " must not be empty.";
    public const string ValidatorNotImplemented = " RefreshToken not in use.";
    public const string ValidatorValidValue = " must have valid value.";
    public const string ValidatorValidGuid = " must have valid Guid.";

    public const string SQL_CONNECTION_STRING_EMPTY = "DataBaseService Context is not configured due ConnectionStrings:SqlServerDataBase was empty.";
    public const string ApplicationNamespace = "Vito.Framework.Common";


    public const string Separator_Comma = ",";
}