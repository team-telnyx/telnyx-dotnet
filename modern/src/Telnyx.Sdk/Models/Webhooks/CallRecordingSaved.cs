using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallRecordingSaved, CallRecordingSavedFromRaw>))]
public sealed record class CallRecordingSaved : JsonModel
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
    public ApiEnum<string, CallRecordingSavedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallRecordingSavedEventType>>(
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

    /// <summary>
    /// ISO 8601 datetime of when the event occurred.
    /// </summary>
    public System::DateTimeOffset? OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("occurred_at", value);
        }
    }

    public CallRecordingSavedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallRecordingSavedPayload>(
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
    public ApiEnum<string, CallRecordingSavedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallRecordingSavedRecordType>>(
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
        _ = this.OccurredAt;
        this.Payload?.Validate();
        this.RecordType?.Validate();
    }

    public CallRecordingSaved ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRecordingSaved (CallRecordingSaved callRecordingSaved) : base(
        callRecordingSaved
    )
    {  }
    #pragma warning restore CS8618

    public CallRecordingSaved (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRecordingSaved (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRecordingSavedFromRaw.FromRawUnchecked"/>
    public static CallRecordingSaved FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallRecordingSavedFromRaw : IFromRawJson<CallRecordingSaved>
{
    /// <inheritdoc/>
    public CallRecordingSaved FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRecordingSaved.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallRecordingSavedEventTypeConverter))]
public enum CallRecordingSavedEventType
{
    CallRecordingSaved
}sealed class CallRecordingSavedEventTypeConverter : JsonConverter<CallRecordingSavedEventType>
{
    public override CallRecordingSavedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.recording.saved"=>CallRecordingSavedEventType.CallRecordingSaved,
            _ =>(CallRecordingSavedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRecordingSavedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallRecordingSavedEventType.CallRecordingSaved=>"call.recording.saved",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallRecordingSavedPayload, CallRecordingSavedPayloadFromRaw>))]
public sealed record class CallRecordingSavedPayload : JsonModel
{
    /// <summary>
    /// ID that is unique to the call and can be used to correlate webhook events.
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
    /// Whether recording was recorded in `single` or `dual` channel.
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
    /// Recording URLs in requested format. The URL is valid for as long as the file
    /// exists. For security purposes, this feature is activated on a per request
    /// basis.  Please contact customer support with your Account ID to request activation.
    /// </summary>
    public PublicRecordingUrls? PublicRecordingUrls {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PublicRecordingUrls>(
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
    public RecordingUrls? RecordingUrls {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RecordingUrls>(
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
        _ = this.CallLegID;
        _ = this.CallSessionID;
        this.Channels?.Validate();
        _ = this.ClientState;
        _ = this.ConnectionID;
        this.PublicRecordingUrls?.Validate();
        _ = this.RecordingEndedAt;
        _ = this.RecordingStartedAt;
        this.RecordingUrls?.Validate();
    }

    public CallRecordingSavedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRecordingSavedPayload (
        CallRecordingSavedPayload callRecordingSavedPayload
    ) : base(callRecordingSavedPayload)
    {  }
    #pragma warning restore CS8618

    public CallRecordingSavedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRecordingSavedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRecordingSavedPayloadFromRaw.FromRawUnchecked"/>
    public static CallRecordingSavedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallRecordingSavedPayloadFromRaw : IFromRawJson<CallRecordingSavedPayload>
{
    /// <inheritdoc/>
    public CallRecordingSavedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRecordingSavedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Whether recording was recorded in `single` or `dual` channel.
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
/// Recording URLs in requested format. The URL is valid for as long as the file exists.
/// For security purposes, this feature is activated on a per request basis.  Please
/// contact customer support with your Account ID to request activation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PublicRecordingUrls, PublicRecordingUrlsFromRaw>))]
public sealed record class PublicRecordingUrls : JsonModel
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

    public PublicRecordingUrls ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PublicRecordingUrls (PublicRecordingUrls publicRecordingUrls) : base(
        publicRecordingUrls
    )
    {  }
    #pragma warning restore CS8618

    public PublicRecordingUrls (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PublicRecordingUrls (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PublicRecordingUrlsFromRaw.FromRawUnchecked"/>
    public static PublicRecordingUrls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PublicRecordingUrlsFromRaw : IFromRawJson<PublicRecordingUrls>
{
    /// <inheritdoc/>
    public PublicRecordingUrls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PublicRecordingUrls.FromRawUnchecked(rawData);
}/// <summary>
/// Recording URLs in requested format. These URLs are valid for 10 minutes. After
/// 10 minutes, you may retrieve recordings via API using Reports -&gt; Call Recordings
/// documentation, or via Mission Control under Reporting -&gt; Recordings.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RecordingUrls, RecordingUrlsFromRaw>))]
public sealed record class RecordingUrls : JsonModel
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

    public RecordingUrls ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordingUrls (RecordingUrls recordingUrls) : base(recordingUrls)
    {  }
    #pragma warning restore CS8618

    public RecordingUrls (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordingUrls (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordingUrlsFromRaw.FromRawUnchecked"/>
    public static RecordingUrls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RecordingUrlsFromRaw : IFromRawJson<RecordingUrls>
{
    /// <inheritdoc/>
    public RecordingUrls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecordingUrls.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallRecordingSavedRecordTypeConverter))]
public enum CallRecordingSavedRecordType
{
    Event
}sealed class CallRecordingSavedRecordTypeConverter : JsonConverter<CallRecordingSavedRecordType>
{
    public override CallRecordingSavedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallRecordingSavedRecordType.Event,
            _ =>(CallRecordingSavedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRecordingSavedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallRecordingSavedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}