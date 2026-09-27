using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TrafficPolicyProfiles;

[JsonConverter(typeof(JsonModelConverter<TrafficPolicyProfileRetrieveResponse, TrafficPolicyProfileRetrieveResponseFromRaw>))]
public sealed record class TrafficPolicyProfileRetrieveResponse : JsonModel
{
    public TrafficPolicyProfile? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TrafficPolicyProfile>(
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

    public TrafficPolicyProfileRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrafficPolicyProfileRetrieveResponse (
        TrafficPolicyProfileRetrieveResponse trafficPolicyProfileRetrieveResponse
    ) : base(trafficPolicyProfileRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public TrafficPolicyProfileRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TrafficPolicyProfileRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TrafficPolicyProfileRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static TrafficPolicyProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TrafficPolicyProfileRetrieveResponseFromRaw : IFromRawJson<TrafficPolicyProfileRetrieveResponse>
{
    /// <inheritdoc/>
    public TrafficPolicyProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TrafficPolicyProfileRetrieveResponse.FromRawUnchecked(rawData);
}