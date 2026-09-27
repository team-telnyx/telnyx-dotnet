using System.Text.Json;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Core;

/// <summary>
/// Helper class for deserializing &lt;c&gt;JsonElement&lt;/c&gt; objects. This handles
/// edge-cases around nullability and reference/value types.
/// </summary>
sealed class WrappedJsonSerializer
{
    public static T GetNotNullClass<T>
    (JsonElement element, string name) where T: class
    {
        T deserialized;
        try
        {
            deserialized =
                JsonSerializer.Deserialize<T>(element, ModelBase.SerializerOptions)
                ?? throw new TelnyxInvalidDataException($"'{name}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new TelnyxInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T GetNotNullStruct<T>
    (JsonElement element, string name) where T: struct
    {
        T deserialized;
        try
        {
            deserialized =
                JsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions)
                ?? throw new TelnyxInvalidDataException($"'{name}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new TelnyxInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T? GetNullableClass<T>
    (JsonElement element, string name) where T: class
    {
        T? deserialized;
        try
        {
            deserialized = JsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new TelnyxInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T? GetNullableStruct<T>
    (JsonElement element, string name) where T: struct
    {
        T? deserialized;
        try
        {
            deserialized = JsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new TelnyxInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }
}