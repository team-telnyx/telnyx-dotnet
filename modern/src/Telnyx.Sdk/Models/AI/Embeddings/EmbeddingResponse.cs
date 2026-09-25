using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Embeddings;

[JsonConverter(typeof(JsonModelConverter<EmbeddingResponse, EmbeddingResponseFromRaw>))]
public sealed record class EmbeddingResponse : JsonModel
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

    public EmbeddingResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddingResponse (EmbeddingResponse embeddingResponse) : base(
        embeddingResponse
    )
    {  }
    #pragma warning restore CS8618

    public EmbeddingResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddingResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddingResponseFromRaw.FromRawUnchecked"/>
    public static EmbeddingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmbeddingResponse (Data data) : this()
    { this.Data = data; }
}

class EmbeddingResponseFromRaw : IFromRawJson<EmbeddingResponse>
{
    /// <inheritdoc/>
    public EmbeddingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmbeddingResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
        init { this._rawData.Set("finished_at", value); }
    }

    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.FinishedAt;
        _ = this.Status;
        _ = this.TaskID;
        _ = this.TaskName;
        _ = this.UserID;
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