using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<RecordingAvailableWebhookEvent, RecordingAvailableWebhookEventFromRaw>))]
public sealed record class RecordingAvailableWebhookEvent : JsonModel
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
    /// Available recording types.
    /// </summary>
    public required RecordingAvailableWebhookEventData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RecordingAvailableWebhookEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Event type.
    /// </summary>
    public required ApiEnum<string, RecordingAvailableWebhookEventEvent> Event {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordingAvailableWebhookEventEvent>>(
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

    public RecordingAvailableWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordingAvailableWebhookEvent (
        RecordingAvailableWebhookEvent recordingAvailableWebhookEvent
    ) : base(recordingAvailableWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public RecordingAvailableWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordingAvailableWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordingAvailableWebhookEventFromRaw.FromRawUnchecked"/>
    public static RecordingAvailableWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RecordingAvailableWebhookEventFromRaw : IFromRawJson<RecordingAvailableWebhookEvent>
{
    /// <inheritdoc/>
    public RecordingAvailableWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecordingAvailableWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Available recording types.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RecordingAvailableWebhookEventData, RecordingAvailableWebhookEventDataFromRaw>))]
public sealed record class RecordingAvailableWebhookEventData : JsonModel
{
    /// <summary>
    /// Available recording types.
    /// </summary>
    public required IReadOnlyList<string> RecordingTypes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "recording_types"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "recording_types",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        _ = this.RecordingTypes;
        _ = this.SessionID;
    }

    public RecordingAvailableWebhookEventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordingAvailableWebhookEventData (
        RecordingAvailableWebhookEventData recordingAvailableWebhookEventData
    ) : base(recordingAvailableWebhookEventData)
    {  }
    #pragma warning restore CS8618

    public RecordingAvailableWebhookEventData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordingAvailableWebhookEventData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordingAvailableWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static RecordingAvailableWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RecordingAvailableWebhookEventDataFromRaw : IFromRawJson<RecordingAvailableWebhookEventData>
{
    /// <inheritdoc/>
    public RecordingAvailableWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecordingAvailableWebhookEventData.FromRawUnchecked(rawData);
}/// <summary>
/// Event type.
/// </summary>
[JsonConverter(typeof(RecordingAvailableWebhookEventEventConverter))]
public enum RecordingAvailableWebhookEventEvent
{
    RecordingAvailable
}sealed class RecordingAvailableWebhookEventEventConverter : JsonConverter<RecordingAvailableWebhookEventEvent>
{
    public override RecordingAvailableWebhookEventEvent Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "recording.available"=>RecordingAvailableWebhookEventEvent.RecordingAvailable,
            _ =>(RecordingAvailableWebhookEventEvent)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecordingAvailableWebhookEventEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordingAvailableWebhookEventEvent.RecordingAvailable=>"recording.available",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}