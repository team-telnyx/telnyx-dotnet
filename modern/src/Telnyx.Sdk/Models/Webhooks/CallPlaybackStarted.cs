using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallPlaybackStarted, CallPlaybackStartedFromRaw>))]
public sealed record class CallPlaybackStarted : JsonModel
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
    public ApiEnum<string, CallPlaybackStartedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallPlaybackStartedEventType>>(
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

    public CallPlaybackStartedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallPlaybackStartedPayload>(
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
    public ApiEnum<string, CallPlaybackStartedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallPlaybackStartedRecordType>>(
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

    public CallPlaybackStarted ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallPlaybackStarted (CallPlaybackStarted callPlaybackStarted) : base(
        callPlaybackStarted
    )
    {  }
    #pragma warning restore CS8618

    public CallPlaybackStarted (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallPlaybackStarted (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallPlaybackStartedFromRaw.FromRawUnchecked"/>
    public static CallPlaybackStarted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallPlaybackStartedFromRaw : IFromRawJson<CallPlaybackStarted>
{
    /// <inheritdoc/>
    public CallPlaybackStarted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallPlaybackStarted.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallPlaybackStartedEventTypeConverter))]
public enum CallPlaybackStartedEventType
{
    CallPlaybackStarted
}sealed class CallPlaybackStartedEventTypeConverter : JsonConverter<CallPlaybackStartedEventType>
{
    public override CallPlaybackStartedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.playback.started"=>CallPlaybackStartedEventType.CallPlaybackStarted,
            _ =>(CallPlaybackStartedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallPlaybackStartedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallPlaybackStartedEventType.CallPlaybackStarted=>"call.playback.started",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallPlaybackStartedPayload, CallPlaybackStartedPayloadFromRaw>))]
public sealed record class CallPlaybackStartedPayload : JsonModel
{
    /// <summary>
    /// Call ID used to issue commands via Call Control API.
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
    /// The name of the audio media file being played back, if media_name has been
    /// used to start.
    /// </summary>
    public string? MediaName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "media_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("media_name", value);
        }
    }

    /// <summary>
    /// The audio URL being played back, if audio_url has been used to start.
    /// </summary>
    public string? MediaUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "media_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("media_url", value);
        }
    }

    /// <summary>
    /// Whether the audio is going to be played in overlay mode or not.
    /// </summary>
    public bool? Overlay {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "overlay"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("overlay", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.ClientState;
        _ = this.ConnectionID;
        _ = this.MediaName;
        _ = this.MediaUrl;
        _ = this.Overlay;
    }

    public CallPlaybackStartedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallPlaybackStartedPayload (
        CallPlaybackStartedPayload callPlaybackStartedPayload
    ) : base(callPlaybackStartedPayload)
    {  }
    #pragma warning restore CS8618

    public CallPlaybackStartedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallPlaybackStartedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallPlaybackStartedPayloadFromRaw.FromRawUnchecked"/>
    public static CallPlaybackStartedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallPlaybackStartedPayloadFromRaw : IFromRawJson<CallPlaybackStartedPayload>
{
    /// <inheritdoc/>
    public CallPlaybackStartedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallPlaybackStartedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallPlaybackStartedRecordTypeConverter))]
public enum CallPlaybackStartedRecordType
{
    Event
}sealed class CallPlaybackStartedRecordTypeConverter : JsonConverter<CallPlaybackStartedRecordType>
{
    public override CallPlaybackStartedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallPlaybackStartedRecordType.Event,
            _ =>(CallPlaybackStartedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallPlaybackStartedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallPlaybackStartedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}