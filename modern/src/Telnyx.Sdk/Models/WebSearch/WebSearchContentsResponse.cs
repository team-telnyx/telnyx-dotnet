using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WebSearch;

[JsonConverter(typeof(JsonModelConverter<WebSearchContentsResponse, WebSearchContentsResponseFromRaw>))]
public sealed record class WebSearchContentsResponse : JsonModel
{
    public WebSearchContentsResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebSearchContentsResponseData>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public WebSearchContentsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebSearchContentsResponse (
        WebSearchContentsResponse webSearchContentsResponse
    ) : base(webSearchContentsResponse)
    {  }
    #pragma warning restore CS8618

    public WebSearchContentsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchContentsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebSearchContentsResponseFromRaw.FromRawUnchecked"/>
    public static WebSearchContentsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebSearchContentsResponseFromRaw : IFromRawJson<WebSearchContentsResponse>
{
    /// <inheritdoc/>
    public WebSearchContentsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebSearchContentsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<WebSearchContentsResponseData, WebSearchContentsResponseDataFromRaw>))]
public sealed record class WebSearchContentsResponseData : JsonModel
{
    public IReadOnlyList<Result>? Results {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Result>>(
                "results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Result>?>(
                "results",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Results ?? [])
        {
            item.Validate();
        }
    }

    public WebSearchContentsResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebSearchContentsResponseData (
        WebSearchContentsResponseData webSearchContentsResponseData
    ) : base(webSearchContentsResponseData)
    {  }
    #pragma warning restore CS8618

    public WebSearchContentsResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchContentsResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebSearchContentsResponseDataFromRaw.FromRawUnchecked"/>
    public static WebSearchContentsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WebSearchContentsResponseDataFromRaw : IFromRawJson<WebSearchContentsResponseData>
{
    /// <inheritdoc/>
    public WebSearchContentsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebSearchContentsResponseData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// The source URL.
    /// </summary>
    public required string Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "url"
            );
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Cleaned HTML content (if `html` format requested; may also be present on
    /// freshly crawled pages).
    /// </summary>
    public string? Html {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "html"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("html", value);
        }
    }

    /// <summary>
    /// Markdown content (if `markdown` format requested).
    /// </summary>
    public string? Markdown {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "markdown"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("markdown", value);
        }
    }

    /// <summary>
    /// Page metadata (if `metadata` format requested).
    /// </summary>
    public Metadata? Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Metadata>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Page title (if available).
    /// </summary>
    public string? Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "title"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        _ = this.Html;
        _ = this.Markdown;
        this.Metadata?.Validate();
        _ = this.Title;
    }

    public Result ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result (Result result) : base(result)
    {  }
    #pragma warning restore CS8618

    public Result (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Result (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Result (string url) : this()
    { this.Url = url; }
}class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Result.FromRawUnchecked(rawData);
}/// <summary>
/// Page metadata (if `metadata` format requested).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : JsonModel
{
    /// <summary>
    /// Favicon URL (if available).
    /// </summary>
    public string? FaviconUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "favicon_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("favicon_url", value);
        }
    }

    /// <summary>
    /// Site name. Often empty.
    /// </summary>
    public string? SiteName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "site_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("site_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FaviconUrl;
        _ = this.SiteName;
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