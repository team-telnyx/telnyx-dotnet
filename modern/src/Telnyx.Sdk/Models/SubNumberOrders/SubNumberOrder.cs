using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SubNumberOrders;

[JsonConverter(typeof(JsonModelConverter<SubNumberOrder, SubNumberOrderFromRaw>))]
public sealed record class SubNumberOrder : JsonModel
{
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
    /// An ISO 8901 datetime string denoting when the number order was created.
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
    /// A customer reference string for customer look ups.
    /// </summary>
    public string? CustomerReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("customer_reference", value);
        }
    }

    /// <summary>
    /// True if the sub number order is a block sub number order
    /// </summary>
    public bool? IsBlockSubNumberOrder {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_block_sub_number_order"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_block_sub_number_order", value);
        }
    }

    public string? OrderRequestID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "order_request_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("order_request_id", value);
        }
    }

    public ApiEnum<string, SubNumberOrderPhoneNumberType>? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SubNumberOrderPhoneNumberType>>(
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
    /// The count of phone numbers in the number order.
    /// </summary>
    public long? PhoneNumbersCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "phone_numbers_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_numbers_count", value);
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

    public IReadOnlyList<SubNumberOrderRegulatoryRequirement>? RegulatoryRequirements {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SubNumberOrderRegulatoryRequirement>>(
                "regulatory_requirements"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SubNumberOrderRegulatoryRequirement>?>(
                "regulatory_requirements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// True if all requirements are met for every phone number, false otherwise.
    /// </summary>
    public bool? RequirementsMet {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "requirements_met"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirements_met", value);
        }
    }

    /// <summary>
    /// The status of the order.
    /// </summary>
    public ApiEnum<string, SubNumberOrderStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SubNumberOrderStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// An ISO 8901 datetime string for when the number order was updated.
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

    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CountryCode;
        _ = this.CreatedAt;
        _ = this.CustomerReference;
        _ = this.IsBlockSubNumberOrder;
        _ = this.OrderRequestID;
        this.PhoneNumberType?.Validate();
        _ = this.PhoneNumbersCount;
        _ = this.RecordType;
        foreach (var item in this.RegulatoryRequirements ?? [])
        {
            item.Validate();
        }
        _ = this.RequirementsMet;
        this.Status?.Validate();
        _ = this.UpdatedAt;
        _ = this.UserID;
    }

    public SubNumberOrder ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrder (SubNumberOrder subNumberOrder) : base(subNumberOrder)
    {  }
    #pragma warning restore CS8618

    public SubNumberOrder (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrder (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SubNumberOrderFromRaw.FromRawUnchecked"/>
    public static SubNumberOrder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SubNumberOrderFromRaw : IFromRawJson<SubNumberOrder>
{
    /// <inheritdoc/>
    public SubNumberOrder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SubNumberOrder.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SubNumberOrderPhoneNumberTypeConverter))]
public enum SubNumberOrderPhoneNumberType
{
    Local, TollFree, Mobile, National, SharedCost, Landline
}sealed class SubNumberOrderPhoneNumberTypeConverter : JsonConverter<SubNumberOrderPhoneNumberType>
{
    public override SubNumberOrderPhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>SubNumberOrderPhoneNumberType.Local,
            "toll_free"=>SubNumberOrderPhoneNumberType.TollFree,
            "mobile"=>SubNumberOrderPhoneNumberType.Mobile,
            "national"=>SubNumberOrderPhoneNumberType.National,
            "shared_cost"=>SubNumberOrderPhoneNumberType.SharedCost,
            "landline"=>SubNumberOrderPhoneNumberType.Landline,
            _ =>(SubNumberOrderPhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubNumberOrderPhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SubNumberOrderPhoneNumberType.Local=>"local",
            SubNumberOrderPhoneNumberType.TollFree=>"toll_free",
            SubNumberOrderPhoneNumberType.Mobile=>"mobile",
            SubNumberOrderPhoneNumberType.National=>"national",
            SubNumberOrderPhoneNumberType.SharedCost=>"shared_cost",
            SubNumberOrderPhoneNumberType.Landline=>"landline",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the order.
/// </summary>
[JsonConverter(typeof(SubNumberOrderStatusConverter))]
public enum SubNumberOrderStatus
{
    Pending, Success, Failure
}sealed class SubNumberOrderStatusConverter : JsonConverter<SubNumberOrderStatus>
{
    public override SubNumberOrderStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>SubNumberOrderStatus.Pending,
            "success"=>SubNumberOrderStatus.Success,
            "failure"=>SubNumberOrderStatus.Failure,
            _ =>(SubNumberOrderStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubNumberOrderStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SubNumberOrderStatus.Pending=>"pending",
            SubNumberOrderStatus.Success=>"success",
            SubNumberOrderStatus.Failure=>"failure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}