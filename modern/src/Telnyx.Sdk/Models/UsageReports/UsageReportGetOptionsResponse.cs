using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.UsageReports;

/// <summary>
/// An object following one of the schemas published in https://developers.telnyx.com/docs/api/v2/detail-records
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UsageReportGetOptionsResponse, UsageReportGetOptionsResponseFromRaw>))]
public sealed record class UsageReportGetOptionsResponse : JsonModel
{
    /// <summary>
    /// Collection of product description
    /// </summary>
    public IReadOnlyList<Data>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Data>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public UsageReportGetOptionsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageReportGetOptionsResponse (
        UsageReportGetOptionsResponse usageReportGetOptionsResponse
    ) : base(usageReportGetOptionsResponse)
    {  }
    #pragma warning restore CS8618

    public UsageReportGetOptionsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageReportGetOptionsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UsageReportGetOptionsResponseFromRaw.FromRawUnchecked"/>
    public static UsageReportGetOptionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UsageReportGetOptionsResponseFromRaw : IFromRawJson<UsageReportGetOptionsResponse>
{
    /// <inheritdoc/>
    public UsageReportGetOptionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UsageReportGetOptionsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// An object following one of the schemas published in https://developers.telnyx.com/docs/api/v2/detail-records
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Telnyx Product
    /// </summary>
    public string? Product {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "product"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("product", value);
        }
    }

    /// <summary>
    /// Telnyx Product Dimensions
    /// </summary>
    public IReadOnlyList<string>? ProductDimensions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "product_dimensions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "product_dimensions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Telnyx Product Metrics
    /// </summary>
    public IReadOnlyList<string>? ProductMetrics {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "product_metrics"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "product_metrics",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Subproducts if applicable
    /// </summary>
    public IReadOnlyList<RecordType>? RecordTypes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RecordType>>(
                "record_types"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RecordType>?>(
                "record_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Product;
        _ = this.ProductDimensions;
        _ = this.ProductMetrics;
        foreach (var item in this.RecordTypes ?? [])
        {
            item.Validate();
        }
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}/// <summary>
/// An object following one of the schemas published in https://developers.telnyx.com/docs/api/v2/detail-records
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RecordType, RecordTypeFromRaw>))]
public sealed record class RecordType : JsonModel
{
    /// <summary>
    /// Telnyx Product Dimensions
    /// </summary>
    public IReadOnlyList<string>? ProductDimensions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "product_dimensions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "product_dimensions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Telnyx Product Metrics
    /// </summary>
    public IReadOnlyList<string>? ProductMetrics {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "product_metrics"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "product_metrics",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Telnyx Product type
    /// </summary>
    public string? RecordTypeValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProductDimensions;
        _ = this.ProductMetrics;
        _ = this.RecordTypeValue;
    }

    public RecordType ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordType (RecordType recordType) : base(recordType)
    {  }
    #pragma warning restore CS8618

    public RecordType (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordType (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordTypeFromRaw.FromRawUnchecked"/>
    public static RecordType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RecordTypeFromRaw : IFromRawJson<RecordType>
{
    /// <inheritdoc/>
    public RecordType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecordType.FromRawUnchecked(rawData);
}