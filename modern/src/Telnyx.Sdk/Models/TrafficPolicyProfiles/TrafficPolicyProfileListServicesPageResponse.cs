using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.TrafficPolicyProfiles;

[JsonConverter(typeof(JsonModelConverter<TrafficPolicyProfileListServicesPageResponse, TrafficPolicyProfileListServicesPageResponseFromRaw>))]
public sealed record class TrafficPolicyProfileListServicesPageResponse : JsonModel
{
    public IReadOnlyList<TrafficPolicyProfileListServicesResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TrafficPolicyProfileListServicesResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<TrafficPolicyProfileListServicesResponse>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public TrafficPolicyProfileListServicesPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrafficPolicyProfileListServicesPageResponse (
        TrafficPolicyProfileListServicesPageResponse trafficPolicyProfileListServicesPageResponse
    ) : base(trafficPolicyProfileListServicesPageResponse)
    {  }
    #pragma warning restore CS8618

    public TrafficPolicyProfileListServicesPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TrafficPolicyProfileListServicesPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TrafficPolicyProfileListServicesPageResponseFromRaw.FromRawUnchecked"/>
    public static TrafficPolicyProfileListServicesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TrafficPolicyProfileListServicesPageResponseFromRaw : IFromRawJson<TrafficPolicyProfileListServicesPageResponse>
{
    /// <inheritdoc/>
    public TrafficPolicyProfileListServicesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TrafficPolicyProfileListServicesPageResponse.FromRawUnchecked(rawData);
}