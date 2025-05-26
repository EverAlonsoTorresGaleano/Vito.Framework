using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vito.Framework.Common.Constants;

namespace Vito.Framework.Common.Extensions;

public static class CommonExtensions
{
    const char slashSeparator = '/';
    const char plusSeparator = '+';
    const char minusSeparator = '-';
    const char underScoreSeparator = '_';
    const string genPrefixN = "N";

    /// <summary>
    /// GetErrorStakTrace
    /// </summary>
    /// <param name="exceptionObject"></param>
    /// <returns></returns>
    public static string GetErrorStakTrace(this Exception exceptionObject)
    {
        var errorDetail = new StringBuilder(exceptionObject.Message);
        var internalError = exceptionObject.InnerException;
        while (internalError != null)
        {
            errorDetail.Append(exceptionObject.Message);
            errorDetail.Append(exceptionObject.StackTrace);
            internalError = internalError.InnerException;
        }
        errorDetail.Append(exceptionObject.StackTrace);
        var stackTrace = errorDetail.ToString();
        return stackTrace;
    }

    public static string NewTokenEncoded()
    {
        var newGuid = Guid.NewGuid().ToString(genPrefixN);
        var returnValue = newGuid.EncodeText();
        return returnValue;
    }

    public static string EncodeText(this string text)
    {
        var tokenLength = 64;
        var tokenGenated = new Rfc2898DeriveBytes(text, 384);
        var tokenString = Convert.ToBase64String(tokenGenated.GetBytes(tokenLength));
        tokenString = (tokenString).Substring(0, tokenLength).Replace(slashSeparator, underScoreSeparator).Replace(plusSeparator, minusSeparator);
        return tokenString;
    }

    public static string ReplaceParameterOnString(this string? baseString, List<KeyValuePair<string, string>> parameters, string paramPrefix = "{{", string paramSufix = "}}")
    {
        StringBuilder finalString = new(baseString);
        if (parameters is not null)
        {
            parameters.ForEach(parameter =>
            {
                finalString = finalString.Replace($"{paramPrefix}{parameter.Key}{paramSufix}", parameter.Value);
            });
        }
        return finalString.ToString();
    }

    public static T? CloneEntity<T>(this T entityToClone)
    {
        string cloneString = entityToClone!.Serialize()!;
        T clonedEntity = cloneString.Deserialize<T>()!;
        return clonedEntity;
    }

    public static string Serialize(this object entity, int maxNestedEntities = 0)
    {

        JsonSerializerOptions options = new JsonSerializerOptions
        {

            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            MaxDepth = maxNestedEntities,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,

        };
        var resultValue = JsonSerializer.Serialize(entity, options);
        return resultValue;
    }

    public static T? Deserialize<T>(this string serializedText, int maxNestedEntities = 0)
    {
        try
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                MaxDepth = maxNestedEntities,
                ReferenceHandler = ReferenceHandler.IgnoreCycles

            };
            T returnEntity = (T)JsonSerializer.Deserialize<T>(serializedText, options)!;

            return returnEntity;
        }
        catch 
        {
            return (T)Activator.CreateInstance(typeof(T))!;
        }
    }

    public static string GetEnumByValue<T>(this T enumList, object value)
    {
        var enumValue = Enum.Parse(typeof(T), value.ToString()!, true).ToString();
        return enumValue!;
    }

    public static object? GetFieldValueFromEntity(this object entity, string fieldName)
    {
        var propertyInfo = entity.GetType().GetProperty(fieldName);
        object? propertyValue = null;
        if (propertyInfo != null)
        {
            propertyValue = propertyInfo.GetValue(entity, null);
        }
        return propertyValue;
    }

    public static decimal GetFieldValueDecimalFromEntity(this object entity, string fieldName)
    {
        var propertyValue = GetFieldValueFromEntity(entity, fieldName);
        decimal propertyValueDecimal = propertyValue == null ? decimal.Zero : decimal.Parse(propertyValue!.ToString()!);
        return propertyValueDecimal;
    }

    public static object GetPropertyValue(this object entity, string PropertyName)
    {
        PropertyInfo infoColumna = entity.GetType().GetProperty(PropertyName)!;
        return infoColumna.GetValue(entity, null)!;
    }

    public static string GetEntityChangesSummary(this object oldEntity, object? newEntity = null)
    {
        List<PropertyInfo> propertyList = oldEntity.GetType().GetProperties().ToList();
        List<KeyValuePair<string, string>> changeList = new();

        object? oldPropertyValue = null;
        object? newPropertyValue = null;
        propertyList.ForEach(itemProperty =>
        {
            if (!itemProperty.Name.Contains("Navigation") && itemProperty.PropertyType.FullName!.Contains("System"))
            {
                oldPropertyValue = GetPropertyValue(oldEntity, itemProperty.Name);
                if (newEntity is not null)
                {
                    newPropertyValue = newEntity is null ? null : GetPropertyValue(newEntity, itemProperty.Name);
                    if (!string.IsNullOrEmpty(oldPropertyValue?.ToString()) && !oldPropertyValue!.ToString()!.Equals(newPropertyValue!.ToString(), StringComparison.Ordinal))
                    {
                        changeList.Add(new(itemProperty.Name, $"Before= {oldPropertyValue} | After={newPropertyValue}"));
                    }
                }
                else //Single Entity
                {
                    if (!string.IsNullOrEmpty(oldPropertyValue?.ToString()))
                    {
                        changeList.Add(new(itemProperty.Name, oldPropertyValue!.ToString()!));
                    }
                }
            }
        });

        var returnJson = changeList.Serialize();
        return returnJson;
    }

    public static DateTime? ToLocalTimeNullable(this DateTime? utcTime)
    {
        DateTime? localTime = null!;
        if (utcTime is null)
        {
            localTime = null!;
        }
        else
        {
            localTime = utcTime.Value.ToLocalTime();
        }
        return localTime;
    }

    public static object[]? ValidateParamArray(this object[]? parameters)
    {
        if (parameters?.Length == 1 && parameters.First().ToString()!.Contains(FrameworkConstants.Separator_Comma))
        {
            parameters = parameters.First().ToString()!.Split(FrameworkConstants.Separator_Comma);
        }
        return parameters;
    }

}