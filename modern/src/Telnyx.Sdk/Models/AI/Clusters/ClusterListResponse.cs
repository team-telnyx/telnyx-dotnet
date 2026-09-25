using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberAssignmentByProfile;

namespace Telnyx.Sdk.Models.AI.Clusters;

[JsonConverter(typeof(JsonModelConverter<ClusterListResponse, ClusterListResponseFromRaw>))]
public sealed record class ClusterListResponse : JsonModel
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

    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required DateTimeOffset FinishedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "finished_at"
            );
        }
        init { this._rawData.Set("finished_at", value); }
    }

    public required long MinClusterSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "min_cluster_size"
            );
        }
        init { this._rawData.Set("min_cluster_size", value); }
    }

    public required long MinSubclusterSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "min_subcluster_size"
            );
        }
        init { this._rawData.Set("min_subcluster_size", value); }
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
    {
        _ = this.Bucket;
        _ = this.CreatedAt;
        _ = this.FinishedAt;
        _ = this.MinClusterSize;
        _ = this.MinSubclusterSize;
        this.Status.Validate();
        _ = this.TaskID;
    }

    public ClusterListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClusterListResponse (ClusterListResponse clusterListResponse) : base(
        clusterListResponse
    )
    {  }
    #pragma warning restore CS8618

    public ClusterListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ClusterListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ClusterListResponseFromRaw.FromRawUnchecked"/>
    public static ClusterListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ClusterListResponseFromRaw : IFromRawJson<ClusterListResponse>
{
    /// <inheritdoc/>
    public ClusterListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ClusterListResponse.FromRawUnchecked(rawData);
}