namespace Vito.Framework.Common.Enums;

#region ListItemGroup

public enum ListItemGroupEnum
{
    ListItemGroup_NotificationType,
    ListItemGroup_DocumentTypeList,
    ListItemGroup_GenderList,
    ListItemGroup_ActionType
}

#endregion

#region List Items
public enum NotificationTypeEnum
{
    Email = 1,
    SMS = 2
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

public enum ActionTypeEnum
{
    ActionType_Undefined = 11,
    ActionType_CreateNewApplication = 12,
    ActionType_CreateNewCompany = 13,
    ActionType_CreateNewPerson = 14,
    ActionType_CreateNewUser = 15,
    ActionType_SendActivationEmail = 16,
    ActionType_ActivateUser = 17,
    ActionType_LoginFail_CompanyNotFound = 18,
    ActionType_LoginFail_CompanySecretInvalid = 19,
    ActionType_LoginFail_CompanyMembershipDoesNotExist = 20,
    ActionType_LoginFail_ApplicationNoFound = 21,
    ActionType_LoginFail_ApplicationSecretInvalid = 22,
    ActionType_LoginFail_UserNotFound = 23,
    ActionType_LoginFail_UserSecretInvalid = 24,
    ActionType_LoginFail_UserUnauthorized=25,
    ActionType_LoginSuccessByAuthorizationCode = 26,
    ActionType_LoginSuccessByClientCredentials = 27,
    ActionType_ChangeUserPassword = 28,
    ActionType_Logoff = 29,
}

#endregion


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