using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Runs = Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites.Runs;

namespace Telnyx.Sdk.Models.AI.Clusters;

[JsonConverter(typeof(JsonModelConverter<ClusterListPageResponse, ClusterListPageResponseFromRaw>))]
public sealed record class ClusterListPageResponse : JsonModel
{
    public required IReadOnlyList<ClusterListResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ClusterListResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ClusterListResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Runs::Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Runs::Meta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public ClusterListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClusterListPageResponse (
        ClusterListPageResponse clusterListPageResponse
    ) : base(clusterListPageResponse)
    {  }
    #pragma warning restore CS8618

    public ClusterListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ClusterListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ClusterListPageResponseFromRaw.FromRawUnchecked"/>
    public static ClusterListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ClusterListPageResponseFromRaw : IFromRawJson<ClusterListPageResponse>
{
    /// <inheritdoc/>
    public ClusterListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ClusterListPageResponse.FromRawUnchecked(rawData);
}