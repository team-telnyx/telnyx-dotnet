using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferencePlaybackStarted, ConferencePlaybackStartedFromRaw>))]
public sealed record class ConferencePlaybackStarted : JsonModel
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
    public ApiEnum<string, ConferencePlaybackStartedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConferencePlaybackStartedEventType>>(
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

    public ConferencePlaybackStartedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferencePlaybackStartedPayload>(
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
    public ApiEnum<string, ConferencePlaybackStartedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConferencePlaybackStartedRecordType>>(
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

    public ConferencePlaybackStarted ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferencePlaybackStarted (
        ConferencePlaybackStarted conferencePlaybackStarted
    ) : base(conferencePlaybackStarted)
    {  }
    #pragma warning restore CS8618

    public ConferencePlaybackStarted (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferencePlaybackStarted (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferencePlaybackStartedFromRaw.FromRawUnchecked"/>
    public static ConferencePlaybackStarted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferencePlaybackStartedFromRaw : IFromRawJson<ConferencePlaybackStarted>
{
    /// <inheritdoc/>
    public ConferencePlaybackStarted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferencePlaybackStarted.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(ConferencePlaybackStartedEventTypeConverter))]
public enum ConferencePlaybackStartedEventType
{
    ConferencePlaybackStarted
}sealed class ConferencePlaybackStartedEventTypeConverter : JsonConverter<ConferencePlaybackStartedEventType>
{
    public override ConferencePlaybackStartedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "conference.playback.started"=>ConferencePlaybackStartedEventType.ConferencePlaybackStarted,
            _ =>(ConferencePlaybackStartedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferencePlaybackStartedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferencePlaybackStartedEventType.ConferencePlaybackStarted=>"conference.playback.started",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<ConferencePlaybackStartedPayload, ConferencePlaybackStartedPayloadFromRaw>))]
public sealed record class ConferencePlaybackStartedPayload : JsonModel
{
    /// <summary>
    /// ID of the conference the text was spoken in.
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
    /// ID that is unique to the call session that started the conference.
    /// </summary>
    public string? CreatorCallSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "creator_call_session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("creator_call_session_id", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConferenceID;
        _ = this.ConnectionID;
        _ = this.CreatorCallSessionID;
        _ = this.MediaName;
        _ = this.MediaUrl;
        _ = this.OccurredAt;
    }

    public ConferencePlaybackStartedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferencePlaybackStartedPayload (
        ConferencePlaybackStartedPayload conferencePlaybackStartedPayload
    ) : base(conferencePlaybackStartedPayload)
    {  }
    #pragma warning restore CS8618

    public ConferencePlaybackStartedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferencePlaybackStartedPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferencePlaybackStartedPayloadFromRaw.FromRawUnchecked"/>
    public static ConferencePlaybackStartedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ConferencePlaybackStartedPayloadFromRaw : IFromRawJson<ConferencePlaybackStartedPayload>
{
    /// <inheritdoc/>
    public ConferencePlaybackStartedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferencePlaybackStartedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(ConferencePlaybackStartedRecordTypeConverter))]
public enum ConferencePlaybackStartedRecordType
{
    Event
}sealed class ConferencePlaybackStartedRecordTypeConverter : JsonConverter<ConferencePlaybackStartedRecordType>
{
    public override ConferencePlaybackStartedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>ConferencePlaybackStartedRecordType.Event,
            _ =>(ConferencePlaybackStartedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferencePlaybackStartedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferencePlaybackStartedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}