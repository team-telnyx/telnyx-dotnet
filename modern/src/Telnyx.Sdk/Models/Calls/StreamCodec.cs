using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls;

/// <summary>
/// Specifies the codec to be used for the streamed audio. When set to 'default'
/// or when transcoding is not possible, the codec from the call will be used.
/// </summary>
[JsonConverter(typeof(StreamCodecConverter))]
public enum StreamCodec
{
    Pcmu, Pcma, G722, Opus, AmrWb, L16, Default
}

sealed class StreamCodecConverter : JsonConverter<StreamCodec>
{
    public override StreamCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PCMU"=>StreamCodec.Pcmu,
            "PCMA"=>StreamCodec.Pcma,
            "G722"=>StreamCodec.G722,
            "OPUS"=>StreamCodec.Opus,
            "AMR-WB"=>StreamCodec.AmrWb,
            "L16"=>StreamCodec.L16,
            "default"=>StreamCodec.Default,
            _ =>(StreamCodec)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, StreamCodec value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StreamCodec.Pcmu=>"PCMU",
            StreamCodec.Pcma=>"PCMA",
            StreamCodec.G722=>"G722",
            StreamCodec.Opus=>"OPUS",
            StreamCodec.AmrWb=>"AMR-WB",
            StreamCodec.L16=>"L16",
            StreamCodec.Default=>"default",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}