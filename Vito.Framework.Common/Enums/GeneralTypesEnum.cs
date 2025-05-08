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
}




public enum NotificationTypeEnum
{
    NotificationType_Email = 1,
    NotificationType_SMS = 2
}

public enum DocumentTypeEnum
{
    DocumentTypeList_BornRegistry = 3,
    DocumentTypeList_DNI = 4,
    DocumentTypeList_ForeingDNI = 5,
    DocumentTypeList_CompanyId = 6,
    DocumentTypeList_Passport = 7
}

public enum GenderEnum
{
    GenderList_Undefined = 8,
    GenderList_Female = 9,
    GenderList_Male = 10,
}

public enum OAuthActionTypeEnum
{
    OAuthActionType_Undefined = 11,
    OAuthActionType_CreateNewApplication = 12,
    OAuthActionType_CreateNewCompany = 13,
    OAuthActionType_CreateNewPerson = 14,
    OAuthActionType_CreateNewUser = 15,
    OAuthActionType_SendActivationEmail = 16,
    OAuthActionType_ActivateUser = 17,
    OAuthActionType_LoginFail_CompanyNotFound = 18,
    OAuthActionType_LoginFail_CompanySecretInvalid = 19,
    OAuthActionType_LoginFail_CompanyMembershipDoesNotExist = 20,
    OAuthActionType_LoginFail_ApplicationNoFound = 21,
    OAuthActionType_LoginFail_ApplicationSecretInvalid = 22,
    OAuthActionType_LoginFail_UserNotFound = 23,
    OAuthActionType_LoginFail_UserSecretInvalid = 24,
    OAuthActionType_LoginFail_UserUnauthorized = 25,
    OAuthActionType_LoginSuccessByAuthorizationCode = 26,
    OAuthActionType_LoginSuccessByClientCredentials = 27,
    OAuthActionType_ChangeUserPassword = 28,
    OAuthActionType_Logoff = 29,
}


public enum LocationTypeEnum
{
    LocationType_State = 30,
    LocationType_City = 31,
    LocationType_Neighborhood = 32
}

public enum SequenceType_Enum
{
    SequenceType_RoleName = 33,
}

public enum EntityAuditTypeEnum
{
    EntityAuditType_Read = 34,
    EntityAuditType_AddRow = 35,
    EntityAuditType_DeleteRow = 36,
    EntityAuditType_UpdateRow = 37,
}