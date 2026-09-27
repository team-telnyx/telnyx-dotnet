using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberSlimListResponse, PhoneNumberSlimListResponseFromRaw>))]
public sealed record class PhoneNumberSlimListResponse : JsonModel
{
    /// <summary>
    /// Identifies the resource.
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
    /// ISO 8601 formatted date indicating when the phone number was first activated
    /// (transitioned from purchase-pending or port-pending to active). Will be null
    /// for numbers that have not yet been activated, or for legacy numbers activated
    /// before this field was tracked.
    /// </summary>
    public System::DateTimeOffset? ActivatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "activated_at"
            );
        }
        init { this._rawData.Set("activated_at", value); }
    }

    /// <summary>
    /// Identifies the billing group associated with the phone number.
    /// </summary>
    public string? BillingGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billing_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billing_group_id", value);
        }
    }

    /// <summary>
    /// Indicates if call forwarding will be enabled for this number if forwards_to
    /// and forwarding_type are filled in. Defaults to true for backwards compatibility
    /// with APIV1 use of numbers endpoints.
    /// </summary>
    public bool? CallForwardingEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "call_forwarding_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_forwarding_enabled", value);
        }
    }

    /// <summary>
    /// Indicates whether call recording is enabled for this number.
    /// </summary>
    public bool? CallRecordingEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "call_recording_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_recording_enabled", value);
        }
    }

    /// <summary>
    /// Indicates whether caller ID is enabled for this number.
    /// </summary>
    public bool? CallerIDNameEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "caller_id_name_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("caller_id_name_enabled", value);
        }
    }

    /// <summary>
    /// Indicates whether a CNAM listing is enabled for this number.
    /// </summary>
    public bool? CnamListingEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "cnam_listing_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cnam_listing_enabled", value);
        }
    }

    /// <summary>
    /// Identifies the connection associated with the phone number.
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// The ISO 3166-1 alpha-2 country code of the phone number.
    /// </summary>
    public string? CountryIsoAlpha2 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_iso_alpha2"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_iso_alpha2", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Identifies the emergency address associated with the phone number.
    /// </summary>
    public string? EmergencyAddressID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "emergency_address_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("emergency_address_id", value);
        }
    }

    /// <summary>
    /// Indicates whether emergency services are enabled for this number.
    /// </summary>
    public bool? EmergencyEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "emergency_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("emergency_enabled", value);
        }
    }

    /// <summary>
    /// Indicates the status of the provisioning of emergency services for the phone
    /// number. This field contains information about activity that may be ongoing
    /// for a number where it either is being provisioned or deprovisioned but is
    /// not yet enabled/disabled.
    /// </summary>
    public ApiEnum<string, PhoneNumberSlimListResponseEmergencyStatus>? EmergencyStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberSlimListResponseEmergencyStatus>>(
                "emergency_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("emergency_status", value);
        }
    }

    /// <summary>
    /// If someone attempts to port your phone number away from Telnyx and your phone
    /// number has an external PIN set, Telnyx will attempt to verify that you provided
    /// the correct external PIN to the winning carrier. Note that not all carriers
    /// cooperate with this security mechanism.
    /// </summary>
    public string? ExternalPin {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "external_pin"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("external_pin", value);
        }
    }

    /// <summary>
    /// Indicates whether HD voice is enabled for this number.
    /// </summary>
    public bool? HDVoiceEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "hd_voice_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("hd_voice_enabled", value);
        }
    }

    /// <summary>
    /// The inbound_call_screening setting is a phone number configuration option
    /// variable that allows users to configure their settings to block or flag fraudulent
    /// calls. It can be set to disabled, reject_calls, or flag_calls. This feature
    /// has an additional per-number monthly cost associated with it.
    /// </summary>
    public ApiEnum<string, PhoneNumberSlimListResponseInboundCallScreening>? InboundCallScreening {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberSlimListResponseInboundCallScreening>>(
                "inbound_call_screening"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound_call_screening", value);
        }
    }

    /// <summary>
    /// The +E.164-formatted phone number associated with this record.
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
    /// The phone number's type. Note: For numbers purchased prior to July 2023 or
    /// when fetching a number's details immediately after a purchase completes, the
    /// legacy values `tollfree`, `shortcode` or `longcode` may be returned instead.
    /// </summary>
    public ApiEnum<string, PhoneNumberSlimListResponsePhoneNumberType>? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberSlimListResponsePhoneNumberType>>(
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
    /// ISO 8601 formatted date indicating when the resource was purchased.
    /// </summary>
    public string? PurchasedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "purchased_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("purchased_at", value);
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
    /// The phone number's current status.
    /// </summary>
    public ApiEnum<string, PhoneNumberSlimListResponseStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberSlimListResponseStatus>>(
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
    /// Indicates whether T38 Fax Gateway for inbound calls to this number.
    /// </summary>
    public bool? T38FaxGatewayEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "t38_fax_gateway_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("t38_fax_gateway_enabled", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.ActivatedAt;
        _ = this.BillingGroupID;
        _ = this.CallForwardingEnabled;
        _ = this.CallRecordingEnabled;
        _ = this.CallerIDNameEnabled;
        _ = this.CnamListingEnabled;
        _ = this.ConnectionID;
        _ = this.CountryIsoAlpha2;
        _ = this.CreatedAt;
        _ = this.CustomerReference;
        _ = this.EmergencyAddressID;
        _ = this.EmergencyEnabled;
        this.EmergencyStatus?.Validate();
        _ = this.ExternalPin;
        _ = this.HDVoiceEnabled;
        this.InboundCallScreening?.Validate();
        _ = this.PhoneNumber;
        this.PhoneNumberType?.Validate();
        _ = this.PurchasedAt;
        _ = this.RecordType;
        this.Status?.Validate();
        _ = this.T38FaxGatewayEnabled;
        _ = this.UpdatedAt;
    }

    public PhoneNumberSlimListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberSlimListResponse (
        PhoneNumberSlimListResponse phoneNumberSlimListResponse
    ) : base(phoneNumberSlimListResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberSlimListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberSlimListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberSlimListResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberSlimListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberSlimListResponseFromRaw : IFromRawJson<PhoneNumberSlimListResponse>
{
    /// <inheritdoc/>
    public PhoneNumberSlimListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberSlimListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates the status of the provisioning of emergency services for the phone
/// number. This field contains information about activity that may be ongoing for
/// a number where it either is being provisioned or deprovisioned but is not yet enabled/disabled.
/// </summary>
[JsonConverter(typeof(PhoneNumberSlimListResponseEmergencyStatusConverter))]
public enum PhoneNumberSlimListResponseEmergencyStatus
{
    Active, Deprovisioning, Disabled, Provisioning, ProvisioningFailed
}sealed class PhoneNumberSlimListResponseEmergencyStatusConverter : JsonConverter<PhoneNumberSlimListResponseEmergencyStatus>
{
    public override PhoneNumberSlimListResponseEmergencyStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active"=>PhoneNumberSlimListResponseEmergencyStatus.Active,
            "deprovisioning"=>PhoneNumberSlimListResponseEmergencyStatus.Deprovisioning,
            "disabled"=>PhoneNumberSlimListResponseEmergencyStatus.Disabled,
            "provisioning"=>PhoneNumberSlimListResponseEmergencyStatus.Provisioning,
            "provisioning-failed"=>PhoneNumberSlimListResponseEmergencyStatus.ProvisioningFailed,
            _ =>(PhoneNumberSlimListResponseEmergencyStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberSlimListResponseEmergencyStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberSlimListResponseEmergencyStatus.Active=>"active",
            PhoneNumberSlimListResponseEmergencyStatus.Deprovisioning=>"deprovisioning",
            PhoneNumberSlimListResponseEmergencyStatus.Disabled=>"disabled",
            PhoneNumberSlimListResponseEmergencyStatus.Provisioning=>"provisioning",
            PhoneNumberSlimListResponseEmergencyStatus.ProvisioningFailed=>"provisioning-failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The inbound_call_screening setting is a phone number configuration option variable
/// that allows users to configure their settings to block or flag fraudulent calls.
/// It can be set to disabled, reject_calls, or flag_calls. This feature has an additional
/// per-number monthly cost associated with it.
/// </summary>
[JsonConverter(typeof(PhoneNumberSlimListResponseInboundCallScreeningConverter))]
public enum PhoneNumberSlimListResponseInboundCallScreening
{
    Disabled, RejectCalls, FlagCalls
}sealed class PhoneNumberSlimListResponseInboundCallScreeningConverter : JsonConverter<PhoneNumberSlimListResponseInboundCallScreening>
{
    public override PhoneNumberSlimListResponseInboundCallScreening Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>PhoneNumberSlimListResponseInboundCallScreening.Disabled,
            "reject_calls"=>PhoneNumberSlimListResponseInboundCallScreening.RejectCalls,
            "flag_calls"=>PhoneNumberSlimListResponseInboundCallScreening.FlagCalls,
            _ =>(PhoneNumberSlimListResponseInboundCallScreening)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberSlimListResponseInboundCallScreening value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberSlimListResponseInboundCallScreening.Disabled=>"disabled",
            PhoneNumberSlimListResponseInboundCallScreening.RejectCalls=>"reject_calls",
            PhoneNumberSlimListResponseInboundCallScreening.FlagCalls=>"flag_calls",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The phone number's type. Note: For numbers purchased prior to July 2023 or when
/// fetching a number's details immediately after a purchase completes, the legacy
/// values `tollfree`, `shortcode` or `longcode` may be returned instead.
/// </summary>
[JsonConverter(typeof(PhoneNumberSlimListResponsePhoneNumberTypeConverter))]
public enum PhoneNumberSlimListResponsePhoneNumberType
{
    Local,
    TollFree,
    Mobile,
    National,
    SharedCost,
    Landline,
    Tollfree,
    Shortcode,
    Longcode
}sealed class PhoneNumberSlimListResponsePhoneNumberTypeConverter : JsonConverter<PhoneNumberSlimListResponsePhoneNumberType>
{
    public override PhoneNumberSlimListResponsePhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>PhoneNumberSlimListResponsePhoneNumberType.Local,
            "toll_free"=>PhoneNumberSlimListResponsePhoneNumberType.TollFree,
            "mobile"=>PhoneNumberSlimListResponsePhoneNumberType.Mobile,
            "national"=>PhoneNumberSlimListResponsePhoneNumberType.National,
            "shared_cost"=>PhoneNumberSlimListResponsePhoneNumberType.SharedCost,
            "landline"=>PhoneNumberSlimListResponsePhoneNumberType.Landline,
            "tollfree"=>PhoneNumberSlimListResponsePhoneNumberType.Tollfree,
            "shortcode"=>PhoneNumberSlimListResponsePhoneNumberType.Shortcode,
            "longcode"=>PhoneNumberSlimListResponsePhoneNumberType.Longcode,
            _ =>(PhoneNumberSlimListResponsePhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberSlimListResponsePhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberSlimListResponsePhoneNumberType.Local=>"local",
            PhoneNumberSlimListResponsePhoneNumberType.TollFree=>"toll_free",
            PhoneNumberSlimListResponsePhoneNumberType.Mobile=>"mobile",
            PhoneNumberSlimListResponsePhoneNumberType.National=>"national",
            PhoneNumberSlimListResponsePhoneNumberType.SharedCost=>"shared_cost",
            PhoneNumberSlimListResponsePhoneNumberType.Landline=>"landline",
            PhoneNumberSlimListResponsePhoneNumberType.Tollfree=>"tollfree",
            PhoneNumberSlimListResponsePhoneNumberType.Shortcode=>"shortcode",
            PhoneNumberSlimListResponsePhoneNumberType.Longcode=>"longcode",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The phone number's current status.
/// </summary>
[JsonConverter(typeof(PhoneNumberSlimListResponseStatusConverter))]
public enum PhoneNumberSlimListResponseStatus
{
    PurchasePending,
    PurchaseFailed,
    PortPending,
    PortFailed,
    Active,
    Deleted,
    EmergencyOnly,
    PortedOut,
    PortOutPending,
    RequirementInfoPending,
    RequirementInfoUnderReview,
    RequirementInfoException,
    ProvisionPending
}sealed class PhoneNumberSlimListResponseStatusConverter : JsonConverter<PhoneNumberSlimListResponseStatus>
{
    public override PhoneNumberSlimListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "purchase-pending"=>PhoneNumberSlimListResponseStatus.PurchasePending,
            "purchase-failed"=>PhoneNumberSlimListResponseStatus.PurchaseFailed,
            "port-pending"=>PhoneNumberSlimListResponseStatus.PortPending,
            "port-failed"=>PhoneNumberSlimListResponseStatus.PortFailed,
            "active"=>PhoneNumberSlimListResponseStatus.Active,
            "deleted"=>PhoneNumberSlimListResponseStatus.Deleted,
            "emergency-only"=>PhoneNumberSlimListResponseStatus.EmergencyOnly,
            "ported-out"=>PhoneNumberSlimListResponseStatus.PortedOut,
            "port-out-pending"=>PhoneNumberSlimListResponseStatus.PortOutPending,
            "requirement-info-pending"=>PhoneNumberSlimListResponseStatus.RequirementInfoPending,
            "requirement-info-under-review"=>PhoneNumberSlimListResponseStatus.RequirementInfoUnderReview,
            "requirement-info-exception"=>PhoneNumberSlimListResponseStatus.RequirementInfoException,
            "provision-pending"=>PhoneNumberSlimListResponseStatus.ProvisionPending,
            _ =>(PhoneNumberSlimListResponseStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberSlimListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberSlimListResponseStatus.PurchasePending=>"purchase-pending",
            PhoneNumberSlimListResponseStatus.PurchaseFailed=>"purchase-failed",
            PhoneNumberSlimListResponseStatus.PortPending=>"port-pending",
            PhoneNumberSlimListResponseStatus.PortFailed=>"port-failed",
            PhoneNumberSlimListResponseStatus.Active=>"active",
            PhoneNumberSlimListResponseStatus.Deleted=>"deleted",
            PhoneNumberSlimListResponseStatus.EmergencyOnly=>"emergency-only",
            PhoneNumberSlimListResponseStatus.PortedOut=>"ported-out",
            PhoneNumberSlimListResponseStatus.PortOutPending=>"port-out-pending",
            PhoneNumberSlimListResponseStatus.RequirementInfoPending=>"requirement-info-pending",
            PhoneNumberSlimListResponseStatus.RequirementInfoUnderReview=>"requirement-info-under-review",
            PhoneNumberSlimListResponseStatus.RequirementInfoException=>"requirement-info-exception",
            PhoneNumberSlimListResponseStatus.ProvisionPending=>"provision-pending",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}