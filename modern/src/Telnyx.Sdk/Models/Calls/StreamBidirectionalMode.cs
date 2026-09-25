using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls;

/// <summary>
/// Configures method of bidirectional streaming (mp3, rtp).
/// </summary>
[JsonConverter(typeof(StreamBidirectionalModeConverter))]
public enum StreamBidirectionalMode
{
    Mp3, Rtp
}

sealed class StreamBidirectionalModeConverter : JsonConverter<StreamBidirectionalMode>
{
    public override StreamBidirectionalMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp3"=>StreamBidirectionalMode.Mp3,
            "rtp"=>StreamBidirectionalMode.Rtp,
            _ =>(StreamBidirectionalMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StreamBidirectionalMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StreamBidirectionalMode.Mp3=>"mp3",
            StreamBidirectionalMode.Rtp=>"rtp",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}