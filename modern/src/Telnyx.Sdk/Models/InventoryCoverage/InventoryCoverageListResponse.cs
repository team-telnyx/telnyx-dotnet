using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.InventoryCoverage;

[JsonConverter(typeof(JsonModelConverter<InventoryCoverageListResponse, InventoryCoverageListResponseFromRaw>))]
public sealed record class InventoryCoverageListResponse : JsonModel
{
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

    public InventoryCoverageListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InventoryCoverageListResponse (
        InventoryCoverageListResponse inventoryCoverageListResponse
    ) : base(inventoryCoverageListResponse)
    {  }
    #pragma warning restore CS8618

    public InventoryCoverageListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InventoryCoverageListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InventoryCoverageListResponseFromRaw.FromRawUnchecked"/>
    public static InventoryCoverageListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InventoryCoverageListResponseFromRaw : IFromRawJson<InventoryCoverageListResponse>
{
    /// <inheritdoc/>
    public InventoryCoverageListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InventoryCoverageListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public string? AdministrativeArea {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "administrative_area"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("administrative_area", value);
        }
    }

    /// <summary>
    /// Indicates if the phone number requires advance requirements.
    /// </summary>
    public bool? AdvanceRequirements {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "advance_requirements"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("advance_requirements", value);
        }
    }

    public long? Count {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("count", value);
        }
    }

    public ApiEnum<string, CoverageType>? CoverageType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CoverageType>>(
                "coverage_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("coverage_type", value);
        }
    }

    public string? Group {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "group"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("group", value);
        }
    }

    public string? GroupType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "group_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("group_type", value);
        }
    }

    public long? NumberRange {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "number_range"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("number_range", value);
        }
    }

    public ApiEnum<string, NumberType>? NumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NumberType>>(
                "number_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("number_type", value);
        }
    }

    public ApiEnum<string, DataPhoneNumberType>? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataPhoneNumberType>>(
                "phone_number_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number_type", value);
        }
    }

    public string? RecordType {
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
        _ = this.AdministrativeArea;
        _ = this.AdvanceRequirements;
        _ = this.Count;
        this.CoverageType?.Validate();
        _ = this.Group;
        _ = this.GroupType;
        _ = this.NumberRange;
        this.NumberType?.Validate();
        this.PhoneNumberType?.Validate();
        _ = this.RecordType;
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
}[JsonConverter(typeof(CoverageTypeConverter))]
public enum CoverageType
{
    Number, Block
}sealed class CoverageTypeConverter : JsonConverter<CoverageType>
{
    public override CoverageType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "number"=>CoverageType.Number,
            "block"=>CoverageType.Block,
            _ =>(CoverageType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, CoverageType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CoverageType.Number=>"number",
            CoverageType.Block=>"block",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(NumberTypeConverter))]
public enum NumberType
{
    Did, TollFree
}sealed class NumberTypeConverter : JsonConverter<NumberType>
{
    public override NumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "did"=>NumberType.Did,
            "toll-free"=>NumberType.TollFree,
            _ =>(NumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, NumberType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NumberType.Did=>"did",
            NumberType.TollFree=>"toll-free",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(DataPhoneNumberTypeConverter))]
public enum DataPhoneNumberType
{
    Local, TollFree, National, Landline, SharedCost, Mobile
}sealed class DataPhoneNumberTypeConverter : JsonConverter<DataPhoneNumberType>
{
    public override DataPhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>DataPhoneNumberType.Local,
            "toll_free"=>DataPhoneNumberType.TollFree,
            "national"=>DataPhoneNumberType.National,
            "landline"=>DataPhoneNumberType.Landline,
            "shared_cost"=>DataPhoneNumberType.SharedCost,
            "mobile"=>DataPhoneNumberType.Mobile,
            _ =>(DataPhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataPhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataPhoneNumberType.Local=>"local",
            DataPhoneNumberType.TollFree=>"toll_free",
            DataPhoneNumberType.National=>"national",
            DataPhoneNumberType.Landline=>"landline",
            DataPhoneNumberType.SharedCost=>"shared_cost",
            DataPhoneNumberType.Mobile=>"mobile",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
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
    { _ = this.TotalResults; }

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