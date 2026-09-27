using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Porting.Events;

[JsonConverter(typeof(JsonModelConverter<EventRetrieveResponse, EventRetrieveResponseFromRaw>))]
public sealed record class EventRetrieveResponse : JsonModel
{
    public PortingEvent? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingEvent>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public EventRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventRetrieveResponse (
        EventRetrieveResponse eventRetrieveResponse
    ) : base(eventRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public EventRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EventRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EventRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static EventRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EventRetrieveResponseFromRaw : IFromRawJson<EventRetrieveResponse>
{
    /// <inheritdoc/>
    public EventRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EventRetrieveResponse.FromRawUnchecked(rawData);
}