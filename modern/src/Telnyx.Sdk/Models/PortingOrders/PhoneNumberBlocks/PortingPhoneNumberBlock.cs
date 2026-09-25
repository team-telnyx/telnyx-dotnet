using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberBlocks;

[JsonConverter(typeof(JsonModelConverter<PortingPhoneNumberBlock, PortingPhoneNumberBlockFromRaw>))]
public sealed record class PortingPhoneNumberBlock : JsonModel
{
    /// <summary>
    /// Uniquely identifies this porting phone number block.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Specifies the activation ranges for this porting phone number block. The activation
    /// range must be within the phone number range and should not overlap with other
    /// activation ranges.
    /// </summary>
    public IReadOnlyList<PortingPhoneNumberBlockActivationRange>? ActivationRanges {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingPhoneNumberBlockActivationRange>>(
                "activation_ranges"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingPhoneNumberBlockActivationRange>?>(
                "activation_ranges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Specifies the country code for this porting phone number block. It is a two-letter
    /// ISO 3166-1 alpha-2 country code.
    /// </summary>
    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Specifies the phone number range for this porting phone number block.
    /// </summary>
    public PortingPhoneNumberBlockPhoneNumberRange? PhoneNumberRange {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingPhoneNumberBlockPhoneNumberRange>(
                "phone_number_range"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number_range", value);
        }
    }

    /// <summary>
    /// Specifies the phone number type for this porting phone number block.
    /// </summary>
    public ApiEnum<string, PhoneNumberType>? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberType>>(
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

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
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

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was last updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.ActivationRanges ?? [])
        {
            item.Validate();
        }
        _ = this.CountryCode;
        _ = this.CreatedAt;
        this.PhoneNumberRange?.Validate();
        this.PhoneNumberType?.Validate();
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public PortingPhoneNumberBlock ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingPhoneNumberBlock (
        PortingPhoneNumberBlock portingPhoneNumberBlock
    ) : base(portingPhoneNumberBlock)
    {  }
    #pragma warning restore CS8618

    public PortingPhoneNumberBlock (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingPhoneNumberBlock (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingPhoneNumberBlockFromRaw.FromRawUnchecked"/>
    public static PortingPhoneNumberBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingPhoneNumberBlockFromRaw : IFromRawJson<PortingPhoneNumberBlock>
{
    /// <inheritdoc/>
    public PortingPhoneNumberBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingPhoneNumberBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PortingPhoneNumberBlockActivationRange, PortingPhoneNumberBlockActivationRangeFromRaw>))]
public sealed record class PortingPhoneNumberBlockActivationRange : JsonModel
{
    /// <summary>
    /// Specifies the end of the activation range. It must be no more than the end
    /// of the phone number range.
    /// </summary>
    public string? EndAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "end_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_at", value);
        }
    }

    /// <summary>
    /// Specifies the start of the activation range. Must be greater or equal the
    /// start of the phone number range.
    /// </summary>
    public string? StartAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "start_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndAt;
        _ = this.StartAt;
    }

    public PortingPhoneNumberBlockActivationRange ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingPhoneNumberBlockActivationRange (
        PortingPhoneNumberBlockActivationRange portingPhoneNumberBlockActivationRange
    ) : base(portingPhoneNumberBlockActivationRange)
    {  }
    #pragma warning restore CS8618

    public PortingPhoneNumberBlockActivationRange (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingPhoneNumberBlockActivationRange (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingPhoneNumberBlockActivationRangeFromRaw.FromRawUnchecked"/>
    public static PortingPhoneNumberBlockActivationRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingPhoneNumberBlockActivationRangeFromRaw : IFromRawJson<PortingPhoneNumberBlockActivationRange>
{
    /// <inheritdoc/>
    public PortingPhoneNumberBlockActivationRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingPhoneNumberBlockActivationRange.FromRawUnchecked(rawData);
}/// <summary>
/// Specifies the phone number range for this porting phone number block.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingPhoneNumberBlockPhoneNumberRange, PortingPhoneNumberBlockPhoneNumberRangeFromRaw>))]
public sealed record class PortingPhoneNumberBlockPhoneNumberRange : JsonModel
{
    /// <summary>
    /// Specifies the end of the phone number range for this porting phone number block.
    /// </summary>
    public string? EndAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "end_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_at", value);
        }
    }

    /// <summary>
    /// Specifies the start of the phone number range for this porting phone number block.
    /// </summary>
    public string? StartAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "start_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndAt;
        _ = this.StartAt;
    }

    public PortingPhoneNumberBlockPhoneNumberRange ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingPhoneNumberBlockPhoneNumberRange (
        PortingPhoneNumberBlockPhoneNumberRange portingPhoneNumberBlockPhoneNumberRange
    ) : base(portingPhoneNumberBlockPhoneNumberRange)
    {  }
    #pragma warning restore CS8618

    public PortingPhoneNumberBlockPhoneNumberRange (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingPhoneNumberBlockPhoneNumberRange (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingPhoneNumberBlockPhoneNumberRangeFromRaw.FromRawUnchecked"/>
    public static PortingPhoneNumberBlockPhoneNumberRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingPhoneNumberBlockPhoneNumberRangeFromRaw : IFromRawJson<PortingPhoneNumberBlockPhoneNumberRange>
{
    /// <inheritdoc/>
    public PortingPhoneNumberBlockPhoneNumberRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingPhoneNumberBlockPhoneNumberRange.FromRawUnchecked(rawData);
}/// <summary>
/// Specifies the phone number type for this porting phone number block.
/// </summary>
[JsonConverter(typeof(PhoneNumberTypeConverter))]
public enum PhoneNumberType
{
    Landline, Local, Mobile, National, SharedCost, TollFree
}sealed class PhoneNumberTypeConverter : JsonConverter<PhoneNumberType>
{
    public override PhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "landline"=>PhoneNumberType.Landline,
            "local"=>PhoneNumberType.Local,
            "mobile"=>PhoneNumberType.Mobile,
            "national"=>PhoneNumberType.National,
            "shared_cost"=>PhoneNumberType.SharedCost,
            "toll_free"=>PhoneNumberType.TollFree,
            _ =>(PhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberType.Landline=>"landline",
            PhoneNumberType.Local=>"local",
            PhoneNumberType.Mobile=>"mobile",
            PhoneNumberType.National=>"national",
            PhoneNumberType.SharedCost=>"shared_cost",
            PhoneNumberType.TollFree=>"toll_free",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}