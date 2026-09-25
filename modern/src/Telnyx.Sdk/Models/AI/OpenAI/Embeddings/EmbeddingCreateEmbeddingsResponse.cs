using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.OpenAI.Embeddings;

[JsonConverter(typeof(JsonModelConverter<EmbeddingCreateEmbeddingsResponse, EmbeddingCreateEmbeddingsResponseFromRaw>))]
public sealed record class EmbeddingCreateEmbeddingsResponse : JsonModel
{
    /// <summary>
    /// List of embedding objects
    /// </summary>
    public required IReadOnlyList<Data> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Data>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The model used for embedding
    /// </summary>
    public required string Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "model"
            );
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// The object type, always 'list'
    /// </summary>
    public required string Object {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "object"
            );
        }
        init { this._rawData.Set("object", value); }
    }

    public required Usage Usage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Usage>(
                "usage"
            );
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.Model;
        _ = this.Object;
        this.Usage.Validate();
    }

    public EmbeddingCreateEmbeddingsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddingCreateEmbeddingsResponse (
        EmbeddingCreateEmbeddingsResponse embeddingCreateEmbeddingsResponse
    ) : base(embeddingCreateEmbeddingsResponse)
    {  }
    #pragma warning restore CS8618

    public EmbeddingCreateEmbeddingsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddingCreateEmbeddingsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddingCreateEmbeddingsResponseFromRaw.FromRawUnchecked"/>
    public static EmbeddingCreateEmbeddingsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmbeddingCreateEmbeddingsResponseFromRaw : IFromRawJson<EmbeddingCreateEmbeddingsResponse>
{
    /// <inheritdoc/>
    public EmbeddingCreateEmbeddingsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmbeddingCreateEmbeddingsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The embedding vector
    /// </summary>
    public required IReadOnlyList<double> Embedding {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<double>>(
                "embedding"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<double>>(
                "embedding",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The index of the embedding in the list of embeddings
    /// </summary>
    public required long Index {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "index"
            );
        }
        init { this._rawData.Set("index", value); }
    }

    /// <summary>
    /// The object type, always 'embedding'
    /// </summary>
    public required string Object {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "object"
            );
        }
        init { this._rawData.Set("object", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Embedding;
        _ = this.Index;
        _ = this.Object;
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
}[JsonConverter(typeof(JsonModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : JsonModel
{
    /// <summary>
    /// Number of tokens in the input
    /// </summary>
    public required long PromptTokens {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "prompt_tokens"
            );
        }
        init { this._rawData.Set("prompt_tokens", value); }
    }

    /// <summary>
    /// Total number of tokens used
    /// </summary>
    public required long TotalTokens {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_tokens"
            );
        }
        init { this._rawData.Set("total_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PromptTokens;
        _ = this.TotalTokens;
    }

    public Usage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Usage (Usage usage) : base(usage)
    {  }
    #pragma warning restore CS8618

    public Usage (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UsageFromRaw.FromRawUnchecked"/>
    public static Usage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class UsageFromRaw : IFromRawJson<Usage>
{
    /// <inheritdoc/>
    public Usage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Usage.FromRawUnchecked(rawData);
}