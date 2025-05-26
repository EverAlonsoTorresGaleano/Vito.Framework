namespace Vito.Framework.Common.Enums;



/// <summary>
/// Include Enum Type Name on Item for Localization Purpouses
/// </summary>
public enum GeneralTypesGroupEnum
{
    GeneralType_NotificationType = 1,
    GeneralType_DocumentTypeList = 2,
    GeneralType_GenderList = 3,
    GeneralType_OAuthActionType = 4,
    GeneralType_LocationType = 5,
    GeneralType_SequenceType = 6,
    GeneralType_EntityAuditType = 7,
    GeneralType_FileType = 8,
    GeneralType_PictureCategoryType = 9,
}




public enum NotificationTypeEnum
{
    NotificationType_Email = 101,
    NotificationType_SMS = 102
}

public enum DocumentTypeEnum
{
    DocumentTypeList_BornRegistry = 201,
    DocumentTypeList_DNI = 202,
    DocumentTypeList_ForeingDNI = 203,
    DocumentTypeList_CompanyId = 204,
    DocumentTypeList_Passport = 205
}

public enum GenderEnum
{
    GenderList_Undefined = 301,
    GenderList_Female = 302,
    GenderList_Male = 303,
}

public enum OAuthActionTypeEnum
{
    OAuthActionType_Undefined = 401,
    OAuthActionType_CreateNewApplication = 402,
    OAuthActionType_CreateNewCompany = 403,
    OAuthActionType_CreateNewUser = 404,
    OAuthActionType_SendActivationEmail = 405,
    OAuthActionType_ActivateUser = 406,
    OAuthActionType_LoginFail_Company_ClientOrSecretNotFound=407,
    OAuthActionType_LoginFail_CompanyMembershipNotFound = 408,
    OAuthActionType_LoginFail_Application_ClientOrSecretNoFound=409,
    OAuthActionType_LoginFail_User_LoginOrPasswordInvalid=410,
    OAuthActionType_LoginFail_UserUnauthorized = 411,
    OAuthActionType_LoginSuccessByAuthorizationCode = 412,
    OAuthActionType_LoginSuccessByClientCredentials = 413,
    OAuthActionType_ChangeUserPassword = 414,
    OAuthActionType_Logoff = 415,
    OAuthActionType_ClearCache = 416,
    OAuthActionType_ApiRequestUnauthorized = 417,
    OAuthActionType_ApiRequestSuccessfully= 418,
}


public enum LocationTypeEnum
{
    LocationType_State = 501,
    LocationType_City = 502,
    LocationType_Neighborhood = 503
}

public enum SequenceType_Enum
{
    SequenceType_RoleName = 601,
}

public enum EntityAuditTypeEnum
{
    EntityAuditType_Read = 701,
    EntityAuditType_AddRow = 702,
    EntityAuditType_UpdateRow = 703,
    EntityAuditType_DeleteRow = 704,
}

public enum FileTypeEnum
{
    FileType_Png = 801,
    FileType_Gif = 802,
    FileType_Jpg = 803
}

public enum PictureCategoryTypeEnum
{
    PictureCategoryType_System = 901,
    PictureCategoryType_Project = 902,
    PictureCategoryType_Property = 903,
    PictureCategoryType_ProjectRoom = 904,
    PictureCategoryTypePropertyRoom = 905,
    PictureCategoryType_Company = 906,
    PictureCategoryType_Sponsor = 907,
    PictureCategoryType_PageIcon = 908,
}