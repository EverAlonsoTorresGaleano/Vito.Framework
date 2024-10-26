using System.Reflection;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json.Serialization;

namespace Vito.Framework.Api.Extensions;

public static class ApiJsonExtensions
{

    public abstract class ValueObject;

    public class MyValueObject : ValueObject;

    public class RootObject
    {
        public ValueObject? ValueObject { get; set; }
    }

    public static void AddNativePolymorphicTypInfo(JsonTypeInfo jsonTypeInfo)
    {
        Type baseValueObjectType = typeof(ValueObject);
        if (jsonTypeInfo.Type == baseValueObjectType)
        {
            jsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
            {
                TypeDiscriminatorPropertyName = "$mytype",
                IgnoreUnrecognizedTypeDiscriminators = true,
                UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization,
            };
            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(ValueObject))); // Fixed MyBaseClass => ValueObject
            foreach (var t in types.Select(t => new JsonDerivedType(t, t.Name.ToLowerInvariant()))) // Fixed ToLower() => ToLowerInvariant
                jsonTypeInfo.PolymorphismOptions.DerivedTypes.Add(t);
        }
    }
}