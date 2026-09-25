using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.DetailRecords;

[JsonConverter(typeof(JsonModelConverter<DetailRecordListPageResponse, DetailRecordListPageResponseFromRaw>))]
public sealed record class DetailRecordListPageResponse : JsonModel
{
    public IReadOnlyList<DetailRecordListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DetailRecordListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<DetailRecordListResponse>?>(
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

    public DetailRecordListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DetailRecordListPageResponse (
        DetailRecordListPageResponse detailRecordListPageResponse
    ) : base(detailRecordListPageResponse)
    {  }
    #pragma warning restore CS8618

    public DetailRecordListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DetailRecordListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DetailRecordListPageResponseFromRaw.FromRawUnchecked"/>
    public static DetailRecordListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DetailRecordListPageResponseFromRaw : IFromRawJson<DetailRecordListPageResponse>
{
    /// <inheritdoc/>
    public DetailRecordListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DetailRecordListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    public required int PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>(
                "page_number"
            );
        }
        init { this._rawData.Set("page_number", value); }
    }

    public required int TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>(
                "total_pages"
            );
        }
        init { this._rawData.Set("total_pages", value); }
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