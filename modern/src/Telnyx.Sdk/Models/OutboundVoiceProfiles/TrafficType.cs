using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OutboundVoiceProfiles;

/// <summary>
/// Specifies the type of traffic allowed in this profile.
/// </summary>
[JsonConverter(typeof(TrafficTypeConverter))]
public enum TrafficType
{
    Conversational
}

sealed class TrafficTypeConverter : JsonConverter<TrafficType>
{
    public override TrafficType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "conversational"=>TrafficType.Conversational, _ =>(TrafficType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, TrafficType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TrafficType.Conversational=>"conversational",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}