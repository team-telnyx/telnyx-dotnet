using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<TranscriptCompletedWebhookEvent, TranscriptCompletedWebhookEventFromRaw>))]
public sealed record class TranscriptCompletedWebhookEvent : JsonModel
{
    /// <summary>
    /// Unique event id; deduplicate deliveries on it.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Finalized transcript details.
    /// </summary>
    public required TranscriptCompletedWebhookEventData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TranscriptCompletedWebhookEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Event type.
    /// </summary>
    public required ApiEnum<string, TranscriptCompletedWebhookEventEvent> Event {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TranscriptCompletedWebhookEventEvent>>(
                "event"
            );
        }
        init { this._rawData.Set("event", value); }
    }

    /// <summary>
    /// When the event occurred.
    /// </summary>
    public required System::DateTimeOffset OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init { this._rawData.Set("occurred_at", value); }
    }

    /// <summary>
    /// Envelope version.
    /// </summary>
    public required string Version {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "version"
            );
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Data.Validate();
        this.Event.Validate();
        _ = this.OccurredAt;
        _ = this.Version;
    }

    public TranscriptCompletedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptCompletedWebhookEvent (
        TranscriptCompletedWebhookEvent transcriptCompletedWebhookEvent
    ) : base(transcriptCompletedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public TranscriptCompletedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptCompletedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptCompletedWebhookEventFromRaw.FromRawUnchecked"/>
    public static TranscriptCompletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptCompletedWebhookEventFromRaw : IFromRawJson<TranscriptCompletedWebhookEvent>
{
    /// <inheritdoc/>
    public TranscriptCompletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptCompletedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Finalized transcript details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TranscriptCompletedWebhookEventData, TranscriptCompletedWebhookEventDataFromRaw>))]
public sealed record class TranscriptCompletedWebhookEventData : JsonModel
{
    /// <summary>
    /// Session end time, or null when unavailable.
    /// </summary>
    public required System::DateTimeOffset? EndedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "ended_at"
            );
        }
        init { this._rawData.Set("ended_at", value); }
    }

    /// <summary>
    /// Last transcript segment sequence number, or null for an empty transcript.
    /// </summary>
    public required long? LastSeq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "last_seq"
            );
        }
        init { this._rawData.Set("last_seq", value); }
    }

    /// <summary>
    /// Number of transcript segments observed during finalization.
    /// </summary>
    public required long SegmentCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "segment_count"
            );
        }
        init { this._rawData.Set("segment_count", value); }
    }

    /// <summary>
    /// The meeting session this event belongs to.
    /// </summary>
    public required string SessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "session_id"
            );
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndedAt;
        _ = this.LastSeq;
        _ = this.SegmentCount;
        _ = this.SessionID;
    }

    public TranscriptCompletedWebhookEventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptCompletedWebhookEventData (
        TranscriptCompletedWebhookEventData transcriptCompletedWebhookEventData
    ) : base(transcriptCompletedWebhookEventData)
    {  }
    #pragma warning restore CS8618

    public TranscriptCompletedWebhookEventData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptCompletedWebhookEventData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptCompletedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static TranscriptCompletedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TranscriptCompletedWebhookEventDataFromRaw : IFromRawJson<TranscriptCompletedWebhookEventData>
{
    /// <inheritdoc/>
    public TranscriptCompletedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptCompletedWebhookEventData.FromRawUnchecked(rawData);
}/// <summary>
/// Event type.
/// </summary>
[JsonConverter(typeof(TranscriptCompletedWebhookEventEventConverter))]
public enum TranscriptCompletedWebhookEventEvent
{
    TranscriptCompleted
}sealed class TranscriptCompletedWebhookEventEventConverter : JsonConverter<TranscriptCompletedWebhookEventEvent>
{
    public override TranscriptCompletedWebhookEventEvent Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transcript.completed"=>TranscriptCompletedWebhookEventEvent.TranscriptCompleted,
            _ =>(TranscriptCompletedWebhookEventEvent)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptCompletedWebhookEventEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptCompletedWebhookEventEvent.TranscriptCompleted=>"transcript.completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}