using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences;

[JsonConverter(typeof(JsonModelConverter<ConferenceCreateResponse, ConferenceCreateResponseFromRaw>))]
public sealed record class ConferenceCreateResponse : JsonModel
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

    public ConferenceCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceCreateResponse (
        ConferenceCreateResponse conferenceCreateResponse
    ) : base(conferenceCreateResponse)
    {  }
    #pragma warning restore CS8618

    public ConferenceCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceCreateResponseFromRaw.FromRawUnchecked"/>
    public static ConferenceCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceCreateResponseFromRaw : IFromRawJson<ConferenceCreateResponse>
{
    /// <inheritdoc/>
    public ConferenceCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceCreateResponse.FromRawUnchecked(rawData);
}