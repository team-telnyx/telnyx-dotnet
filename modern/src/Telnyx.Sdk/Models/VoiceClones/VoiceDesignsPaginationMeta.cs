using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VoiceClones;

/// <summary>
/// Pagination metadata returned with list responses.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceDesignsPaginationMeta, VoiceDesignsPaginationMetaFromRaw>))]
public sealed record class VoiceDesignsPaginationMeta : JsonModel
{
    /// <summary>
    /// Current page number (1-based).
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
    /// Number of results per page.
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
    /// Total number of pages.
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
    /// Total number of results across all pages.
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

    public VoiceDesignsPaginationMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceDesignsPaginationMeta (
        VoiceDesignsPaginationMeta voiceDesignsPaginationMeta
    ) : base(voiceDesignsPaginationMeta)
    {  }
    #pragma warning restore CS8618

    public VoiceDesignsPaginationMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceDesignsPaginationMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceDesignsPaginationMetaFromRaw.FromRawUnchecked"/>
    public static VoiceDesignsPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceDesignsPaginationMetaFromRaw : IFromRawJson<VoiceDesignsPaginationMeta>
{
    /// <inheritdoc/>
    public VoiceDesignsPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceDesignsPaginationMeta.FromRawUnchecked(rawData);
}