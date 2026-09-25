using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.UsageReports;

[JsonConverter(typeof(JsonModelConverter<UsageReportListPageResponse, UsageReportListPageResponseFromRaw>))]
public sealed record class UsageReportListPageResponse : JsonModel
{
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    public Meta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Meta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        this.Meta?.Validate();
    }

    public UsageReportListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageReportListPageResponse (
        UsageReportListPageResponse usageReportListPageResponse
    ) : base(usageReportListPageResponse)
    {  }
    #pragma warning restore CS8618

    public UsageReportListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageReportListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UsageReportListPageResponseFromRaw.FromRawUnchecked"/>
    public static UsageReportListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UsageReportListPageResponseFromRaw : IFromRawJson<UsageReportListPageResponse>
{
    /// <inheritdoc/>
    public UsageReportListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UsageReportListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// Selected page number.
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
    /// Records per single page
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
    /// Total number of results.
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