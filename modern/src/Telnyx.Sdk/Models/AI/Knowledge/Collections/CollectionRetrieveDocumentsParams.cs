using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Knowledge.Collections;

/// <summary>
/// Runs search over the documents in a collection, ranked by relevance to `query`.
/// Searches currently run `vector` retrieval (semantic similarity). The collection's
/// `retrieval_type` setting is the forward-compatible selector: `hybrid` (vector
/// similarity fused with keyword matching) can be set but cannot be searched yet,
/// and `keyword` (lexical BM25 matching) is not accepted yet -- setting it returns
/// 422 `unsupported_retrieval_type`. A per-request `retrieval_type` is accepted but
/// ignored; `meta.retrieval_type` echoes the mode that actually ran. When `query`
/// is omitted, returns a plain catalog listing of the collection's documents.
///
/// <para>**How it works:** 1. The `query` text is embedded into a 1024-dimensional
/// vector using the multilingual-e5-large model. 2. The embedding is compared against
/// the collection's indexed document chunks using semantic similarity. When `hybrid`
/// and `keyword` execution ship, those scores will be fused with, or replaced by,
/// lexical BM25 matching. 3. Results are ranked by `score` (descending) and paginated
/// via `page[number]` / `page[size]`.</para>
///
/// <para>**Authentication:** Requires a Telnyx API key via `Authorization: Bearer
/// &lt;key&gt;`. Results are automatically scoped to your organization and cannot
/// be overridden.</para>
///
/// <para>**Filtering:** Use `filter[field][operator]=value` query parameters to
/// narrow results before search. Supported operators: `eq` (default), `in`, `gte`,
/// `gt`, `lte`, `lt`, `contains`. Metadata fields resolve to `metadata.&lt;field&gt;`.</para>
///
/// <para>**Examples:** - `GET /v2/ai/knowledge/collections/my-collection/documents?query=billing+issue&amp;top_k=10`
/// - `GET /v2/ai/knowledge/collections/my-collection/documents?query=refund&amp;sources=voice,message`
/// - `GET /v2/ai/knowledge/collections/my-collection/documents?query=outage&amp;filter[record_created_at][gte]=2026-01-01T00:00:00Z`</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CollectionRetrieveDocumentsParams : ParamsBase
{
    public string? Slug { get; init; }

    /// <summary>
    /// Field filters applied before ranking, using `filter[field][operator]=value`.
    /// Supported operators: `eq` (default), `in`, `gte`, `gt`, `lte`, `lt`, `contains`.
    /// Known fields: `record_type`, `record_id`, `user_id`, `record_created_at`,
    /// `ingested_at`; any other name resolves to a `metadata.&lt;field&gt;` filter.
    /// Example: `filter[record_id][eq]=rec_123`.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set<FrozenDictionary<string, JsonElement>?>(
                "filter",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Page number to return (1-based). Defaults to 1.
    /// </summary>
    public long? PageNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[number]", value);
        }
    }

    /// <summary>
    /// Number of results per page. Defaults to 20.
    /// </summary>
    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[size]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[size]", value);
        }
    }

    /// <summary>
    /// Natural-language search query. When provided, the text is matched against
    /// the collection's document chunks using the collection's `retrieval_type`
    /// (vector or hybrid). When omitted, documents are returned as a plain catalog listing.
    /// </summary>
    public string? Query {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "query"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("query", value);
        }
    }

    /// <summary>
    /// Reserved; not yet functional. A value supplied here is accepted but ignored
    /// — it does not override the collection's configured strategy, and it is not
    /// echoed back. Searches run `vector` retrieval, and `meta.retrieval_type` reports
    /// the mode that actually ran. To change retrieval strategy, set it on the collection's
    /// settings subresource.
    /// </summary>
    public ApiEnum<string, RetrievalType>? RetrievalType {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, RetrievalType>>(
                "retrieval_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("retrieval_type", value);
        }
    }

    /// <summary>
    /// Comma-separated list of source types to restrict the search to. When omitted,
    /// all of the collection's sources are searched.
    /// </summary>
    public string? Sources {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "sources"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("sources", value);
        }
    }

    /// <summary>
    /// Maximum number of ranked results to consider. When omitted, the collection's
    /// configured `top_k` setting is used.
    /// </summary>
    public long? TopK {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "top_k"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("top_k", value);
        }
    }

    public CollectionRetrieveDocumentsParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CollectionRetrieveDocumentsParams (
        CollectionRetrieveDocumentsParams collectionRetrieveDocumentsParams
    ) : base(collectionRetrieveDocumentsParams)
    { this.Slug = collectionRetrieveDocumentsParams.Slug; }
    #pragma warning restore CS8618

    public CollectionRetrieveDocumentsParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CollectionRetrieveDocumentsParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string slug
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.Slug = slug;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CollectionRetrieveDocumentsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string slug
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            slug
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["Slug"] = JsonSerializer.SerializeToElement(this.Slug),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(CollectionRetrieveDocumentsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.Slug?.Equals(other.Slug) ?? other.Slug == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/knowledge/collections/{0}/documents",
            this.Slug)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
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
/// Reserved; not yet functional. A value supplied here is accepted but ignored —
/// it does not override the collection's configured strategy, and it is not echoed
/// back. Searches run `vector` retrieval, and `meta.retrieval_type` reports the mode
/// that actually ran. To change retrieval strategy, set it on the collection's settings subresource.
/// </summary>
[JsonConverter(typeof(RetrievalTypeConverter))]
public enum RetrievalType
{
    Vector, Hybrid, Keyword
}

sealed class RetrievalTypeConverter : JsonConverter<RetrievalType>
{
    public override RetrievalType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vector"=>RetrievalType.Vector,
            "hybrid"=>RetrievalType.Hybrid,
            "keyword"=>RetrievalType.Keyword,
            _ =>(RetrievalType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RetrievalType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RetrievalType.Vector=>"vector",
            RetrievalType.Hybrid=>"hybrid",
            RetrievalType.Keyword=>"keyword",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}