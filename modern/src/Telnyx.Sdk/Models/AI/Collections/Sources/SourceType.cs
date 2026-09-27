using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Collections.Sources;

/// <summary>
/// The type of Telnyx data attached as a source. `bucket` requires an additional
/// `bucket_id`. Only `voice` is searchable today; `meeting_bot`, `message`, and
/// `bucket` attach but are not yet searchable (Coming soon).
/// </summary>
[JsonConverter(typeof(SourceTypeConverter))]
public enum SourceType
{
    Voice, MeetingBot, Message, Bucket
}

sealed class SourceTypeConverter : JsonConverter<SourceType>
{
    public override SourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "voice"=>SourceType.Voice,
            "meeting_bot"=>SourceType.MeetingBot,
            "message"=>SourceType.Message,
            "bucket"=>SourceType.Bucket,
            _ =>(SourceType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, SourceType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SourceType.Voice=>"voice",
            SourceType.MeetingBot=>"meeting_bot",
            SourceType.Message=>"message",
            SourceType.Bucket=>"bucket",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}