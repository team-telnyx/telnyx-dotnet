using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberAssignmentByProfile;

namespace Telnyx.Sdk.Models.AI.Clusters;

[JsonConverter(typeof(JsonModelConverter<ClusterRetrieveResponse, ClusterRetrieveResponseFromRaw>))]
public sealed record class ClusterRetrieveResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public ClusterRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClusterRetrieveResponse (
        ClusterRetrieveResponse clusterRetrieveResponse
    ) : base(clusterRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ClusterRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ClusterRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ClusterRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ClusterRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ClusterRetrieveResponse (Data data) : this()
    { this.Data = data; }
}

class ClusterRetrieveResponseFromRaw : IFromRawJson<ClusterRetrieveResponse>
{
    /// <inheritdoc/>
    public ClusterRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ClusterRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public required string Bucket {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "bucket"
            );
        }
        init { this._rawData.Set("bucket", value); }
    }

    public required IReadOnlyList<RecursiveCluster> Clusters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RecursiveCluster>>(
                "clusters"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<RecursiveCluster>>(
                "clusters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, TaskStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TaskStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bucket;
        foreach (var item in this.Clusters)
        {
            item.Validate();
        }
        this.Status.Validate();
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}