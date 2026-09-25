using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.Events;

[JsonConverter(typeof(JsonModelConverter<EventResponse, EventResponseFromRaw>))]
public sealed record class EventResponse : JsonModel
{
    public required EventData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EventResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventResponse (EventResponse eventResponse) : base(eventResponse)
    {  }
    #pragma warning restore CS8618

    public EventResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EventResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EventResponseFromRaw.FromRawUnchecked"/>
    public static EventResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EventResponse (EventData data) : this()
    { this.Data = data; }
}

class EventResponseFromRaw : IFromRawJson<EventResponse>
{
    /// <inheritdoc/>
    public EventResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EventResponse.FromRawUnchecked(rawData);
}