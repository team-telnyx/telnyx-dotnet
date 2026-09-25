using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.Events;

[JsonConverter(typeof(JsonModelConverter<EventData, EventDataFromRaw>))]
public sealed record class EventData : JsonModel
{
    public required string EventID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "event_id"
            );
        }
        init { this._rawData.Set("event_id", value); }
    }

    public required string RunID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "run_id"
            );
        }
        init { this._rawData.Set("run_id", value); }
    }

    public required string Summary {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "summary"
            );
        }
        init { this._rawData.Set("summary", value); }
    }

    public required DateTimeOffset Timestamp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "timestamp"
            );
        }
        init { this._rawData.Set("timestamp", value); }
    }

    public required ApiEnum<string, EventType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public string? AgentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "agent_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("agent_id", value);
        }
    }

    public string? IdempotencyKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "idempotency_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("idempotency_key", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "payload",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? StepID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "step_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("step_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EventID;
        _ = this.RunID;
        _ = this.Summary;
        _ = this.Timestamp;
        this.Type.Validate();
        _ = this.AgentID;
        _ = this.IdempotencyKey;
        _ = this.Payload;
        _ = this.StepID;
    }

    public EventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventData (EventData eventData) : base(eventData)
    {  }
    #pragma warning restore CS8618

    public EventData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EventData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EventDataFromRaw.FromRawUnchecked"/>
    public static EventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EventDataFromRaw : IFromRawJson<EventData>
{
    /// <inheritdoc/>
    public EventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EventData.FromRawUnchecked(rawData);
}