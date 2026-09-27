using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.VirtualCrossConnectsCoverage;

[JsonConverter(typeof(JsonModelConverter<VirtualCrossConnectsCoverageListPageResponse, VirtualCrossConnectsCoverageListPageResponseFromRaw>))]
public sealed record class VirtualCrossConnectsCoverageListPageResponse : JsonModel
{
    public IReadOnlyList<VirtualCrossConnectsCoverageListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<VirtualCrossConnectsCoverageListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<VirtualCrossConnectsCoverageListResponse>?>(
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

    public VirtualCrossConnectsCoverageListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VirtualCrossConnectsCoverageListPageResponse (
        VirtualCrossConnectsCoverageListPageResponse virtualCrossConnectsCoverageListPageResponse
    ) : base(virtualCrossConnectsCoverageListPageResponse)
    {  }
    #pragma warning restore CS8618

    public VirtualCrossConnectsCoverageListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VirtualCrossConnectsCoverageListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VirtualCrossConnectsCoverageListPageResponseFromRaw.FromRawUnchecked"/>
    public static VirtualCrossConnectsCoverageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VirtualCrossConnectsCoverageListPageResponseFromRaw : IFromRawJson<VirtualCrossConnectsCoverageListPageResponse>
{
    /// <inheritdoc/>
    public VirtualCrossConnectsCoverageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VirtualCrossConnectsCoverageListPageResponse.FromRawUnchecked(rawData);
}