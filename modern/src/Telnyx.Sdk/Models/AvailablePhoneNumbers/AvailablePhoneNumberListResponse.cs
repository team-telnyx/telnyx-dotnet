using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Models = Telnyx.Sdk.Models;

namespace Telnyx.Sdk.Models.AvailablePhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<AvailablePhoneNumberListResponse, AvailablePhoneNumberListResponseFromRaw>))]
public sealed record class AvailablePhoneNumberListResponse : JsonModel
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

    public AvailablePhoneNumbersMetadata? Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AvailablePhoneNumbersMetadata>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("metadata", value);
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
        this.Metadata?.Validate();
    }

    public AvailablePhoneNumberListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AvailablePhoneNumberListResponse (
        AvailablePhoneNumberListResponse availablePhoneNumberListResponse
    ) : base(availablePhoneNumberListResponse)
    {  }
    #pragma warning restore CS8618

    public AvailablePhoneNumberListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AvailablePhoneNumberListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AvailablePhoneNumberListResponseFromRaw.FromRawUnchecked"/>
    public static AvailablePhoneNumberListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AvailablePhoneNumberListResponseFromRaw : IFromRawJson<AvailablePhoneNumberListResponse>
{
    /// <inheritdoc/>
    public AvailablePhoneNumberListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AvailablePhoneNumberListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Specifies whether the phone number is an exact match based on the search criteria
    /// or not.
    /// </summary>
    public bool? BestEffort {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "best_effort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("best_effort", value);
        }
    }

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

    public IReadOnlyList<Models::Feature>? Features {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Models::Feature>>(
                "features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Models::Feature>?>(
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

    /// <summary>
    /// Specifies whether the phone number can receive calls immediately after purchase
    /// or not.
    /// </summary>
    public bool? Quickship {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "quickship"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quickship", value);
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

    public IReadOnlyList<Models::RegionInformation>? RegionInformation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Models::RegionInformation>>(
                "region_information"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Models::RegionInformation>?>(
                "region_information",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Specifies whether the phone number can be reserved before purchase or not.
    /// </summary>
    public bool? Reservable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "reservable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reservable", value);
        }
    }

    public string? VanityFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "vanity_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("vanity_format", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BestEffort;
        this.CostInformation?.Validate();
        foreach (var item in this.Features ?? [])
        {
            item.Validate();
        }
        _ = this.PhoneNumber;
        _ = this.Quickship;
        this.RecordType?.Validate();
        foreach (var item in this.RegionInformation ?? [])
        {
            item.Validate();
        }
        _ = this.Reservable;
        _ = this.VanityFormat;
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
    AvailablePhoneNumber
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
            "available_phone_number"=>RecordType.AvailablePhoneNumber,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.AvailablePhoneNumber=>"available_phone_number",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}