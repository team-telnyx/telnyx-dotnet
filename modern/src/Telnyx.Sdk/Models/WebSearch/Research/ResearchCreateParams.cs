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

namespace Telnyx.Sdk.Models.WebSearch.Research;

/// <summary>
/// Starts a deep research task that runs multiple searches, reads sources, and synthesizes
/// an answer with citations.
///
/// <para>## Synchronous mode (default)</para>
///
/// <para>When `background` is `false` or omitted, the request blocks until the research
/// completes and returns the answer with citations. This can take up to 120 seconds
/// depending on `research_effort`.</para>
///
/// <para>## Asynchronous mode</para>
///
/// <para>When `background` is `true`, the request returns immediately with a `task_id`
/// and `status: pending`. Poll `GET /web_search/research/{task_id}` to check when
/// the research completes and retrieve the answer.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ResearchCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The research question or topic.
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
    /// When `true`, the research runs asynchronously. The response returns a `task_id`
    /// immediately instead of waiting for the result. Poll `GET /web_search/research/{task_id}`
    /// to check status.
    /// </summary>
    public bool? Background {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "background"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("background", value);
        }
    }

    /// <summary>
    /// Maximum number of sources to use.
    /// </summary>
    public long? MaxSources {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "max_sources"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("max_sources", value);
        }
    }

    /// <summary>
    /// Research depth level. `lite` is fastest, `deep` is most thorough.
    /// </summary>
    public ApiEnum<string, ResearchEffort>? ResearchEffort {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ResearchEffort>>(
                "research_effort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("research_effort", value);
        }
    }

    public ResearchCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResearchCreateParams (
        ResearchCreateParams researchCreateParams
    ) : base(researchCreateParams)
    { this._rawBodyData = new(researchCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public ResearchCreateParams (
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
    ResearchCreateParams (
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
    public static ResearchCreateParams FromRawUnchecked(
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

    public virtual bool Equals(ResearchCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/web_search/research"
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
/// Research depth level. `lite` is fastest, `deep` is most thorough.
/// </summary>
[JsonConverter(typeof(ResearchEffortConverter))]
public enum ResearchEffort
{
    Lite, Standard, Deep
}

sealed class ResearchEffortConverter : JsonConverter<ResearchEffort>
{
    public override ResearchEffort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "lite"=>ResearchEffort.Lite,
            "standard"=>ResearchEffort.Standard,
            "deep"=>ResearchEffort.Deep,
            _ =>(ResearchEffort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResearchEffort value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ResearchEffort.Lite=>"lite",
            ResearchEffort.Standard=>"standard",
            ResearchEffort.Deep=>"deep",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}