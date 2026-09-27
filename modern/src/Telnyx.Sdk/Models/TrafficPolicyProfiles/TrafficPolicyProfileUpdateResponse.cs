using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TrafficPolicyProfiles;

[JsonConverter(typeof(JsonModelConverter<TrafficPolicyProfileUpdateResponse, TrafficPolicyProfileUpdateResponseFromRaw>))]
public sealed record class TrafficPolicyProfileUpdateResponse : JsonModel
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

    public TrafficPolicyProfileUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrafficPolicyProfileUpdateResponse (
        TrafficPolicyProfileUpdateResponse trafficPolicyProfileUpdateResponse
    ) : base(trafficPolicyProfileUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public TrafficPolicyProfileUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TrafficPolicyProfileUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TrafficPolicyProfileUpdateResponseFromRaw.FromRawUnchecked"/>
    public static TrafficPolicyProfileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TrafficPolicyProfileUpdateResponseFromRaw : IFromRawJson<TrafficPolicyProfileUpdateResponse>
{
    /// <inheritdoc/>
    public TrafficPolicyProfileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TrafficPolicyProfileUpdateResponse.FromRawUnchecked(rawData);
}