using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<SessionStatusChangedWebhookEvent, SessionStatusChangedWebhookEventFromRaw>))]
public sealed record class SessionStatusChangedWebhookEvent : JsonModel
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
    /// Status transition details.
    /// </summary>
    public required SessionStatusChangedWebhookEventData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionStatusChangedWebhookEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Event type.
    /// </summary>
    public required ApiEnum<string, SessionStatusChangedWebhookEventEvent> Event {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SessionStatusChangedWebhookEventEvent>>(
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

    public SessionStatusChangedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionStatusChangedWebhookEvent (
        SessionStatusChangedWebhookEvent sessionStatusChangedWebhookEvent
    ) : base(sessionStatusChangedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public SessionStatusChangedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionStatusChangedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionStatusChangedWebhookEventFromRaw.FromRawUnchecked"/>
    public static SessionStatusChangedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SessionStatusChangedWebhookEventFromRaw : IFromRawJson<SessionStatusChangedWebhookEvent>
{
    /// <inheritdoc/>
    public SessionStatusChangedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionStatusChangedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Status transition details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SessionStatusChangedWebhookEventData, SessionStatusChangedWebhookEventDataFromRaw>))]
public sealed record class SessionStatusChangedWebhookEventData : JsonModel
{
    /// <summary>
    /// Whether the session is recording at this lifecycle edge.
    /// </summary>
    public required bool Recording {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "recording"
            );
        }
        init { this._rawData.Set("recording", value); }
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

    /// <summary>
    /// The new session status.
    /// </summary>
    public required string Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Additional detail about the status (for example `timeout_exceeded_everyone_left`
    /// or `cancelled`), or null.
    /// </summary>
    public required string? StatusDetail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "status_detail"
            );
        }
        init { this._rawData.Set("status_detail", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Recording;
        _ = this.SessionID;
        _ = this.Status;
        _ = this.StatusDetail;
    }

    public SessionStatusChangedWebhookEventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionStatusChangedWebhookEventData (
        SessionStatusChangedWebhookEventData sessionStatusChangedWebhookEventData
    ) : base(sessionStatusChangedWebhookEventData)
    {  }
    #pragma warning restore CS8618

    public SessionStatusChangedWebhookEventData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionStatusChangedWebhookEventData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionStatusChangedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static SessionStatusChangedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SessionStatusChangedWebhookEventDataFromRaw : IFromRawJson<SessionStatusChangedWebhookEventData>
{
    /// <inheritdoc/>
    public SessionStatusChangedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionStatusChangedWebhookEventData.FromRawUnchecked(rawData);
}/// <summary>
/// Event type.
/// </summary>
[JsonConverter(typeof(SessionStatusChangedWebhookEventEventConverter))]
public enum SessionStatusChangedWebhookEventEvent
{
    SessionStatusChanged
}sealed class SessionStatusChangedWebhookEventEventConverter : JsonConverter<SessionStatusChangedWebhookEventEvent>
{
    public override SessionStatusChangedWebhookEventEvent Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session.status_changed"=>SessionStatusChangedWebhookEventEvent.SessionStatusChanged,
            _ =>(SessionStatusChangedWebhookEventEvent)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SessionStatusChangedWebhookEventEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SessionStatusChangedWebhookEventEvent.SessionStatusChanged=>"session.status_changed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}