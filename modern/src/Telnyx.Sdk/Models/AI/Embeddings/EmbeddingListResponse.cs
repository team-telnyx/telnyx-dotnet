using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Embeddings;

[JsonConverter(typeof(JsonModelConverter<EmbeddingListResponse, EmbeddingListResponseFromRaw>))]
public sealed record class EmbeddingListResponse : JsonModel
{
    public required IReadOnlyList<EmbeddingListResponseData> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmbeddingListResponseData>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmbeddingListResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public EmbeddingListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddingListResponse (
        EmbeddingListResponse embeddingListResponse
    ) : base(embeddingListResponse)
    {  }
    #pragma warning restore CS8618

    public EmbeddingListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddingListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddingListResponseFromRaw.FromRawUnchecked"/>
    public static EmbeddingListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmbeddingListResponse (
        IReadOnlyList<EmbeddingListResponseData> data
    ) : this()
    { this.Data = data; }
}

class EmbeddingListResponseFromRaw : IFromRawJson<EmbeddingListResponse>
{
    /// <inheritdoc/>
    public EmbeddingListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmbeddingListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<EmbeddingListResponseData, EmbeddingListResponseDataFromRaw>))]
public sealed record class EmbeddingListResponseData : JsonModel
{
    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Status of an embeddings task.
    /// </summary>
    public required ApiEnum<string, BackgroundTaskStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BackgroundTaskStatus>>(
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

    public required string TaskName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "task_name"
            );
        }
        init { this._rawData.Set("task_name", value); }
    }

    public required string UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "user_id"
            );
        }
        init { this._rawData.Set("user_id", value); }
    }

    public string? Bucket {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "bucket"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bucket", value);
        }
    }

    public DateTimeOffset? FinishedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "finished_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("finished_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        this.Status.Validate();
        _ = this.TaskID;
        _ = this.TaskName;
        _ = this.UserID;
        _ = this.Bucket;
        _ = this.FinishedAt;
    }

    public EmbeddingListResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddingListResponseData (
        EmbeddingListResponseData embeddingListResponseData
    ) : base(embeddingListResponseData)
    {  }
    #pragma warning restore CS8618

    public EmbeddingListResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddingListResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddingListResponseDataFromRaw.FromRawUnchecked"/>
    public static EmbeddingListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EmbeddingListResponseDataFromRaw : IFromRawJson<EmbeddingListResponseData>
{
    /// <inheritdoc/>
    public EmbeddingListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmbeddingListResponseData.FromRawUnchecked(rawData);
}