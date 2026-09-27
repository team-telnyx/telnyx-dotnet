using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls;

/// <summary>
/// Specifies which call legs should receive the bidirectional stream audio.
/// </summary>
[JsonConverter(typeof(StreamBidirectionalTargetLegsConverter))]
public enum StreamBidirectionalTargetLegs
{
    Both, Self, Opposite
}

sealed class StreamBidirectionalTargetLegsConverter : JsonConverter<StreamBidirectionalTargetLegs>
{
    public override StreamBidirectionalTargetLegs Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "both"=>StreamBidirectionalTargetLegs.Both,
            "self"=>StreamBidirectionalTargetLegs.Self,
            "opposite"=>StreamBidirectionalTargetLegs.Opposite,
            _ =>(StreamBidirectionalTargetLegs)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StreamBidirectionalTargetLegs value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StreamBidirectionalTargetLegs.Both=>"both",
            StreamBidirectionalTargetLegs.Self=>"self",
            StreamBidirectionalTargetLegs.Opposite=>"opposite",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}