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

[JsonConverter(typeof(JsonModelConverter<NumbersSubNumberOrder, NumbersSubNumberOrderFromRaw>))]
public sealed record class NumbersSubNumberOrder : JsonModel
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
    /// The first 50 phone numbers in the sub number order, including their per-number
    /// regulatory requirement statuses. Only present when filter[include_phone_numbers]=true
    /// is used.
    /// </summary>
    public IReadOnlyList<PhoneNumber>? PhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PhoneNumber>>(
                "phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PhoneNumber>?>(
                "phone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
    public ApiEnum<string, NumbersSubNumberOrderStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NumbersSubNumberOrderStatus>>(
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
        foreach (var item in this.PhoneNumbers ?? [])
        {
            item.Validate();
        }
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

    public NumbersSubNumberOrder ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumbersSubNumberOrder (
        NumbersSubNumberOrder numbersSubNumberOrder
    ) : base(numbersSubNumberOrder)
    {  }
    #pragma warning restore CS8618

    public NumbersSubNumberOrder (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumbersSubNumberOrder (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumbersSubNumberOrderFromRaw.FromRawUnchecked"/>
    public static NumbersSubNumberOrder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumbersSubNumberOrderFromRaw : IFromRawJson<NumbersSubNumberOrder>
{
    /// <inheritdoc/>
    public NumbersSubNumberOrder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumbersSubNumberOrder.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PhoneNumberTypeConverter))]
public enum PhoneNumberType
{
    Local, TollFree, Mobile, National, SharedCost, Landline
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
            "local"=>PhoneNumberType.Local,
            "toll_free"=>PhoneNumberType.TollFree,
            "mobile"=>PhoneNumberType.Mobile,
            "national"=>PhoneNumberType.National,
            "shared_cost"=>PhoneNumberType.SharedCost,
            "landline"=>PhoneNumberType.Landline,
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
            PhoneNumberType.Local=>"local",
            PhoneNumberType.TollFree=>"toll_free",
            PhoneNumberType.Mobile=>"mobile",
            PhoneNumberType.National=>"national",
            PhoneNumberType.SharedCost=>"shared_cost",
            PhoneNumberType.Landline=>"landline",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<PhoneNumber, PhoneNumberFromRaw>))]
public sealed record class PhoneNumber : JsonModel
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

    public string? BundleID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "bundle_id"
            );
        }
        init { this._rawData.Set("bundle_id", value); }
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

    public string? PhoneNumberValue {
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

    public string? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    public IReadOnlyList<RegulatoryRequirement>? RegulatoryRequirements {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RegulatoryRequirement>>(
                "regulatory_requirements"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RegulatoryRequirement>?>(
                "regulatory_requirements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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

    public string? RequirementsStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "requirements_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirements_status", value);
        }
    }

    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BundleID;
        _ = this.CountryCode;
        _ = this.PhoneNumberValue;
        _ = this.PhoneNumberType;
        _ = this.RecordType;
        foreach (var item in this.RegulatoryRequirements ?? [])
        {
            item.Validate();
        }
        _ = this.RequirementsMet;
        _ = this.RequirementsStatus;
        _ = this.Status;
    }

    public PhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumber (PhoneNumber phoneNumber) : base(phoneNumber)
    {  }
    #pragma warning restore CS8618

    public PhoneNumber (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberFromRaw.FromRawUnchecked"/>
    public static PhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PhoneNumberFromRaw : IFromRawJson<PhoneNumber>
{
    /// <inheritdoc/>
    public PhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumber.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<RegulatoryRequirement, RegulatoryRequirementFromRaw>))]
public sealed record class RegulatoryRequirement : JsonModel
{
    public ApiEnum<string, FieldType>? FieldType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FieldType>>(
                "field_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("field_type", value);
        }
    }

    /// <summary>
    /// The value of the requirement, this could be an id to a resource or a string value.
    /// </summary>
    public string? FieldValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "field_value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("field_value", value);
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

    /// <summary>
    /// Unique id for a requirement.
    /// </summary>
    public string? RequirementID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "requirement_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirement_id", value);
        }
    }

    /// <summary>
    /// The status of the regulatory requirement for this phone number.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FieldType?.Validate();
        _ = this.FieldValue;
        _ = this.RecordType;
        _ = this.RequirementID;
        this.Status?.Validate();
    }

    public RegulatoryRequirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegulatoryRequirement (
        RegulatoryRequirement regulatoryRequirement
    ) : base(regulatoryRequirement)
    {  }
    #pragma warning restore CS8618

    public RegulatoryRequirement (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RegulatoryRequirement (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RegulatoryRequirementFromRaw.FromRawUnchecked"/>
    public static RegulatoryRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RegulatoryRequirementFromRaw : IFromRawJson<RegulatoryRequirement>
{
    /// <inheritdoc/>
    public RegulatoryRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RegulatoryRequirement.FromRawUnchecked(rawData);
}[JsonConverter(typeof(FieldTypeConverter))]
public enum FieldType
{
    Textual, Datetime, Address, Document
}sealed class FieldTypeConverter : JsonConverter<FieldType>
{
    public override FieldType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "textual"=>FieldType.Textual,
            "datetime"=>FieldType.Datetime,
            "address"=>FieldType.Address,
            "document"=>FieldType.Document,
            _ =>(FieldType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, FieldType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FieldType.Textual=>"textual",
            FieldType.Datetime=>"datetime",
            FieldType.Address=>"address",
            FieldType.Document=>"document",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the regulatory requirement for this phone number.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Approved, Declined, AwaitingValue, PendingApproval
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approved"=>Status.Approved,
            "declined"=>Status.Declined,
            "awaiting-value"=>Status.AwaitingValue,
            "pending-approval"=>Status.PendingApproval,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Approved=>"approved",
            Status.Declined=>"declined",
            Status.AwaitingValue=>"awaiting-value",
            Status.PendingApproval=>"pending-approval",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the order.
/// </summary>
[JsonConverter(typeof(NumbersSubNumberOrderStatusConverter))]
public enum NumbersSubNumberOrderStatus
{
    Pending, Success, Failure
}sealed class NumbersSubNumberOrderStatusConverter : JsonConverter<NumbersSubNumberOrderStatus>
{
    public override NumbersSubNumberOrderStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>NumbersSubNumberOrderStatus.Pending,
            "success"=>NumbersSubNumberOrderStatus.Success,
            "failure"=>NumbersSubNumberOrderStatus.Failure,
            _ =>(NumbersSubNumberOrderStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NumbersSubNumberOrderStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NumbersSubNumberOrderStatus.Pending=>"pending",
            NumbersSubNumberOrderStatus.Success=>"success",
            NumbersSubNumberOrderStatus.Failure=>"failure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}