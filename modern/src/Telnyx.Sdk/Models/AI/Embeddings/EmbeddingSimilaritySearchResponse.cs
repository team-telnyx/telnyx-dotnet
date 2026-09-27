using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Embeddings;

[JsonConverter(typeof(JsonModelConverter<EmbeddingSimilaritySearchResponse, EmbeddingSimilaritySearchResponseFromRaw>))]
public sealed record class EmbeddingSimilaritySearchResponse : JsonModel
{
    public required IReadOnlyList<EmbeddingSimilaritySearchResponseData> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmbeddingSimilaritySearchResponseData>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmbeddingSimilaritySearchResponseData>>(
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

    public EmbeddingSimilaritySearchResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddingSimilaritySearchResponse (
        EmbeddingSimilaritySearchResponse embeddingSimilaritySearchResponse
    ) : base(embeddingSimilaritySearchResponse)
    {  }
    #pragma warning restore CS8618

    public EmbeddingSimilaritySearchResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddingSimilaritySearchResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddingSimilaritySearchResponseFromRaw.FromRawUnchecked"/>
    public static EmbeddingSimilaritySearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmbeddingSimilaritySearchResponse (
        IReadOnlyList<EmbeddingSimilaritySearchResponseData> data
    ) : this()
    { this.Data = data; }
}

class EmbeddingSimilaritySearchResponseFromRaw : IFromRawJson<EmbeddingSimilaritySearchResponse>
{
    /// <inheritdoc/>
    public EmbeddingSimilaritySearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmbeddingSimilaritySearchResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Example document response from embedding service {   "document_chunk": "your status?
/// This is Vanessa Bloome...",   "distance": 0.18607724,   "metadata": {     "source":
/// "https://us-central-1.telnyxstorage.com/scripts/bee_movie_script.txt",     "checksum":
/// "343054dd19bab39bbf6761a3d20f1daa",     "embedding": "openai/text-embedding-ada-002",
///     "filename": "bee_movie_script.txt",     "certainty": 0.9069613814353943,
///     "loader_metadata": {}   } }
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmbeddingSimilaritySearchResponseData, EmbeddingSimilaritySearchResponseDataFromRaw>))]
public sealed record class EmbeddingSimilaritySearchResponseData : JsonModel
{
    public required double Distance {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "distance"
            );
        }
        init { this._rawData.Set("distance", value); }
    }

    public required string DocumentChunk {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "document_chunk"
            );
        }
        init { this._rawData.Set("document_chunk", value); }
    }

    public required Metadata Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Metadata>(
                "metadata"
            );
        }
        init { this._rawData.Set("metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Distance;
        _ = this.DocumentChunk;
        this.Metadata.Validate();
    }

    public EmbeddingSimilaritySearchResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddingSimilaritySearchResponseData (
        EmbeddingSimilaritySearchResponseData embeddingSimilaritySearchResponseData
    ) : base(embeddingSimilaritySearchResponseData)
    {  }
    #pragma warning restore CS8618

    public EmbeddingSimilaritySearchResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddingSimilaritySearchResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddingSimilaritySearchResponseDataFromRaw.FromRawUnchecked"/>
    public static EmbeddingSimilaritySearchResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EmbeddingSimilaritySearchResponseDataFromRaw : IFromRawJson<EmbeddingSimilaritySearchResponseData>
{
    /// <inheritdoc/>
    public EmbeddingSimilaritySearchResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmbeddingSimilaritySearchResponseData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : JsonModel
{
    public required string Checksum {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "checksum"
            );
        }
        init { this._rawData.Set("checksum", value); }
    }

    public required string Embedding {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "embedding"
            );
        }
        init { this._rawData.Set("embedding", value); }
    }

    public required string Filename {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "filename"
            );
        }
        init { this._rawData.Set("filename", value); }
    }

    public required string Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "source"
            );
        }
        init { this._rawData.Set("source", value); }
    }

    public double? Certainty {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "certainty"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("certainty", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? LoaderMetadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "loader_metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "loader_metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Checksum;
        _ = this.Embedding;
        _ = this.Filename;
        _ = this.Source;
        _ = this.Certainty;
        _ = this.LoaderMetadata;
    }

    public Metadata ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Metadata (Metadata metadata) : base(metadata)
    {  }
    #pragma warning restore CS8618

    public Metadata (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetadataFromRaw.FromRawUnchecked"/>
    public static Metadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MetadataFromRaw : IFromRawJson<Metadata>
{
    /// <inheritdoc/>
    public Metadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Metadata.FromRawUnchecked(rawData);
}