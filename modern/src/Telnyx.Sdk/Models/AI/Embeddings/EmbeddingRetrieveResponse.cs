using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Embeddings;

[JsonConverter(typeof(JsonModelConverter<EmbeddingRetrieveResponse, EmbeddingRetrieveResponseFromRaw>))]
public sealed record class EmbeddingRetrieveResponse : JsonModel
{
    public required EmbeddingRetrieveResponseData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmbeddingRetrieveResponseData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmbeddingRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddingRetrieveResponse (
        EmbeddingRetrieveResponse embeddingRetrieveResponse
    ) : base(embeddingRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public EmbeddingRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddingRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddingRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static EmbeddingRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmbeddingRetrieveResponse (
        EmbeddingRetrieveResponseData data
    ) : this()
    { this.Data = data; }
}

class EmbeddingRetrieveResponseFromRaw : IFromRawJson<EmbeddingRetrieveResponse>
{
    /// <inheritdoc/>
    public EmbeddingRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmbeddingRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<EmbeddingRetrieveResponseData, EmbeddingRetrieveResponseDataFromRaw>))]
public sealed record class EmbeddingRetrieveResponseData : JsonModel
{
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public string? FinishedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <summary>
    /// Status of an embeddings task.
    /// </summary>
    public ApiEnum<string, BackgroundTaskStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BackgroundTaskStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public string? TaskID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "task_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("task_id", value);
        }
    }

    public string? TaskName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "task_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("task_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.FinishedAt;
        this.Status?.Validate();
        _ = this.TaskID;
        _ = this.TaskName;
    }

    public EmbeddingRetrieveResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddingRetrieveResponseData (
        EmbeddingRetrieveResponseData embeddingRetrieveResponseData
    ) : base(embeddingRetrieveResponseData)
    {  }
    #pragma warning restore CS8618

    public EmbeddingRetrieveResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddingRetrieveResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddingRetrieveResponseDataFromRaw.FromRawUnchecked"/>
    public static EmbeddingRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EmbeddingRetrieveResponseDataFromRaw : IFromRawJson<EmbeddingRetrieveResponseData>
{
    /// <inheritdoc/>
    public EmbeddingRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmbeddingRetrieveResponseData.FromRawUnchecked(rawData);
}