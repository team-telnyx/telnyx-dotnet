using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.Messaging;

[JsonConverter(typeof(JsonModelConverter<StandardPaginationMetaFfba4faa88, StandardPaginationMetaFfba4faa88FromRaw>))]
public sealed record class StandardPaginationMetaFfba4faa88 : JsonModel
{
    public int? PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
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

    public int? TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
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
        _ = this.PageSize;
        _ = this.TotalPages;
        _ = this.TotalResults;
    }

    public StandardPaginationMetaFfba4faa88 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StandardPaginationMetaFfba4faa88 (
        StandardPaginationMetaFfba4faa88 standardPaginationMetaFfba4faa88
    ) : base(standardPaginationMetaFfba4faa88)
    {  }
    #pragma warning restore CS8618

    public StandardPaginationMetaFfba4faa88 (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StandardPaginationMetaFfba4faa88 (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StandardPaginationMetaFfba4faa88FromRaw.FromRawUnchecked"/>
    public static StandardPaginationMetaFfba4faa88 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class StandardPaginationMetaFfba4faa88FromRaw : IFromRawJson<StandardPaginationMetaFfba4faa88>
{
    /// <inheritdoc/>
    public StandardPaginationMetaFfba4faa88 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StandardPaginationMetaFfba4faa88.FromRawUnchecked(rawData);
}