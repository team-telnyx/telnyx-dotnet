using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// If `telephony` is enabled, the assistant will be able to make and receive calls.
/// If `messaging` is enabled, the assistant will be able to send and receive messages.
/// </summary>
[JsonConverter(typeof(EnabledFeaturesConverter))]
public enum EnabledFeatures
{
    Telephony, Messaging
}

sealed class EnabledFeaturesConverter : JsonConverter<EnabledFeatures>
{
    public override EnabledFeatures Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telephony"=>EnabledFeatures.Telephony,
            "messaging"=>EnabledFeatures.Messaging,
            _ =>(EnabledFeatures)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EnabledFeatures value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EnabledFeatures.Telephony=>"telephony",
            EnabledFeatures.Messaging=>"messaging",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}