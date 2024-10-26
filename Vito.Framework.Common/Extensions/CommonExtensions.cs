using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

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

    public static string Serialize(this object entity)
    {
        var resultValue = JsonSerializer.Serialize(entity);
        return resultValue;
    }

    public static T Deserialize<T>(this string serializedText)
    {
        try
        {
            T returnEntity = (T)JsonSerializer.Deserialize<T>(serializedText);

            return returnEntity;
        }
        catch (Exception exception)
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }

    public static string GetEnumByValue<T>(this T enumList, object value)
    {
        var enumValue = Enum.Parse(typeof(T), value.ToString(), true).ToString();
        return enumValue;
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
        decimal propertyValueDecimal = propertyValue == null ? decimal.Zero : decimal.Parse(propertyValue!.ToString());
        return propertyValueDecimal;
    }

    //public static T DeepClone<T>(this T a)
    //{
    //    using (MemoryStream stream = new MemoryStream())
    //    {
    //        var formatter = new BinaryFormatter();
    //        formatter.Serialize(out m, a);
    //        stream.Position = 0;
    //        return (T)formatter.Deserialize(stream);
    //    }
    //}
}