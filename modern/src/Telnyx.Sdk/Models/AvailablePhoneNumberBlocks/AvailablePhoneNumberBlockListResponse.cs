using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AvailablePhoneNumberBlocks;

[JsonConverter(typeof(JsonModelConverter<AvailablePhoneNumberBlockListResponse, AvailablePhoneNumberBlockListResponseFromRaw>))]
public sealed record class AvailablePhoneNumberBlockListResponse : JsonModel
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

    public AvailablePhoneNumbersMetadata? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AvailablePhoneNumbersMetadata>(
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

    public AvailablePhoneNumberBlockListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AvailablePhoneNumberBlockListResponse (
        AvailablePhoneNumberBlockListResponse availablePhoneNumberBlockListResponse
    ) : base(availablePhoneNumberBlockListResponse)
    {  }
    #pragma warning restore CS8618

    public AvailablePhoneNumberBlockListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AvailablePhoneNumberBlockListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AvailablePhoneNumberBlockListResponseFromRaw.FromRawUnchecked"/>
    public static AvailablePhoneNumberBlockListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AvailablePhoneNumberBlockListResponseFromRaw : IFromRawJson<AvailablePhoneNumberBlockListResponse>
{
    /// <inheritdoc/>
    public AvailablePhoneNumberBlockListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AvailablePhoneNumberBlockListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public CostInformation? CostInformation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CostInformation>(
                "cost_information"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cost_information", value);
        }
    }

    public IReadOnlyList<Feature>? Features {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Feature>>(
                "features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Feature>?>(
                "features",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    public long? Range {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "range"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("range", value);
        }
    }

    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
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

    public IReadOnlyList<RegionInformation>? RegionInformation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RegionInformation>>(
                "region_information"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RegionInformation>?>(
                "region_information",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CostInformation?.Validate();
        foreach (var item in this.Features ?? [])
        {
            item.Validate();
        }
        _ = this.PhoneNumber;
        _ = this.Range;
        this.RecordType?.Validate();
        foreach (var item in this.RegionInformation ?? [])
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
}[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    AvailablePhoneNumberBlock
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "available_phone_number_block"=>RecordType.AvailablePhoneNumberBlock,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.AvailablePhoneNumberBlock=>"available_phone_number_block",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}