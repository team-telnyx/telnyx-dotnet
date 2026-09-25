using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences;

[JsonConverter(typeof(JsonModelConverter<ConferenceRetrieveResponse, ConferenceRetrieveResponseFromRaw>))]
public sealed record class ConferenceRetrieveResponse : JsonModel
{
    public Conference? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Conference>(
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

    public ConferenceRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceRetrieveResponse (
        ConferenceRetrieveResponse conferenceRetrieveResponse
    ) : base(conferenceRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ConferenceRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ConferenceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceRetrieveResponseFromRaw : IFromRawJson<ConferenceRetrieveResponse>
{
    /// <inheritdoc/>
    public ConferenceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceRetrieveResponse.FromRawUnchecked(rawData);
}