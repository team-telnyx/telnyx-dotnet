using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Embeddings;

/// <summary>
/// Perform embedding on a Telnyx Storage Bucket using the a embedding model. The
/// current supported file types are: - PDF - HTML - txt/unstructured text files
/// - json - csv - audio / video (mp3, mp4, mpeg, mpga, m4a, wav, or webm ) - Max
/// of 100mb file size.
///
/// <para>Any files not matching the above types will be attempted to be embedded
/// as unstructured text.</para>
///
/// <para>This process can be slow, so it runs in the background and the user can
/// check the status of the task using the endpoint `/ai/embeddings/{task_id}`.</para>
///
/// <para> **Important Note**: When you update documents in a Telnyx Storage bucket,
/// their associated embeddings are automatically kept up to date. If you add or
/// update a file, it is automatically embedded. If you delete a file, the embeddings
/// are deleted for that particular file.</para>
///
/// <para>You can also specify a custom `loader` param. Currently the only supported
/// loader value is `intercom` which loads Intercom article jsons as specified by
/// [the Intercom article API](https://developers.intercom.com/docs/references/rest-api/api.intercom.io/Articles/article/)
/// This loader will split each article into paragraphs and save additional parameters
/// relevant to Intercom docs, such as `article_url` and `heading`. These values will
/// be returned by the `/v2/ai/embeddings/similarity-search` endpoint in the `loader_metadata` field.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EmbeddingCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string BucketName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "bucket_name"
            );
        }
        init { this._rawBodyData.Set("bucket_name", value); }
    }

    public long? DocumentChunkOverlapSize {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "document_chunk_overlap_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("document_chunk_overlap_size", value);
        }
    }

    public long? DocumentChunkSize {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "document_chunk_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("document_chunk_size", value);
        }
    }

    /// <summary>
    /// Supported models to vectorize and embed documents.
    /// </summary>
    public ApiEnum<string, EmbeddingModel>? EmbeddingModel {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, EmbeddingModel>>(
                "embedding_model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("embedding_model", value);
        }
    }

    /// <summary>
    /// Supported types of custom document loaders for embeddings.
    /// </summary>
    public ApiEnum<string, Loader>? Loader {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Loader>>(
                "loader"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("loader", value);
        }
    }

    public string? IdempotencyKey {
        get {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>(
                "Idempotency-Key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public EmbeddingCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddingCreateParams (
        EmbeddingCreateParams embeddingCreateParams
    ) : base(embeddingCreateParams)
    { this._rawBodyData = new(embeddingCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public EmbeddingCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddingCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EmbeddingCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(EmbeddingCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/ai/embeddings"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// Supported models to vectorize and embed documents.
/// </summary>
[JsonConverter(typeof(EmbeddingModelConverter))]
public enum EmbeddingModel
{
    ThenlperGteLarge, IntfloatMultilingualE5Large
}

sealed class EmbeddingModelConverter : JsonConverter<EmbeddingModel>
{
    public override EmbeddingModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "thenlper/gte-large"=>EmbeddingModel.ThenlperGteLarge,
            "intfloat/multilingual-e5-large"=>EmbeddingModel.IntfloatMultilingualE5Large,
            _ =>(EmbeddingModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmbeddingModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmbeddingModel.ThenlperGteLarge=>"thenlper/gte-large",
            EmbeddingModel.IntfloatMultilingualE5Large=>"intfloat/multilingual-e5-large",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Supported types of custom document loaders for embeddings.
/// </summary>
[JsonConverter(typeof(LoaderConverter))]
public enum Loader
{
    Default, Intercom
}

sealed class LoaderConverter : JsonConverter<Loader>
{
    public override Loader Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "default"=>Loader.Default,
            "intercom"=>Loader.Intercom,
            _ =>(Loader)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Loader value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Loader.Default=>"default",
            Loader.Intercom=>"intercom",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}