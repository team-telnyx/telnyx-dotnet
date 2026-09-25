using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : JsonModel
{
    /// <summary>
    /// Current Page based on pagination settings (included when defaults are used.)
    /// </summary>
    public required int PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>(
                "page_number"
            );
        }
        init { this._rawData.Set("page_number", value); }
    }

    /// <summary>
    /// Total number of pages based on pagination settings
    /// </summary>
    public required int TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>(
                "total_pages"
            );
        }
        init { this._rawData.Set("total_pages", value); }
    }

    /// <summary>
    /// Number of results to return per page based on pagination settings (included
    /// when defaults are used.)
    /// </summary>
    public int? PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
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
    public int? TotalResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
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
}

class MetadataFromRaw : IFromRawJson<Metadata>
{
    /// <inheritdoc/>
    public Metadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Metadata.FromRawUnchecked(rawData);
}