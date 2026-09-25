using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.NetworkCoverage;

[JsonConverter(typeof(JsonModelConverter<NetworkCoverageListPageResponse, NetworkCoverageListPageResponseFromRaw>))]
public sealed record class NetworkCoverageListPageResponse : JsonModel
{
    public IReadOnlyList<NetworkCoverageListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<NetworkCoverageListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<NetworkCoverageListResponse>?>(
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

    public NetworkCoverageListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkCoverageListPageResponse (
        NetworkCoverageListPageResponse networkCoverageListPageResponse
    ) : base(networkCoverageListPageResponse)
    {  }
    #pragma warning restore CS8618

    public NetworkCoverageListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkCoverageListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NetworkCoverageListPageResponseFromRaw.FromRawUnchecked"/>
    public static NetworkCoverageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NetworkCoverageListPageResponseFromRaw : IFromRawJson<NetworkCoverageListPageResponse>
{
    /// <inheritdoc/>
    public NetworkCoverageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NetworkCoverageListPageResponse.FromRawUnchecked(rawData);
}