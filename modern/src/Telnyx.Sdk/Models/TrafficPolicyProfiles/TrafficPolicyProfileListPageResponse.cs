using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.TrafficPolicyProfiles;

[JsonConverter(typeof(JsonModelConverter<TrafficPolicyProfileListPageResponse, TrafficPolicyProfileListPageResponseFromRaw>))]
public sealed record class TrafficPolicyProfileListPageResponse : JsonModel
{
    public IReadOnlyList<TrafficPolicyProfile>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TrafficPolicyProfile>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<TrafficPolicyProfile>?>(
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

    public TrafficPolicyProfileListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrafficPolicyProfileListPageResponse (
        TrafficPolicyProfileListPageResponse trafficPolicyProfileListPageResponse
    ) : base(trafficPolicyProfileListPageResponse)
    {  }
    #pragma warning restore CS8618

    public TrafficPolicyProfileListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TrafficPolicyProfileListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TrafficPolicyProfileListPageResponseFromRaw.FromRawUnchecked"/>
    public static TrafficPolicyProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TrafficPolicyProfileListPageResponseFromRaw : IFromRawJson<TrafficPolicyProfileListPageResponse>
{
    /// <inheritdoc/>
    public TrafficPolicyProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TrafficPolicyProfileListPageResponse.FromRawUnchecked(rawData);
}