using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberDetailed, PhoneNumberDetailedFromRaw>))]
public sealed record class PhoneNumberDetailed : JsonModel
{
    /// <summary>
    /// Identifies the resource.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The ISO 3166-1 alpha-2 country code of the phone number.
    /// </summary>
    public required string CountryIsoAlpha2 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "country_iso_alpha2"
            );
        }
        init { this._rawData.Set("country_iso_alpha2", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Indicates whether deletion lock is enabled for this number. When enabled,
    /// this prevents the phone number from being deleted via the API or Telnyx portal.
    /// </summary>
    public required bool DeletionLockEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "deletion_lock_enabled"
            );
        }
        init { this._rawData.Set("deletion_lock_enabled", value); }
    }

    /// <summary>
    /// If someone attempts to port your phone number away from Telnyx and your phone
    /// number has an external PIN set, Telnyx will attempt to verify that you provided
    /// the correct external PIN to the winning carrier. Note that not all carriers
    /// cooperate with this security mechanism.
    /// </summary>
    public required string? ExternalPin {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "external_pin"
            );
        }
        init { this._rawData.Set("external_pin", value); }
    }

    /// <summary>
    /// The +E.164-formatted phone number associated with this record.
    /// </summary>
    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <summary>
    /// The phone number's type. Note: For numbers purchased prior to July 2023 or
    /// when fetching a number's details immediately after a purchase completes, the
    /// legacy values `tollfree`, `shortcode` or `longcode` may be returned instead.
    /// </summary>
    public required ApiEnum<string, PhoneNumberDetailedPhoneNumberType> PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PhoneNumberDetailedPhoneNumberType>>(
                "phone_number_type"
            );
        }
        init { this._rawData.Set("phone_number_type", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was purchased.
    /// </summary>
    public required string PurchasedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "purchased_at"
            );
        }
        init { this._rawData.Set("purchased_at", value); }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// The phone number's current status.
    /// </summary>
    public required ApiEnum<string, PhoneNumberDetailedStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PhoneNumberDetailedStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A list of user-assigned tags to help manage the phone number.
    /// </summary>
    public required IReadOnlyList<string> Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "tags",
                ImmutableArray.ToImmutableArray(value)
            );
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
        init { this._rawData.Set("billing_group_id", value); }
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
        init { this._rawData.Set("connection_id", value); }
    }

    /// <summary>
    /// The user-assigned name of the connection to be associated with this phone number.
    /// </summary>
    public string? ConnectionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_name"
            );
        }
        init { this._rawData.Set("connection_name", value); }
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
        init { this._rawData.Set("customer_reference", value); }
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
        init { this._rawData.Set("emergency_address_id", value); }
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
    public ApiEnum<string, PhoneNumberDetailedEmergencyStatus>? EmergencyStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberDetailedEmergencyStatus>>(
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
    public ApiEnum<string, PhoneNumberDetailedInboundCallScreening>? InboundCallScreening {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberDetailedInboundCallScreening>>(
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
    /// Identifies the messaging profile associated with the phone number.
    /// </summary>
    public string? MessagingProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_profile_id"
            );
        }
        init { this._rawData.Set("messaging_profile_id", value); }
    }

    /// <summary>
    /// The name of the messaging profile associated with the phone number.
    /// </summary>
    public string? MessagingProfileName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_profile_name"
            );
        }
        init { this._rawData.Set("messaging_profile_name", value); }
    }

    /// <summary>
    /// Indicates if the phone number was purchased or ported in. For some numbers
    /// this information may not be available.
    /// </summary>
    public ApiEnum<string, PhoneNumberDetailedSourceType>? SourceType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberDetailedSourceType>>(
                "source_type"
            );
        }
        init { this._rawData.Set("source_type", value); }
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
        _ = this.CountryIsoAlpha2;
        _ = this.CreatedAt;
        _ = this.DeletionLockEnabled;
        _ = this.ExternalPin;
        _ = this.PhoneNumber;
        this.PhoneNumberType.Validate();
        _ = this.PurchasedAt;
        _ = this.RecordType;
        this.Status.Validate();
        _ = this.Tags;
        _ = this.ActivatedAt;
        _ = this.BillingGroupID;
        _ = this.CallForwardingEnabled;
        _ = this.CallRecordingEnabled;
        _ = this.CallerIDNameEnabled;
        _ = this.CnamListingEnabled;
        _ = this.ConnectionID;
        _ = this.ConnectionName;
        _ = this.CustomerReference;
        _ = this.EmergencyAddressID;
        _ = this.EmergencyEnabled;
        this.EmergencyStatus?.Validate();
        _ = this.HDVoiceEnabled;
        this.InboundCallScreening?.Validate();
        _ = this.MessagingProfileID;
        _ = this.MessagingProfileName;
        this.SourceType?.Validate();
        _ = this.T38FaxGatewayEnabled;
        _ = this.UpdatedAt;
    }

    public PhoneNumberDetailed ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberDetailed (PhoneNumberDetailed phoneNumberDetailed) : base(
        phoneNumberDetailed
    )
    {  }
    #pragma warning restore CS8618

    public PhoneNumberDetailed (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberDetailed (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberDetailedFromRaw.FromRawUnchecked"/>
    public static PhoneNumberDetailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberDetailedFromRaw : IFromRawJson<PhoneNumberDetailed>
{
    /// <inheritdoc/>
    public PhoneNumberDetailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberDetailed.FromRawUnchecked(rawData);
}

/// <summary>
/// The phone number's type. Note: For numbers purchased prior to July 2023 or when
/// fetching a number's details immediately after a purchase completes, the legacy
/// values `tollfree`, `shortcode` or `longcode` may be returned instead.
/// </summary>
[JsonConverter(typeof(PhoneNumberDetailedPhoneNumberTypeConverter))]
public enum PhoneNumberDetailedPhoneNumberType
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
}sealed class PhoneNumberDetailedPhoneNumberTypeConverter : JsonConverter<PhoneNumberDetailedPhoneNumberType>
{
    public override PhoneNumberDetailedPhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>PhoneNumberDetailedPhoneNumberType.Local,
            "toll_free"=>PhoneNumberDetailedPhoneNumberType.TollFree,
            "mobile"=>PhoneNumberDetailedPhoneNumberType.Mobile,
            "national"=>PhoneNumberDetailedPhoneNumberType.National,
            "shared_cost"=>PhoneNumberDetailedPhoneNumberType.SharedCost,
            "landline"=>PhoneNumberDetailedPhoneNumberType.Landline,
            "tollfree"=>PhoneNumberDetailedPhoneNumberType.Tollfree,
            "shortcode"=>PhoneNumberDetailedPhoneNumberType.Shortcode,
            "longcode"=>PhoneNumberDetailedPhoneNumberType.Longcode,
            _ =>(PhoneNumberDetailedPhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberDetailedPhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberDetailedPhoneNumberType.Local=>"local",
            PhoneNumberDetailedPhoneNumberType.TollFree=>"toll_free",
            PhoneNumberDetailedPhoneNumberType.Mobile=>"mobile",
            PhoneNumberDetailedPhoneNumberType.National=>"national",
            PhoneNumberDetailedPhoneNumberType.SharedCost=>"shared_cost",
            PhoneNumberDetailedPhoneNumberType.Landline=>"landline",
            PhoneNumberDetailedPhoneNumberType.Tollfree=>"tollfree",
            PhoneNumberDetailedPhoneNumberType.Shortcode=>"shortcode",
            PhoneNumberDetailedPhoneNumberType.Longcode=>"longcode",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The phone number's current status.
/// </summary>
[JsonConverter(typeof(PhoneNumberDetailedStatusConverter))]
public enum PhoneNumberDetailedStatus
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
}sealed class PhoneNumberDetailedStatusConverter : JsonConverter<PhoneNumberDetailedStatus>
{
    public override PhoneNumberDetailedStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "purchase-pending"=>PhoneNumberDetailedStatus.PurchasePending,
            "purchase-failed"=>PhoneNumberDetailedStatus.PurchaseFailed,
            "port-pending"=>PhoneNumberDetailedStatus.PortPending,
            "port-failed"=>PhoneNumberDetailedStatus.PortFailed,
            "active"=>PhoneNumberDetailedStatus.Active,
            "deleted"=>PhoneNumberDetailedStatus.Deleted,
            "emergency-only"=>PhoneNumberDetailedStatus.EmergencyOnly,
            "ported-out"=>PhoneNumberDetailedStatus.PortedOut,
            "port-out-pending"=>PhoneNumberDetailedStatus.PortOutPending,
            "requirement-info-pending"=>PhoneNumberDetailedStatus.RequirementInfoPending,
            "requirement-info-under-review"=>PhoneNumberDetailedStatus.RequirementInfoUnderReview,
            "requirement-info-exception"=>PhoneNumberDetailedStatus.RequirementInfoException,
            "provision-pending"=>PhoneNumberDetailedStatus.ProvisionPending,
            _ =>(PhoneNumberDetailedStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberDetailedStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberDetailedStatus.PurchasePending=>"purchase-pending",
            PhoneNumberDetailedStatus.PurchaseFailed=>"purchase-failed",
            PhoneNumberDetailedStatus.PortPending=>"port-pending",
            PhoneNumberDetailedStatus.PortFailed=>"port-failed",
            PhoneNumberDetailedStatus.Active=>"active",
            PhoneNumberDetailedStatus.Deleted=>"deleted",
            PhoneNumberDetailedStatus.EmergencyOnly=>"emergency-only",
            PhoneNumberDetailedStatus.PortedOut=>"ported-out",
            PhoneNumberDetailedStatus.PortOutPending=>"port-out-pending",
            PhoneNumberDetailedStatus.RequirementInfoPending=>"requirement-info-pending",
            PhoneNumberDetailedStatus.RequirementInfoUnderReview=>"requirement-info-under-review",
            PhoneNumberDetailedStatus.RequirementInfoException=>"requirement-info-exception",
            PhoneNumberDetailedStatus.ProvisionPending=>"provision-pending",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Indicates the status of the provisioning of emergency services for the phone
/// number. This field contains information about activity that may be ongoing for
/// a number where it either is being provisioned or deprovisioned but is not yet enabled/disabled.
/// </summary>
[JsonConverter(typeof(PhoneNumberDetailedEmergencyStatusConverter))]
public enum PhoneNumberDetailedEmergencyStatus
{
    Active, Deprovisioning, Disabled, Provisioning, ProvisioningFailed
}sealed class PhoneNumberDetailedEmergencyStatusConverter : JsonConverter<PhoneNumberDetailedEmergencyStatus>
{
    public override PhoneNumberDetailedEmergencyStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active"=>PhoneNumberDetailedEmergencyStatus.Active,
            "deprovisioning"=>PhoneNumberDetailedEmergencyStatus.Deprovisioning,
            "disabled"=>PhoneNumberDetailedEmergencyStatus.Disabled,
            "provisioning"=>PhoneNumberDetailedEmergencyStatus.Provisioning,
            "provisioning-failed"=>PhoneNumberDetailedEmergencyStatus.ProvisioningFailed,
            _ =>(PhoneNumberDetailedEmergencyStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberDetailedEmergencyStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberDetailedEmergencyStatus.Active=>"active",
            PhoneNumberDetailedEmergencyStatus.Deprovisioning=>"deprovisioning",
            PhoneNumberDetailedEmergencyStatus.Disabled=>"disabled",
            PhoneNumberDetailedEmergencyStatus.Provisioning=>"provisioning",
            PhoneNumberDetailedEmergencyStatus.ProvisioningFailed=>"provisioning-failed",
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
[JsonConverter(typeof(PhoneNumberDetailedInboundCallScreeningConverter))]
public enum PhoneNumberDetailedInboundCallScreening
{
    Disabled, RejectCalls, FlagCalls
}sealed class PhoneNumberDetailedInboundCallScreeningConverter : JsonConverter<PhoneNumberDetailedInboundCallScreening>
{
    public override PhoneNumberDetailedInboundCallScreening Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>PhoneNumberDetailedInboundCallScreening.Disabled,
            "reject_calls"=>PhoneNumberDetailedInboundCallScreening.RejectCalls,
            "flag_calls"=>PhoneNumberDetailedInboundCallScreening.FlagCalls,
            _ =>(PhoneNumberDetailedInboundCallScreening)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberDetailedInboundCallScreening value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberDetailedInboundCallScreening.Disabled=>"disabled",
            PhoneNumberDetailedInboundCallScreening.RejectCalls=>"reject_calls",
            PhoneNumberDetailedInboundCallScreening.FlagCalls=>"flag_calls",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Indicates if the phone number was purchased or ported in. For some numbers this
/// information may not be available.
/// </summary>
[JsonConverter(typeof(PhoneNumberDetailedSourceTypeConverter))]
public enum PhoneNumberDetailedSourceType
{
    NumberOrder, PortRequest
}sealed class PhoneNumberDetailedSourceTypeConverter : JsonConverter<PhoneNumberDetailedSourceType>
{
    public override PhoneNumberDetailedSourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "number_order"=>PhoneNumberDetailedSourceType.NumberOrder,
            "port_request"=>PhoneNumberDetailedSourceType.PortRequest,
            _ =>(PhoneNumberDetailedSourceType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberDetailedSourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberDetailedSourceType.NumberOrder=>"number_order",
            PhoneNumberDetailedSourceType.PortRequest=>"port_request",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}