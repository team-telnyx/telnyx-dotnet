using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Reports;

[JsonConverter(typeof(JsonModelConverter<ReportListWdrsPageResponse, ReportListWdrsPageResponseFromRaw>))]
public sealed record class ReportListWdrsPageResponse : JsonModel
{
    public IReadOnlyList<ReportListWdrsResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ReportListWdrsResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ReportListWdrsResponse>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public ReportListWdrsPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportListWdrsPageResponse (
        ReportListWdrsPageResponse reportListWdrsPageResponse
    ) : base(reportListWdrsPageResponse)
    {  }
    #pragma warning restore CS8618

    public ReportListWdrsPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportListWdrsPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReportListWdrsPageResponseFromRaw.FromRawUnchecked"/>
    public static ReportListWdrsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReportListWdrsPageResponseFromRaw : IFromRawJson<ReportListWdrsPageResponse>
{
    /// <inheritdoc/>
    public ReportListWdrsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReportListWdrsPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
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