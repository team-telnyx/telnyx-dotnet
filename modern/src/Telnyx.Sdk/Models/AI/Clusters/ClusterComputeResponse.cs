using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Clusters;

[JsonConverter(typeof(JsonModelConverter<ClusterComputeResponse, ClusterComputeResponseFromRaw>))]
public sealed record class ClusterComputeResponse : JsonModel
{
    public required ClusterComputeResponseData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ClusterComputeResponseData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public ClusterComputeResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClusterComputeResponse (
        ClusterComputeResponse clusterComputeResponse
    ) : base(clusterComputeResponse)
    {  }
    #pragma warning restore CS8618

    public ClusterComputeResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ClusterComputeResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ClusterComputeResponseFromRaw.FromRawUnchecked"/>
    public static ClusterComputeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ClusterComputeResponse (ClusterComputeResponseData data) : this()
    { this.Data = data; }
}

class ClusterComputeResponseFromRaw : IFromRawJson<ClusterComputeResponse>
{
    /// <inheritdoc/>
    public ClusterComputeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ClusterComputeResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ClusterComputeResponseData, ClusterComputeResponseDataFromRaw>))]
public sealed record class ClusterComputeResponseData : JsonModel
{
    public required string TaskID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "task_id"
            );
        }
        init { this._rawData.Set("task_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.TaskID; }

    public ClusterComputeResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClusterComputeResponseData (
        ClusterComputeResponseData clusterComputeResponseData
    ) : base(clusterComputeResponseData)
    {  }
    #pragma warning restore CS8618

    public ClusterComputeResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ClusterComputeResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ClusterComputeResponseDataFromRaw.FromRawUnchecked"/>
    public static ClusterComputeResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ClusterComputeResponseData (string taskID) : this()
    { this.TaskID = taskID; }
}class ClusterComputeResponseDataFromRaw : IFromRawJson<ClusterComputeResponseData>
{
    /// <inheritdoc/>
    public ClusterComputeResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ClusterComputeResponseData.FromRawUnchecked(rawData);
}