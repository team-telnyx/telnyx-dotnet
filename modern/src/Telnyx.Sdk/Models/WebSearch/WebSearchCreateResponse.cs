using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WebSearch;

[JsonConverter(typeof(JsonModelConverter<WebSearchCreateResponse, WebSearchCreateResponseFromRaw>))]
public sealed record class WebSearchCreateResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
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

    public WebSearchCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebSearchCreateResponse (
        WebSearchCreateResponse webSearchCreateResponse
    ) : base(webSearchCreateResponse)
    {  }
    #pragma warning restore CS8618

    public WebSearchCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebSearchCreateResponseFromRaw.FromRawUnchecked"/>
    public static WebSearchCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebSearchCreateResponseFromRaw : IFromRawJson<WebSearchCreateResponse>
{
    /// <inheritdoc/>
    public WebSearchCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebSearchCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public Results? Results {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Results>(
                "results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("results", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Results?.Validate(); }

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
}[JsonConverter(typeof(JsonModelConverter<Results, ResultsFromRaw>))]
public sealed record class Results : JsonModel
{
    /// <summary>
    /// Web search results.
    /// </summary>
    public required IReadOnlyList<WebSearchResult> Web {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WebSearchResult>>(
                "web"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<WebSearchResult>>(
                "web",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// News search results. Present only when the query surfaces news results.
    /// </summary>
    public IReadOnlyList<WebSearchResult>? News {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WebSearchResult>>(
                "news"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WebSearchResult>?>(
                "news",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Web)
        {
            item.Validate();
        }
        foreach (var item in this.News ?? [])
        {
            item.Validate();
        }
    }

    public Results ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Results (Results results) : base(results)
    {  }
    #pragma warning restore CS8618

    public Results (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Results (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResultsFromRaw.FromRawUnchecked"/>
    public static Results FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Results (IReadOnlyList<WebSearchResult> web) : this()
    { this.Web = web; }
}class ResultsFromRaw : IFromRawJson<Results>
{
    /// <inheritdoc/>
    public Results FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Results.FromRawUnchecked(rawData);
}