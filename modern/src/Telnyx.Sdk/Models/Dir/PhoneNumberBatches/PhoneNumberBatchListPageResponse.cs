using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.CallReasons;

namespace Telnyx.Sdk.Models.Dir.PhoneNumberBatches;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberBatchListPageResponse, PhoneNumberBatchListPageResponseFromRaw>))]
public sealed record class PhoneNumberBatchListPageResponse : JsonModel
{
    public required IReadOnlyList<PhoneNumberBatch> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PhoneNumberBatch>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<PhoneNumberBatch>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// JSON:API pagination metadata returned with every paginated list response.
    /// Page numbering is 1-based. `page_size` reports the number of items actually
    /// returned in `data` for this page; the requested size is taken from the `page[size]`
    /// query parameter.
    /// </summary>
    public required BrandedCallingPaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrandedCallingPaginationMeta>(
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

    public PhoneNumberBatchListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberBatchListPageResponse (
        PhoneNumberBatchListPageResponse phoneNumberBatchListPageResponse
    ) : base(phoneNumberBatchListPageResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberBatchListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberBatchListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberBatchListPageResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberBatchListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberBatchListPageResponseFromRaw : IFromRawJson<PhoneNumberBatchListPageResponse>
{
    /// <inheritdoc/>
    public PhoneNumberBatchListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberBatchListPageResponse.FromRawUnchecked(rawData);
}