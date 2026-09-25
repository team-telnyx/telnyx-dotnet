using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Runs = Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites.Runs;
using Telnyx.Sdk.Models.AI.Missions.Runs.Events;

namespace Telnyx.Sdk.Models.AI.Missions;

[JsonConverter(typeof(JsonModelConverter<EventsListResponse, EventsListResponseFromRaw>))]
public sealed record class EventsListResponse : JsonModel
{
    public required IReadOnlyList<EventData> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EventData>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EventData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Runs::Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Runs::Meta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public EventsListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventsListResponse (EventsListResponse eventsListResponse) : base(
        eventsListResponse
    )
    {  }
    #pragma warning restore CS8618

    public EventsListResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EventsListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EventsListResponseFromRaw.FromRawUnchecked"/>
    public static EventsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EventsListResponseFromRaw : IFromRawJson<EventsListResponse>
{
    /// <inheritdoc/>
    public EventsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EventsListResponse.FromRawUnchecked(rawData);
}