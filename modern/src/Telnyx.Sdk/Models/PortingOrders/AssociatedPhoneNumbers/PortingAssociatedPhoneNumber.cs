using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders.AssociatedPhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PortingAssociatedPhoneNumber, PortingAssociatedPhoneNumberFromRaw>))]
public sealed record class PortingAssociatedPhoneNumber : JsonModel
{
    /// <summary>
    /// Uniquely identifies this associated phone number.
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
    /// Specifies the action to take with this phone number during partial porting.
    /// </summary>
    public ApiEnum<string, PortingAssociatedPhoneNumberAction>? Action {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingAssociatedPhoneNumberAction>>(
                "action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action", value);
        }
    }

    /// <summary>
    /// Specifies the country code for this associated phone number. It is a two-letter
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
    /// Specifies the phone number range for this associated phone number.
    /// </summary>
    public PortingAssociatedPhoneNumberPhoneNumberRange? PhoneNumberRange {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingAssociatedPhoneNumberPhoneNumberRange>(
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
    /// Specifies the phone number type for this associated phone number.
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
    /// Identifies the porting order associated with this phone number.
    /// </summary>
    public string? PortingOrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "porting_order_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("porting_order_id", value);
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
        this.Action?.Validate();
        _ = this.CountryCode;
        _ = this.CreatedAt;
        this.PhoneNumberRange?.Validate();
        this.PhoneNumberType?.Validate();
        _ = this.PortingOrderID;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public PortingAssociatedPhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingAssociatedPhoneNumber (
        PortingAssociatedPhoneNumber portingAssociatedPhoneNumber
    ) : base(portingAssociatedPhoneNumber)
    {  }
    #pragma warning restore CS8618

    public PortingAssociatedPhoneNumber (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingAssociatedPhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingAssociatedPhoneNumberFromRaw.FromRawUnchecked"/>
    public static PortingAssociatedPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingAssociatedPhoneNumberFromRaw : IFromRawJson<PortingAssociatedPhoneNumber>
{
    /// <inheritdoc/>
    public PortingAssociatedPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingAssociatedPhoneNumber.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the action to take with this phone number during partial porting.
/// </summary>
[JsonConverter(typeof(PortingAssociatedPhoneNumberActionConverter))]
public enum PortingAssociatedPhoneNumberAction
{
    Keep, Disconnect
}sealed class PortingAssociatedPhoneNumberActionConverter : JsonConverter<PortingAssociatedPhoneNumberAction>
{
    public override PortingAssociatedPhoneNumberAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "keep"=>PortingAssociatedPhoneNumberAction.Keep,
            "disconnect"=>PortingAssociatedPhoneNumberAction.Disconnect,
            _ =>(PortingAssociatedPhoneNumberAction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingAssociatedPhoneNumberAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingAssociatedPhoneNumberAction.Keep=>"keep",
            PortingAssociatedPhoneNumberAction.Disconnect=>"disconnect",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Specifies the phone number range for this associated phone number.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingAssociatedPhoneNumberPhoneNumberRange, PortingAssociatedPhoneNumberPhoneNumberRangeFromRaw>))]
public sealed record class PortingAssociatedPhoneNumberPhoneNumberRange : JsonModel
{
    /// <summary>
    /// Specifies the end of the phone number range for this associated phone number.
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
    /// Specifies the start of the phone number range for this associated phone number.
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

    public PortingAssociatedPhoneNumberPhoneNumberRange ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingAssociatedPhoneNumberPhoneNumberRange (
        PortingAssociatedPhoneNumberPhoneNumberRange portingAssociatedPhoneNumberPhoneNumberRange
    ) : base(portingAssociatedPhoneNumberPhoneNumberRange)
    {  }
    #pragma warning restore CS8618

    public PortingAssociatedPhoneNumberPhoneNumberRange (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingAssociatedPhoneNumberPhoneNumberRange (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingAssociatedPhoneNumberPhoneNumberRangeFromRaw.FromRawUnchecked"/>
    public static PortingAssociatedPhoneNumberPhoneNumberRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingAssociatedPhoneNumberPhoneNumberRangeFromRaw : IFromRawJson<PortingAssociatedPhoneNumberPhoneNumberRange>
{
    /// <inheritdoc/>
    public PortingAssociatedPhoneNumberPhoneNumberRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingAssociatedPhoneNumberPhoneNumberRange.FromRawUnchecked(rawData);
}/// <summary>
/// Specifies the phone number type for this associated phone number.
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