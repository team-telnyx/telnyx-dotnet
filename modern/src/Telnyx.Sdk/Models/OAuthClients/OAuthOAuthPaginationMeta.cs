using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OAuthClients;

[JsonConverter(typeof(JsonModelConverter<OAuthOAuthPaginationMeta, OAuthOAuthPaginationMetaFromRaw>))]
public sealed record class OAuthOAuthPaginationMeta : JsonModel
{
    /// <summary>
    /// Current page number
    /// </summary>
    public long? PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page_number", value);
        }
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
    /// Total number of pages
    /// </summary>
    public long? TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "total_pages"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_pages", value);
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
        _ = this.PageSize;
        _ = this.TotalPages;
        _ = this.TotalResults;
    }

    public OAuthOAuthPaginationMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthOAuthPaginationMeta (
        OAuthOAuthPaginationMeta oauthOAuthPaginationMeta
    ) : base(oauthOAuthPaginationMeta)
    {  }
    #pragma warning restore CS8618

    public OAuthOAuthPaginationMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthOAuthPaginationMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthOAuthPaginationMetaFromRaw.FromRawUnchecked"/>
    public static OAuthOAuthPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthOAuthPaginationMetaFromRaw : IFromRawJson<OAuthOAuthPaginationMeta>
{
    /// <inheritdoc/>
    public OAuthOAuthPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthOAuthPaginationMeta.FromRawUnchecked(rawData);
}