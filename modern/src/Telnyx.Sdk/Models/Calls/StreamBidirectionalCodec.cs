using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls;

/// <summary>
/// Indicates codec for bidirectional streaming RTP payloads. Used only with stream_bidirectional_mode=rtp.
/// Case sensitive.
/// </summary>
[JsonConverter(typeof(StreamBidirectionalCodecConverter))]
public enum StreamBidirectionalCodec
{
    Pcmu, Pcma, G722, Opus, AmrWb, L16
}

sealed class StreamBidirectionalCodecConverter : JsonConverter<StreamBidirectionalCodec>
{
    public override StreamBidirectionalCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PCMU"=>StreamBidirectionalCodec.Pcmu,
            "PCMA"=>StreamBidirectionalCodec.Pcma,
            "G722"=>StreamBidirectionalCodec.G722,
            "OPUS"=>StreamBidirectionalCodec.Opus,
            "AMR-WB"=>StreamBidirectionalCodec.AmrWb,
            "L16"=>StreamBidirectionalCodec.L16,
            _ =>(StreamBidirectionalCodec)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StreamBidirectionalCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StreamBidirectionalCodec.Pcmu=>"PCMU",
            StreamBidirectionalCodec.Pcma=>"PCMA",
            StreamBidirectionalCodec.G722=>"G722",
            StreamBidirectionalCodec.Opus=>"OPUS",
            StreamBidirectionalCodec.AmrWb=>"AMR-WB",
            StreamBidirectionalCodec.L16=>"L16",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}