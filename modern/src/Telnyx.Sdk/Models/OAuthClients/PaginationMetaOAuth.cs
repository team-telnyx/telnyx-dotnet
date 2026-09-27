using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OAuthClients;

[JsonConverter(typeof(JsonModelConverter<PaginationMetaOAuth, PaginationMetaOAuthFromRaw>))]
public sealed record class PaginationMetaOAuth : JsonModel
{
    /// <summary>
    /// Current page number
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
    /// Total number of pages
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
    /// Number of items per page
    /// </summary>
    public long? PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page_size", value);
        }
    }

    /// <summary>
    /// Total number of results
    /// </summary>
    public long? TotalResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "total_results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_results", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PageNumber;
        _ = this.TotalPages;
        _ = this.PageSize;
        _ = this.TotalResults;
    }

    public PaginationMetaOAuth ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginationMetaOAuth (PaginationMetaOAuth paginationMetaOAuth) : base(
        paginationMetaOAuth
    )
    {  }
    #pragma warning restore CS8618

    public PaginationMetaOAuth (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginationMetaOAuth (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PaginationMetaOAuthFromRaw.FromRawUnchecked"/>
    public static PaginationMetaOAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PaginationMetaOAuthFromRaw : IFromRawJson<PaginationMetaOAuth>
{
    /// <inheritdoc/>
    public PaginationMetaOAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PaginationMetaOAuth.FromRawUnchecked(rawData);
}