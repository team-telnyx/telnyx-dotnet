using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TrafficPolicyProfiles;

[JsonConverter(typeof(JsonModelConverter<TrafficPolicyProfileCreateResponse, TrafficPolicyProfileCreateResponseFromRaw>))]
public sealed record class TrafficPolicyProfileCreateResponse : JsonModel
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

    public TrafficPolicyProfileCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrafficPolicyProfileCreateResponse (
        TrafficPolicyProfileCreateResponse trafficPolicyProfileCreateResponse
    ) : base(trafficPolicyProfileCreateResponse)
    {  }
    #pragma warning restore CS8618

    public TrafficPolicyProfileCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TrafficPolicyProfileCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TrafficPolicyProfileCreateResponseFromRaw.FromRawUnchecked"/>
    public static TrafficPolicyProfileCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TrafficPolicyProfileCreateResponseFromRaw : IFromRawJson<TrafficPolicyProfileCreateResponse>
{
    /// <inheritdoc/>
    public TrafficPolicyProfileCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TrafficPolicyProfileCreateResponse.FromRawUnchecked(rawData);
}