using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.OpenAI.Embeddings;

[JsonConverter(typeof(JsonModelConverter<EmbeddingListEmbeddingModelsResponse, EmbeddingListEmbeddingModelsResponseFromRaw>))]
public sealed record class EmbeddingListEmbeddingModelsResponse : JsonModel
{
    /// <summary>
    /// List of available embedding models
    /// </summary>
    public required IReadOnlyList<EmbeddingListEmbeddingModelsResponseData> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmbeddingListEmbeddingModelsResponseData>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmbeddingListEmbeddingModelsResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.Object;
    }

    public EmbeddingListEmbeddingModelsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddingListEmbeddingModelsResponse (
        EmbeddingListEmbeddingModelsResponse embeddingListEmbeddingModelsResponse
    ) : base(embeddingListEmbeddingModelsResponse)
    {  }
    #pragma warning restore CS8618

    public EmbeddingListEmbeddingModelsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddingListEmbeddingModelsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddingListEmbeddingModelsResponseFromRaw.FromRawUnchecked"/>
    public static EmbeddingListEmbeddingModelsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmbeddingListEmbeddingModelsResponseFromRaw : IFromRawJson<EmbeddingListEmbeddingModelsResponse>
{
    /// <inheritdoc/>
    public EmbeddingListEmbeddingModelsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmbeddingListEmbeddingModelsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<EmbeddingListEmbeddingModelsResponseData, EmbeddingListEmbeddingModelsResponseDataFromRaw>))]
public sealed record class EmbeddingListEmbeddingModelsResponseData : JsonModel
{
    /// <summary>
    /// The model identifier
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Unix timestamp of when the model was created
    /// </summary>
    public required long Created {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "created"
            );
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// The object type, always 'model'
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

    /// <summary>
    /// The organization that owns the model
    /// </summary>
    public required string OwnedBy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "owned_by"
            );
        }
        init { this._rawData.Set("owned_by", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Created;
        _ = this.Object;
        _ = this.OwnedBy;
    }

    public EmbeddingListEmbeddingModelsResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddingListEmbeddingModelsResponseData (
        EmbeddingListEmbeddingModelsResponseData embeddingListEmbeddingModelsResponseData
    ) : base(embeddingListEmbeddingModelsResponseData)
    {  }
    #pragma warning restore CS8618

    public EmbeddingListEmbeddingModelsResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddingListEmbeddingModelsResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddingListEmbeddingModelsResponseDataFromRaw.FromRawUnchecked"/>
    public static EmbeddingListEmbeddingModelsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EmbeddingListEmbeddingModelsResponseDataFromRaw : IFromRawJson<EmbeddingListEmbeddingModelsResponseData>
{
    /// <inheritdoc/>
    public EmbeddingListEmbeddingModelsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmbeddingListEmbeddingModelsResponseData.FromRawUnchecked(rawData);
}