using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferenceRecordingSaved, ConferenceRecordingSavedFromRaw>))]
public sealed record class ConferenceRecordingSaved : JsonModel
{
    /// <summary>
    /// Identifies the type of resource.
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
    /// The type of event being delivered.
    /// </summary>
    public ApiEnum<string, ConferenceRecordingSavedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConferenceRecordingSavedEventType>>(
                "event_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    public ConferenceRecordingSavedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceRecordingSavedPayload>(
                "payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payload", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public ApiEnum<string, ConferenceRecordingSavedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConferenceRecordingSavedRecordType>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.EventType?.Validate();
        this.Payload?.Validate();
        this.RecordType?.Validate();
    }

    public ConferenceRecordingSaved ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceRecordingSaved (
        ConferenceRecordingSaved conferenceRecordingSaved
    ) : base(conferenceRecordingSaved)
    {  }
    #pragma warning restore CS8618

    public ConferenceRecordingSaved (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceRecordingSaved (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceRecordingSavedFromRaw.FromRawUnchecked"/>
    public static ConferenceRecordingSaved FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceRecordingSavedFromRaw : IFromRawJson<ConferenceRecordingSaved>
{
    /// <inheritdoc/>
    public ConferenceRecordingSaved FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceRecordingSaved.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(ConferenceRecordingSavedEventTypeConverter))]
public enum ConferenceRecordingSavedEventType
{
    ConferenceRecordingSaved
}sealed class ConferenceRecordingSavedEventTypeConverter : JsonConverter<ConferenceRecordingSavedEventType>
{
    public override ConferenceRecordingSavedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "conference.recording.saved"=>ConferenceRecordingSavedEventType.ConferenceRecordingSaved,
            _ =>(ConferenceRecordingSavedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceRecordingSavedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceRecordingSavedEventType.ConferenceRecordingSaved=>"conference.recording.saved",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<ConferenceRecordingSavedPayload, ConferenceRecordingSavedPayloadFromRaw>))]
public sealed record class ConferenceRecordingSavedPayload : JsonModel
{
    /// <summary>
    /// Participant's call ID used to issue commands via Call Control API.
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
    /// Whether recording was recorded in `single` or `dual` channel.
    /// </summary>
    public ApiEnum<string, ConferenceRecordingSavedPayloadChannels>? Channels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConferenceRecordingSavedPayloadChannels>>(
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
    /// State received from a command.
    /// </summary>
    public string? ClientState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("client_state", value);
        }
    }

    /// <summary>
    /// ID of the conference that is being recorded.
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
    /// Call Control App ID (formerly Telnyx connection ID) used in the call.
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
    /// The audio file format used when storing the call recording. Can be either
    /// `mp3` or `wav`.
    /// </summary>
    public ApiEnum<string, Format>? Format {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Format>>(
                "format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("format", value);
        }
    }

    /// <summary>
    /// Recording URLs in requested format. The URL is valid for as long as the file
    /// exists. For security purposes, this feature is activated on a per request
    /// basis.  Please contact customer support with your Account ID to request activation.
    /// </summary>
    public ConferenceRecordingSavedPayloadPublicRecordingUrls? PublicRecordingUrls {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceRecordingSavedPayloadPublicRecordingUrls>(
                "public_recording_urls"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("public_recording_urls", value);
        }
    }

    /// <summary>
    /// ISO 8601 datetime of when recording ended.
    /// </summary>
    public System::DateTimeOffset? RecordingEndedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// ID of the conference recording.
    /// </summary>
    public string? RecordingID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recording_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recording_id", value);
        }
    }

    /// <summary>
    /// ISO 8601 datetime of when recording started.
    /// </summary>
    public System::DateTimeOffset? RecordingStartedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// Recording URLs in requested format. These URLs are valid for 10 minutes.
    /// After 10 minutes, you may retrieve recordings via API using Reports -&gt;
    /// Call Recordings documentation, or via Mission Control under Reporting -&gt; Recordings.
    /// </summary>
    public ConferenceRecordingSavedPayloadRecordingUrls? RecordingUrls {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceRecordingSavedPayloadRecordingUrls>(
                "recording_urls"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recording_urls", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallSessionID;
        this.Channels?.Validate();
        _ = this.ClientState;
        _ = this.ConferenceID;
        _ = this.ConnectionID;
        this.Format?.Validate();
        this.PublicRecordingUrls?.Validate();
        _ = this.RecordingEndedAt;
        _ = this.RecordingID;
        _ = this.RecordingStartedAt;
        this.RecordingUrls?.Validate();
    }

    public ConferenceRecordingSavedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceRecordingSavedPayload (
        ConferenceRecordingSavedPayload conferenceRecordingSavedPayload
    ) : base(conferenceRecordingSavedPayload)
    {  }
    #pragma warning restore CS8618

    public ConferenceRecordingSavedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceRecordingSavedPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceRecordingSavedPayloadFromRaw.FromRawUnchecked"/>
    public static ConferenceRecordingSavedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ConferenceRecordingSavedPayloadFromRaw : IFromRawJson<ConferenceRecordingSavedPayload>
{
    /// <inheritdoc/>
    public ConferenceRecordingSavedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceRecordingSavedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Whether recording was recorded in `single` or `dual` channel.
/// </summary>
[JsonConverter(typeof(ConferenceRecordingSavedPayloadChannelsConverter))]
public enum ConferenceRecordingSavedPayloadChannels
{
    Single, Dual
}sealed class ConferenceRecordingSavedPayloadChannelsConverter : JsonConverter<ConferenceRecordingSavedPayloadChannels>
{
    public override ConferenceRecordingSavedPayloadChannels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "single"=>ConferenceRecordingSavedPayloadChannels.Single,
            "dual"=>ConferenceRecordingSavedPayloadChannels.Dual,
            _ =>(ConferenceRecordingSavedPayloadChannels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceRecordingSavedPayloadChannels value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceRecordingSavedPayloadChannels.Single=>"single",
            ConferenceRecordingSavedPayloadChannels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The audio file format used when storing the call recording. Can be either `mp3`
/// or `wav`.
/// </summary>
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Wav, Mp3
}sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "wav"=>Format.Wav, "mp3"=>Format.Mp3, _ =>(Format)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Format value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Format.Wav=>"wav",
            Format.Mp3=>"mp3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Recording URLs in requested format. The URL is valid for as long as the file exists.
/// For security purposes, this feature is activated on a per request basis.  Please
/// contact customer support with your Account ID to request activation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConferenceRecordingSavedPayloadPublicRecordingUrls, ConferenceRecordingSavedPayloadPublicRecordingUrlsFromRaw>))]
public sealed record class ConferenceRecordingSavedPayloadPublicRecordingUrls : JsonModel
{
    /// <summary>
    /// Recording URL in requested `mp3` format.
    /// </summary>
    public string? Mp3 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mp3"
            );
        }
        init { this._rawData.Set("mp3", value); }
    }

    /// <summary>
    /// Recording URL in requested `wav` format.
    /// </summary>
    public string? Wav {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wav"
            );
        }
        init { this._rawData.Set("wav", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Mp3;
        _ = this.Wav;
    }

    public ConferenceRecordingSavedPayloadPublicRecordingUrls ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceRecordingSavedPayloadPublicRecordingUrls (
        ConferenceRecordingSavedPayloadPublicRecordingUrls conferenceRecordingSavedPayloadPublicRecordingUrls
    ) : base(conferenceRecordingSavedPayloadPublicRecordingUrls)
    {  }
    #pragma warning restore CS8618

    public ConferenceRecordingSavedPayloadPublicRecordingUrls (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceRecordingSavedPayloadPublicRecordingUrls (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceRecordingSavedPayloadPublicRecordingUrlsFromRaw.FromRawUnchecked"/>
    public static ConferenceRecordingSavedPayloadPublicRecordingUrls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ConferenceRecordingSavedPayloadPublicRecordingUrlsFromRaw : IFromRawJson<ConferenceRecordingSavedPayloadPublicRecordingUrls>
{
    /// <inheritdoc/>
    public ConferenceRecordingSavedPayloadPublicRecordingUrls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceRecordingSavedPayloadPublicRecordingUrls.FromRawUnchecked(rawData);
}/// <summary>
/// Recording URLs in requested format. These URLs are valid for 10 minutes. After
/// 10 minutes, you may retrieve recordings via API using Reports -&gt; Call Recordings
/// documentation, or via Mission Control under Reporting -&gt; Recordings.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConferenceRecordingSavedPayloadRecordingUrls, ConferenceRecordingSavedPayloadRecordingUrlsFromRaw>))]
public sealed record class ConferenceRecordingSavedPayloadRecordingUrls : JsonModel
{
    /// <summary>
    /// Recording URL in requested `mp3` format.
    /// </summary>
    public string? Mp3 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mp3"
            );
        }
        init { this._rawData.Set("mp3", value); }
    }

    /// <summary>
    /// Recording URL in requested `wav` format.
    /// </summary>
    public string? Wav {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wav"
            );
        }
        init { this._rawData.Set("wav", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Mp3;
        _ = this.Wav;
    }

    public ConferenceRecordingSavedPayloadRecordingUrls ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceRecordingSavedPayloadRecordingUrls (
        ConferenceRecordingSavedPayloadRecordingUrls conferenceRecordingSavedPayloadRecordingUrls
    ) : base(conferenceRecordingSavedPayloadRecordingUrls)
    {  }
    #pragma warning restore CS8618

    public ConferenceRecordingSavedPayloadRecordingUrls (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceRecordingSavedPayloadRecordingUrls (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceRecordingSavedPayloadRecordingUrlsFromRaw.FromRawUnchecked"/>
    public static ConferenceRecordingSavedPayloadRecordingUrls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ConferenceRecordingSavedPayloadRecordingUrlsFromRaw : IFromRawJson<ConferenceRecordingSavedPayloadRecordingUrls>
{
    /// <inheritdoc/>
    public ConferenceRecordingSavedPayloadRecordingUrls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceRecordingSavedPayloadRecordingUrls.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(ConferenceRecordingSavedRecordTypeConverter))]
public enum ConferenceRecordingSavedRecordType
{
    Event
}sealed class ConferenceRecordingSavedRecordTypeConverter : JsonConverter<ConferenceRecordingSavedRecordType>
{
    public override ConferenceRecordingSavedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>ConferenceRecordingSavedRecordType.Event,
            _ =>(ConferenceRecordingSavedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceRecordingSavedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceRecordingSavedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}