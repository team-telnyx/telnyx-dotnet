using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI;

/// <summary>
/// Search response following the standard Telnyx V2 API format.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AIRetrieveConversationHistoriesPageResponse, AIRetrieveConversationHistoriesPageResponseFromRaw>))]
public sealed record class AIRetrieveConversationHistoriesPageResponse : JsonModel
{
    /// <summary>
    /// Ranked list of matching text chunks, sorted by cosine similarity score descending.
    /// </summary>
    public required IReadOnlyList<AIRetrieveConversationHistoriesResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AIRetrieveConversationHistoriesResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<AIRetrieveConversationHistoriesResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata following the standard Telnyx V2 API format.
    /// </summary>
    public required Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public AIRetrieveConversationHistoriesPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AIRetrieveConversationHistoriesPageResponse (
        AIRetrieveConversationHistoriesPageResponse aiRetrieveConversationHistoriesPageResponse
    ) : base(aiRetrieveConversationHistoriesPageResponse)
    {  }
    #pragma warning restore CS8618

    public AIRetrieveConversationHistoriesPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AIRetrieveConversationHistoriesPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AIRetrieveConversationHistoriesPageResponseFromRaw.FromRawUnchecked"/>
    public static AIRetrieveConversationHistoriesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AIRetrieveConversationHistoriesPageResponseFromRaw : IFromRawJson<AIRetrieveConversationHistoriesPageResponse>
{
    /// <inheritdoc/>
    public AIRetrieveConversationHistoriesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AIRetrieveConversationHistoriesPageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Pagination metadata following the standard Telnyx V2 API format.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// Current page number (1-based), matching the requested page[number].
    /// </summary>
    public required long PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page_number"
            );
        }
        init { this._rawData.Set("page_number", value); }
    }

    /// <summary>
    /// Number of results per page, matching the requested page[size].
    /// </summary>
    public required long PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page_size"
            );
        }
        init { this._rawData.Set("page_size", value); }
    }

    /// <summary>
    /// Total number of pages.
    /// </summary>
    public required long TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_pages"
            );
        }
        init { this._rawData.Set("total_pages", value); }
    }

    /// <summary>
    /// Total number of matching results across all queried regions.
    /// </summary>
    public required long TotalResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_results"
            );
        }
        init { this._rawData.Set("total_results", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PageNumber;
        _ = this.PageSize;
        _ = this.TotalPages;
        _ = this.TotalResults;
    }

    public Meta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta (Meta meta) : base(meta)
    {  }
    #pragma warning restore CS8618

    public Meta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}