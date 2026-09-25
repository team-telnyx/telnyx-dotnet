using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI;

/// <summary>
/// Performs semantic vector search across conversation history records.
///
/// <para>**How it works:** 1. The query text is embedded into a 1024-dimensional
/// vector using the multilingual-e5-large model. 2. The vector is compared against
/// indexed record chunks using semantic similarity search. 3. When no region is specified,
/// all regions are queried in parallel (fan-out) and results are merged by score.
/// 4. Results are ranked by similarity score (descending) and paginated via `page[number]`
/// / `page[size]`.</para>
///
/// <para>**Authentication:** Requires a Telnyx API key via `Authorization: Bearer
/// &lt;key&gt;`. Results are automatically scoped to the caller's organization —
/// `organization_id` is injected from the auth token and cannot be overridden.</para>
///
/// <para>**Chunking:** Records are split into chunks of up to 480 tokens with 64-token
/// overlap at ingestion time. Each search result represents a single chunk, with
/// `chunk_index` and `chunk_total` indicating its position within the original record.</para>
///
/// <para>**Filtering:** Use `filter[field][operator]=value` query parameters to
/// narrow results before vector search.</para>
///
/// <para>Top-level filterable fields: `user_id`, `region`, `record_id`, `record_created_at`,
/// `ingested_at`, `retention`</para>
///
/// <para>Note: `retention` is filter-only — it can be used to narrow results but
/// is not returned in the response body.</para>
///
/// <para>Metadata fields: any field not in the list above is resolved to `data.metadata.&lt;field&gt;`
/// (e.g., `filter[language]=en` → `data.metadata.language`).</para>
///
/// <para>Supported filter operators: - `eq` — exact match (default when no operator
/// specified) - `in` — match any of comma-separated values - `gte`, `gt`, `lte`,
/// `lt` — range comparisons (useful for date filtering) - `contains` — wildcard substring match</para>
///
/// <para>**Examples:** - `GET /v2/ai/conversation_histories?q=billing+issue&amp;page[size]=10`
/// - `GET /v2/ai/conversation_histories?q=setup+guide&amp;region=USA&amp;min_score=0.5`
/// - `GET /v2/ai/conversation_histories?q=refund&amp;filter[record_created_at][gte]=2026-01-01T00:00:00Z`
/// - `GET /v2/ai/conversation_histories?q=outage&amp;filter[region][in]=USA,DEU`
/// - `GET /v2/ai/conversation_histories?q=hold+time&amp;filter[language]=en`</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AIRetrieveConversationHistoriesParams : ParamsBase
{
    /// <summary>
    /// Natural language search query. The text is embedded into a 1024-dimensional
    /// vector and compared against indexed record chunks using semantic similarity.
    /// </summary>
    public required string Q {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>(
                "q"
            );
        }
        init { this._rawQueryData.Set("q", value); }
    }

    /// <summary>
    /// Only include records ingested (chunked, embedded, and indexed) on or after
    /// this ISO 8601 timestamp.
    /// </summary>
    public System::DateTimeOffset? FilterIngestedAtGte {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "filter[ingested_at][gte]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[ingested_at][gte]", value);
        }
    }

    /// <summary>
    /// Only include records ingested (chunked, embedded, and indexed) on or before
    /// this ISO 8601 timestamp.
    /// </summary>
    public System::DateTimeOffset? FilterIngestedAtLte {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "filter[ingested_at][lte]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[ingested_at][lte]", value);
        }
    }

    /// <summary>
    /// Only include records whose original creation time is on or after this ISO
    /// 8601 timestamp.
    /// </summary>
    public System::DateTimeOffset? FilterRecordCreatedAtGte {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "filter[record_created_at][gte]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[record_created_at][gte]", value);
        }
    }

    /// <summary>
    /// Only include records whose original creation time is on or before this ISO
    /// 8601 timestamp.
    /// </summary>
    public System::DateTimeOffset? FilterRecordCreatedAtLte {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "filter[record_created_at][lte]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[record_created_at][lte]", value);
        }
    }

    /// <summary>
    /// Filter to chunks belonging to a specific parent record (exact match).
    /// </summary>
    public string? FilterRecordID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[record_id]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[record_id]", value);
        }
    }

    /// <summary>
    /// Filter by the region stored on the record. Comma-separated to match multiple
    /// regions (USA, DEU, AUS, UAE). Distinct from the `region` parameter, which
    /// selects which cluster(s) are queried.
    /// </summary>
    public string? FilterRegionIn {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[region][in]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[region][in]", value);
        }
    }

    /// <summary>
    /// Filter by retention policy (exact match). Filter-only: not returned in the
    /// response body.
    /// </summary>
    public string? FilterRetention {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[retention]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[retention]", value);
        }
    }

    /// <summary>
    /// Filter to records owned by a specific user (exact match).
    /// </summary>
    public string? FilterUserID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[user_id]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[user_id]", value);
        }
    }

    /// <summary>
    /// Minimum cosine similarity score threshold (0.0 to 1.0). Results below this
    /// threshold are excluded.
    /// </summary>
    public float? MinScore {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<float>(
                "min_score"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("min_score", value);
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
    /// Number of results per page. Defaults to 20, maximum 100.
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
    /// Restrict search to a specific region. When omitted, all regions are queried
    /// in parallel (fan-out) and results are merged by similarity score.
    /// </summary>
    public ApiEnum<string, Region>? Region {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Region>>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("region", value);
        }
    }

    public AIRetrieveConversationHistoriesParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AIRetrieveConversationHistoriesParams (
        AIRetrieveConversationHistoriesParams aiRetrieveConversationHistoriesParams
    ) : base(aiRetrieveConversationHistoriesParams)
    {  }
    #pragma warning restore CS8618

    public AIRetrieveConversationHistoriesParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AIRetrieveConversationHistoriesParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AIRetrieveConversationHistoriesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AIRetrieveConversationHistoriesParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/ai/conversation_histories"
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
/// Restrict search to a specific region. When omitted, all regions are queried in
/// parallel (fan-out) and results are merged by similarity score.
/// </summary>
[JsonConverter(typeof(RegionConverter))]
public enum Region
{
    Usa, Deu, Aus, Uae
}

sealed class RegionConverter : JsonConverter<Region>
{
    public override Region Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USA"=>Region.Usa,
            "DEU"=>Region.Deu,
            "AUS"=>Region.Aus,
            "UAE"=>Region.Uae,
            _ =>(Region)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Region value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Region.Usa=>"USA",
            Region.Deu=>"DEU",
            Region.Aus=>"AUS",
            Region.Uae=>"UAE",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}