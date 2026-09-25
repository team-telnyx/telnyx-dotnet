using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;

[JsonConverter(typeof(TwimlRecordingChannelsConverter))]
public enum TwimlRecordingChannels
{
    Channel1, Channel2
}

sealed class TwimlRecordingChannelsConverter : JsonConverter<TwimlRecordingChannels>
{
    public override TwimlRecordingChannels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<long>(ref reader, options) switch
        {
            1L=>TwimlRecordingChannels.Channel1,
            2L=>TwimlRecordingChannels.Channel2,
            _ =>(TwimlRecordingChannels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TwimlRecordingChannels value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TwimlRecordingChannels.Channel1=>1L,
            TwimlRecordingChannels.Channel2=>2L,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}