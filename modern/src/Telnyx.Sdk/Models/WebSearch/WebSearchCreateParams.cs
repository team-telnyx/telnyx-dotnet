using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.WebSearch;

/// <summary>
/// Performs a real-time web search and returns structured, LLM-ready JSON results
/// with titles, URLs, descriptions, and snippets. Supports filtering by domain, country,
/// safe search, freshness, and live crawl.
///
/// <para>**Note:** `include_domains` and `exclude_domains` cannot be used in the
/// same request. Use one or the other.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WebSearchCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The search query text.
    /// </summary>
    public required string Query {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "query"
            );
        }
        init { this._rawBodyData.Set("query", value); }
    }

    /// <summary>
    /// Number of results to return (1-100).
    /// </summary>
    public long? Count {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("count", value);
        }
    }

    /// <summary>
    /// Two-letter country code (ISO 3166-1 alpha-2) to bias results.
    /// </summary>
    public string? Country {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "country"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("country", value);
        }
    }

    /// <summary>
    /// Exclude results from these domains (bare hostnames, e.g. `pinterest.com`).
    /// </summary>
    public IReadOnlyList<string>? ExcludeDomains {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "exclude_domains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "exclude_domains",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Time-based filter for results. Common values: `day`, `week`, `month`, `year`.
    /// </summary>
    public string? Freshness {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "freshness"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("freshness", value);
        }
    }

    /// <summary>
    /// Restrict results to these domains (bare hostnames, e.g. `arxiv.org`).
    /// </summary>
    public IReadOnlyList<string>? IncludeDomains {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "include_domains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "include_domains",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When true, the provider crawls pages in real-time for fresh content. The
    /// boolean is translated to the provider's internal enum internally; callers
    /// always pass `true` or `false`.
    /// </summary>
    public bool? Livecrawl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "livecrawl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("livecrawl", value);
        }
    }

    /// <summary>
    /// Safe search filter level.
    /// </summary>
    public ApiEnum<string, Safesearch>? Safesearch {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Safesearch>>(
                "safesearch"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("safesearch", value);
        }
    }

    public WebSearchCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebSearchCreateParams (
        WebSearchCreateParams webSearchCreateParams
    ) : base(webSearchCreateParams)
    { this._rawBodyData = new(webSearchCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public WebSearchCreateParams (
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
    WebSearchCreateParams (
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
    public static WebSearchCreateParams FromRawUnchecked(
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

    public virtual bool Equals(WebSearchCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/web_search"
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
/// Safe search filter level.
/// </summary>
[JsonConverter(typeof(SafesearchConverter))]
public enum Safesearch
{
    Off, Moderate, Strict
}

sealed class SafesearchConverter : JsonConverter<Safesearch>
{
    public override Safesearch Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "off"=>Safesearch.Off,
            "moderate"=>Safesearch.Moderate,
            "strict"=>Safesearch.Strict,
            _ =>(Safesearch)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Safesearch value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Safesearch.Off=>"off",
            Safesearch.Moderate=>"moderate",
            Safesearch.Strict=>"strict",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}