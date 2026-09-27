using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

[JsonConverter(typeof(JsonModelConverter<BrandListPageResponse, BrandListPageResponseFromRaw>))]
public sealed record class BrandListPageResponse : JsonModel
{
    public long? Page {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page", value);
        }
    }

    public IReadOnlyList<BrandListResponse>? Records {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BrandListResponse>>(
                "records"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<BrandListResponse>?>(
                "records",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? TotalRecords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "totalRecords"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("totalRecords", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Page;
        foreach (var item in this.Records ?? [])
        {
            item.Validate();
        }
        _ = this.TotalRecords;
    }

    public BrandListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandListPageResponse (
        BrandListPageResponse brandListPageResponse
    ) : base(brandListPageResponse)
    {  }
    #pragma warning restore CS8618

    public BrandListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandListPageResponseFromRaw.FromRawUnchecked"/>
    public static BrandListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandListPageResponseFromRaw : IFromRawJson<BrandListPageResponse>
{
    /// <inheritdoc/>
    public BrandListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandListPageResponse.FromRawUnchecked(rawData);
}