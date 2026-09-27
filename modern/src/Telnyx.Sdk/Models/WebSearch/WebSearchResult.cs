using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WebSearch;

[JsonConverter(typeof(JsonModelConverter<WebSearchResult, WebSearchResultFromRaw>))]
public sealed record class WebSearchResult : JsonModel
{
    /// <summary>
    /// Short description or excerpt.
    /// </summary>
    public required string Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Relevant text snippets from the page.
    /// </summary>
    public required IReadOnlyList<string> Snippets {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "snippets"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "snippets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Result title.
    /// </summary>
    public required string Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "title"
            );
        }
        init { this._rawData.Set("title", value); }
    }

    /// <summary>
    /// Result URL.
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
    /// Thumbnail image URL (if available).
    /// </summary>
    public string? ThumbnailUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "thumbnail_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("thumbnail_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Snippets;
        _ = this.Title;
        _ = this.Url;
        _ = this.FaviconUrl;
        _ = this.ThumbnailUrl;
    }

    public WebSearchResult ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebSearchResult (WebSearchResult webSearchResult) : base(
        webSearchResult
    )
    {  }
    #pragma warning restore CS8618

    public WebSearchResult (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchResult (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebSearchResultFromRaw.FromRawUnchecked"/>
    public static WebSearchResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebSearchResultFromRaw : IFromRawJson<WebSearchResult>
{
    /// <inheritdoc/>
    public WebSearchResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebSearchResult.FromRawUnchecked(rawData);
}