using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Recordings;

[JsonConverter(typeof(JsonModelConverter<RecordingResponseData, RecordingResponseDataFromRaw>))]
public sealed record class RecordingResponseData : JsonModel
{
    /// <summary>
    /// Uniquely identifies the recording.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Unique identifier and token for controlling the call.
    /// </summary>
    public string? CallControlID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_control_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_control_id", value);
        }
    }

    /// <summary>
    /// ID unique to the call leg (used to correlate webhook events).
    /// </summary>
    public string? CallLegID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_leg_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_leg_id", value);
        }
    }

    /// <summary>
    /// ID that is unique to the call session and can be used to correlate webhook
    /// events. Call session is a group of related call legs that logically belong
    /// to the same phone call, e.g. an inbound and outbound leg of a transferred call.
    /// </summary>
    public string? CallSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_session_id", value);
        }
    }

    /// <summary>
    /// When `dual`, the final audio file has the first leg on channel A, and the
    /// rest on channel B.
    /// </summary>
    public ApiEnum<string, Channels>? Channels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Channels>>(
                "channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channels", value);
        }
    }

    /// <summary>
    /// Uniquely identifies the conference.
    /// </summary>
    public string? ConferenceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conference_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conference_id", value);
        }
    }

    /// <summary>
    /// Identifies the Telnyx application (Call Control, TeXML) or SIP connection
    /// resource associated with this recording.
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Links to download the recording files.
    /// </summary>
    public DownloadUrls? DownloadUrls {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DownloadUrls>(
                "download_urls"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("download_urls", value);
        }
    }

    /// <summary>
    /// The duration of the recording in milliseconds.
    /// </summary>
    public int? DurationMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "duration_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("duration_millis", value);
        }
    }

    /// <summary>
    /// The `from` (caller) number for the call that generated this recording.
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// Indicates what triggered the recording. Possible values include `DialVerb`,
    /// `Conference`, `OutboundAPI`, `Trunking`, `RecordVerb`, `StartCallRecordingAPI`, `StartConferenceRecordingAPI`.
    /// </summary>
    public string? InitiatedBy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "initiated_by"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("initiated_by", value);
        }
    }

    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the recording ended.
    /// </summary>
    public string? RecordingEndedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recording_ended_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recording_ended_at", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the recording started.
    /// </summary>
    public string? RecordingStartedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recording_started_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recording_started_at", value);
        }
    }

    /// <summary>
    /// The kind of event that led to this recording being created.
    /// </summary>
    public ApiEnum<string, Source>? Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Source>>(
                "source"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <summary>
    /// The status of the recording. Only `completed` recordings are currently supported.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// The `to` (callee) number for the call that generated this recording.
    /// </summary>
    public string? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        this.Channels?.Validate();
        _ = this.ConferenceID;
        _ = this.ConnectionID;
        _ = this.CreatedAt;
        this.DownloadUrls?.Validate();
        _ = this.DurationMillis;
        _ = this.From;
        _ = this.InitiatedBy;
        this.RecordType?.Validate();
        _ = this.RecordingEndedAt;
        _ = this.RecordingStartedAt;
        this.Source?.Validate();
        this.Status?.Validate();
        _ = this.To;
        _ = this.UpdatedAt;
    }

    public RecordingResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordingResponseData (
        RecordingResponseData recordingResponseData
    ) : base(recordingResponseData)
    {  }
    #pragma warning restore CS8618

    public RecordingResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordingResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordingResponseDataFromRaw.FromRawUnchecked"/>
    public static RecordingResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RecordingResponseDataFromRaw : IFromRawJson<RecordingResponseData>
{
    /// <inheritdoc/>
    public RecordingResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecordingResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// When `dual`, the final audio file has the first leg on channel A, and the rest
/// on channel B.
/// </summary>
[JsonConverter(typeof(ChannelsConverter))]
public enum Channels
{
    Single, Dual
}sealed class ChannelsConverter : JsonConverter<Channels>
{
    public override Channels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "single"=>Channels.Single, "dual"=>Channels.Dual, _ =>(Channels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Channels value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Channels.Single=>"single",
            Channels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Links to download the recording files.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DownloadUrls, DownloadUrlsFromRaw>))]
public sealed record class DownloadUrls : JsonModel
{
    /// <summary>
    /// Link to download the recording in mp3 format.
    /// </summary>
    public string? Mp3 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mp3"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mp3", value);
        }
    }

    /// <summary>
    /// Link to download the recording in wav format.
    /// </summary>
    public string? Wav {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wav"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wav", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Mp3;
        _ = this.Wav;
    }

    public DownloadUrls ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DownloadUrls (DownloadUrls downloadUrls) : base(downloadUrls)
    {  }
    #pragma warning restore CS8618

    public DownloadUrls (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DownloadUrls (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DownloadUrlsFromRaw.FromRawUnchecked"/>
    public static DownloadUrls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DownloadUrlsFromRaw : IFromRawJson<DownloadUrls>
{
    /// <inheritdoc/>
    public DownloadUrls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DownloadUrls.FromRawUnchecked(rawData);
}[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    Recording
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "recording"=>RecordType.Recording, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.Recording=>"recording",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The kind of event that led to this recording being created.
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Conference, Call
}sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "conference"=>Source.Conference,
            "call"=>Source.Call,
            _ =>(Source)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Source value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Source.Conference=>"conference",
            Source.Call=>"call",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the recording. Only `completed` recordings are currently supported.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Completed
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "completed"=>Status.Completed, _ =>(Status)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}