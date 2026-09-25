using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingPhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PortingPhoneNumber, PortingPhoneNumberFromRaw>))]
public sealed record class PortingPhoneNumber : JsonModel
{
    /// <summary>
    /// Activation status
    /// </summary>
    public ApiEnum<string, PortingOrderActivationStatus>? ActivationStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingOrderActivationStatus>>(
                "activation_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("activation_status", value);
        }
    }

    /// <summary>
    /// E164 formatted phone number
    /// </summary>
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
    /// The type of the phone number
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
    /// Specifies whether Telnyx is able to confirm portability this number in the
    /// United States &amp; Canada. International phone numbers are provisional by default.
    /// </summary>
    public ApiEnum<string, PortabilityStatus>? PortabilityStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortabilityStatus>>(
                "portability_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("portability_status", value);
        }
    }

    /// <summary>
    /// Identifies the associated port request
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
    /// The current status of the porting order
    /// </summary>
    public ApiEnum<string, PortingPhoneNumberPortingOrderStatus>? PortingOrderStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingPhoneNumberPortingOrderStatus>>(
                "porting_order_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("porting_order_status", value);
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
    /// The current status of the requirements in a INTL porting order
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
    /// A key to reference this porting order when contacting Telnyx customer support
    /// </summary>
    public string? SupportKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "support_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("support_key", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ActivationStatus?.Validate();
        _ = this.PhoneNumber;
        this.PhoneNumberType?.Validate();
        this.PortabilityStatus?.Validate();
        _ = this.PortingOrderID;
        this.PortingOrderStatus?.Validate();
        _ = this.RecordType;
        this.RequirementsStatus?.Validate();
        _ = this.SupportKey;
    }

    public PortingPhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingPhoneNumber (PortingPhoneNumber portingPhoneNumber) : base(
        portingPhoneNumber
    )
    {  }
    #pragma warning restore CS8618

    public PortingPhoneNumber (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingPhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingPhoneNumberFromRaw.FromRawUnchecked"/>
    public static PortingPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingPhoneNumberFromRaw : IFromRawJson<PortingPhoneNumber>
{
    /// <inheritdoc/>
    public PortingPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingPhoneNumber.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the phone number
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
}/// <summary>
/// Specifies whether Telnyx is able to confirm portability this number in the United
/// States &amp; Canada. International phone numbers are provisional by default.
/// </summary>
[JsonConverter(typeof(PortabilityStatusConverter))]
public enum PortabilityStatus
{
    Pending, Confirmed, Provisional
}sealed class PortabilityStatusConverter : JsonConverter<PortabilityStatus>
{
    public override PortabilityStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>PortabilityStatus.Pending,
            "confirmed"=>PortabilityStatus.Confirmed,
            "provisional"=>PortabilityStatus.Provisional,
            _ =>(PortabilityStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortabilityStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortabilityStatus.Pending=>"pending",
            PortabilityStatus.Confirmed=>"confirmed",
            PortabilityStatus.Provisional=>"provisional",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The current status of the porting order
/// </summary>
[JsonConverter(typeof(PortingPhoneNumberPortingOrderStatusConverter))]
public enum PortingPhoneNumberPortingOrderStatus
{
    Draft,
    InProcess,
    Submitted,
    Exception,
    FocDateConfirmed,
    CancelPending,
    Ported,
    Cancelled
}sealed class PortingPhoneNumberPortingOrderStatusConverter : JsonConverter<PortingPhoneNumberPortingOrderStatus>
{
    public override PortingPhoneNumberPortingOrderStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft"=>PortingPhoneNumberPortingOrderStatus.Draft,
            "in-process"=>PortingPhoneNumberPortingOrderStatus.InProcess,
            "submitted"=>PortingPhoneNumberPortingOrderStatus.Submitted,
            "exception"=>PortingPhoneNumberPortingOrderStatus.Exception,
            "foc-date-confirmed"=>PortingPhoneNumberPortingOrderStatus.FocDateConfirmed,
            "cancel-pending"=>PortingPhoneNumberPortingOrderStatus.CancelPending,
            "ported"=>PortingPhoneNumberPortingOrderStatus.Ported,
            "cancelled"=>PortingPhoneNumberPortingOrderStatus.Cancelled,
            _ =>(PortingPhoneNumberPortingOrderStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingPhoneNumberPortingOrderStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingPhoneNumberPortingOrderStatus.Draft=>"draft",
            PortingPhoneNumberPortingOrderStatus.InProcess=>"in-process",
            PortingPhoneNumberPortingOrderStatus.Submitted=>"submitted",
            PortingPhoneNumberPortingOrderStatus.Exception=>"exception",
            PortingPhoneNumberPortingOrderStatus.FocDateConfirmed=>"foc-date-confirmed",
            PortingPhoneNumberPortingOrderStatus.CancelPending=>"cancel-pending",
            PortingPhoneNumberPortingOrderStatus.Ported=>"ported",
            PortingPhoneNumberPortingOrderStatus.Cancelled=>"cancelled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The current status of the requirements in a INTL porting order
/// </summary>
[JsonConverter(typeof(RequirementsStatusConverter))]
public enum RequirementsStatus
{
    RequirementInfoPending,
    RequirementInfoUnderReview,
    RequirementInfoException,
    Approved
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
            "requirement-info-pending"=>RequirementsStatus.RequirementInfoPending,
            "requirement-info-under-review"=>RequirementsStatus.RequirementInfoUnderReview,
            "requirement-info-exception"=>RequirementsStatus.RequirementInfoException,
            "approved"=>RequirementsStatus.Approved,
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
            RequirementsStatus.RequirementInfoPending=>"requirement-info-pending",
            RequirementsStatus.RequirementInfoUnderReview=>"requirement-info-under-review",
            RequirementsStatus.RequirementInfoException=>"requirement-info-exception",
            RequirementsStatus.Approved=>"approved",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}