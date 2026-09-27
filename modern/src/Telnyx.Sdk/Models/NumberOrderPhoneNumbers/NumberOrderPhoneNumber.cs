using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.NumberOrderPhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<NumberOrderPhoneNumber, NumberOrderPhoneNumberFromRaw>))]
public sealed record class NumberOrderPhoneNumber : JsonModel
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

    public System::DateTimeOffset? Deadline {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "deadline"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("deadline", value);
        }
    }

    public bool? IsBlockNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_block_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_block_number", value);
        }
    }

    public string? Locality {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "locality"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("locality", value);
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

    public IReadOnlyList<SubNumberOrderRegulatoryRequirementWithValue>? RegulatoryRequirements {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SubNumberOrderRegulatoryRequirementWithValue>>(
                "regulatory_requirements"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SubNumberOrderRegulatoryRequirementWithValue>?>(
                "regulatory_requirements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// True if all requirements are met for a phone number, false otherwise.
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
    /// Status of requirements (if applicable)
    /// </summary>
    public ApiEnum<string, RequirementsStatus>? RequirementsStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RequirementsStatus>>(
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

    /// <summary>
    /// The status of the phone number in the order.
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

    public string? SubNumberOrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sub_number_order_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sub_number_order_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BundleID;
        _ = this.CountryCode;
        _ = this.Deadline;
        _ = this.IsBlockNumber;
        _ = this.Locality;
        _ = this.OrderRequestID;
        _ = this.PhoneNumber;
        this.PhoneNumberType?.Validate();
        _ = this.RecordType;
        foreach (var item in this.RegulatoryRequirements ?? [])
        {
            item.Validate();
        }
        _ = this.RequirementsMet;
        this.RequirementsStatus?.Validate();
        this.Status?.Validate();
        _ = this.SubNumberOrderID;
    }

    public NumberOrderPhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderPhoneNumber (
        NumberOrderPhoneNumber numberOrderPhoneNumber
    ) : base(numberOrderPhoneNumber)
    {  }
    #pragma warning restore CS8618

    public NumberOrderPhoneNumber (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderPhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderPhoneNumberFromRaw.FromRawUnchecked"/>
    public static NumberOrderPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberOrderPhoneNumberFromRaw : IFromRawJson<NumberOrderPhoneNumber>
{
    /// <inheritdoc/>
    public NumberOrderPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderPhoneNumber.FromRawUnchecked(rawData);
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
}/// <summary>
/// Status of requirements (if applicable)
/// </summary>
[JsonConverter(typeof(RequirementsStatusConverter))]
public enum RequirementsStatus
{
    Pending,
    Approved,
    Cancelled,
    Deleted,
    RequirementInfoException,
    RequirementInfoPending,
    RequirementInfoUnderReview
}sealed class RequirementsStatusConverter : JsonConverter<RequirementsStatus>
{
    public override RequirementsStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>RequirementsStatus.Pending,
            "approved"=>RequirementsStatus.Approved,
            "cancelled"=>RequirementsStatus.Cancelled,
            "deleted"=>RequirementsStatus.Deleted,
            "requirement-info-exception"=>RequirementsStatus.RequirementInfoException,
            "requirement-info-pending"=>RequirementsStatus.RequirementInfoPending,
            "requirement-info-under-review"=>RequirementsStatus.RequirementInfoUnderReview,
            _ =>(RequirementsStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RequirementsStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RequirementsStatus.Pending=>"pending",
            RequirementsStatus.Approved=>"approved",
            RequirementsStatus.Cancelled=>"cancelled",
            RequirementsStatus.Deleted=>"deleted",
            RequirementsStatus.RequirementInfoException=>"requirement-info-exception",
            RequirementsStatus.RequirementInfoPending=>"requirement-info-pending",
            RequirementsStatus.RequirementInfoUnderReview=>"requirement-info-under-review",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the phone number in the order.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Success, Failure
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
            "pending"=>Status.Pending,
            "success"=>Status.Success,
            "failure"=>Status.Failure,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"pending",
            Status.Success=>"success",
            Status.Failure=>"failure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}