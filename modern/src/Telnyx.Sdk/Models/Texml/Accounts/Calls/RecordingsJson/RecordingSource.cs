using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;

/// <summary>
/// Defines how the recording was created.
/// </summary>
[JsonConverter(typeof(RecordingSourceConverter))]
public enum RecordingSource
{
    StartCallRecordingApi,
    StartConferenceRecordingApi,
    OutboundApi,
    DialVerb,
    Conference,
    RecordVerb,
    Trunking
}

sealed class RecordingSourceConverter : JsonConverter<RecordingSource>
{
    public override RecordingSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "StartCallRecordingAPI"=>RecordingSource.StartCallRecordingApi,
            "StartConferenceRecordingAPI"=>RecordingSource.StartConferenceRecordingApi,
            "OutboundAPI"=>RecordingSource.OutboundApi,
            "DialVerb"=>RecordingSource.DialVerb,
            "Conference"=>RecordingSource.Conference,
            "RecordVerb"=>RecordingSource.RecordVerb,
            "Trunking"=>RecordingSource.Trunking,
            _ =>(RecordingSource)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecordingSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordingSource.StartCallRecordingApi=>"StartCallRecordingAPI",
            RecordingSource.StartConferenceRecordingApi=>"StartConferenceRecordingAPI",
            RecordingSource.OutboundApi=>"OutboundAPI",
            RecordingSource.DialVerb=>"DialVerb",
            RecordingSource.Conference=>"Conference",
            RecordingSource.RecordVerb=>"RecordVerb",
            RecordingSource.Trunking=>"Trunking",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}