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

[JsonConverter(typeof(JsonModelConverter<NumbersPhoneNumberDetailed, NumbersPhoneNumberDetailedFromRaw>))]
public sealed record class NumbersPhoneNumberDetailed : JsonModel
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
    public required ApiEnum<string, PhoneNumberType> PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PhoneNumberType>>(
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
    public required ApiEnum<string, NumbersPhoneNumberDetailedStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NumbersPhoneNumberDetailedStatus>>(
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
    public ApiEnum<string, EmergencyStatus>? EmergencyStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EmergencyStatus>>(
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
    public ApiEnum<string, InboundCallScreening>? InboundCallScreening {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InboundCallScreening>>(
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
    /// Identifies the messaging campaign associated with the phone number's messaging
    /// profile. If the messaging profile details could not be retrieved, this value
    /// is the string `UNAVAILABLE`.
    /// </summary>
    public string? MessagingCampaignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_campaign_id"
            );
        }
        init { this._rawData.Set("messaging_campaign_id", value); }
    }

    /// <summary>
    /// Identifies the messaging profile associated with the phone number. If the
    /// messaging profile details could not be retrieved, this value is the string `UNAVAILABLE`.
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
    /// The name of the messaging profile associated with the phone number. If the
    /// messaging profile details could not be retrieved, this value is the string `UNAVAILABLE`.
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
    public ApiEnum<string, SourceType>? SourceType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SourceType>>(
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
        _ = this.MessagingCampaignID;
        _ = this.MessagingProfileID;
        _ = this.MessagingProfileName;
        this.SourceType?.Validate();
        _ = this.T38FaxGatewayEnabled;
        _ = this.UpdatedAt;
    }

    public NumbersPhoneNumberDetailed ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumbersPhoneNumberDetailed (
        NumbersPhoneNumberDetailed numbersPhoneNumberDetailed
    ) : base(numbersPhoneNumberDetailed)
    {  }
    #pragma warning restore CS8618

    public NumbersPhoneNumberDetailed (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumbersPhoneNumberDetailed (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumbersPhoneNumberDetailedFromRaw.FromRawUnchecked"/>
    public static NumbersPhoneNumberDetailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumbersPhoneNumberDetailedFromRaw : IFromRawJson<NumbersPhoneNumberDetailed>
{
    /// <inheritdoc/>
    public NumbersPhoneNumberDetailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumbersPhoneNumberDetailed.FromRawUnchecked(rawData);
}

/// <summary>
/// The phone number's type. Note: For numbers purchased prior to July 2023 or when
/// fetching a number's details immediately after a purchase completes, the legacy
/// values `tollfree`, `shortcode` or `longcode` may be returned instead.
/// </summary>
[JsonConverter(typeof(PhoneNumberTypeConverter))]
public enum PhoneNumberType
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
            "tollfree"=>PhoneNumberType.Tollfree,
            "shortcode"=>PhoneNumberType.Shortcode,
            "longcode"=>PhoneNumberType.Longcode,
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
            PhoneNumberType.Tollfree=>"tollfree",
            PhoneNumberType.Shortcode=>"shortcode",
            PhoneNumberType.Longcode=>"longcode",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The phone number's current status.
/// </summary>
[JsonConverter(typeof(NumbersPhoneNumberDetailedStatusConverter))]
public enum NumbersPhoneNumberDetailedStatus
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
}sealed class NumbersPhoneNumberDetailedStatusConverter : JsonConverter<NumbersPhoneNumberDetailedStatus>
{
    public override NumbersPhoneNumberDetailedStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "purchase-pending"=>NumbersPhoneNumberDetailedStatus.PurchasePending,
            "purchase-failed"=>NumbersPhoneNumberDetailedStatus.PurchaseFailed,
            "port-pending"=>NumbersPhoneNumberDetailedStatus.PortPending,
            "port-failed"=>NumbersPhoneNumberDetailedStatus.PortFailed,
            "active"=>NumbersPhoneNumberDetailedStatus.Active,
            "deleted"=>NumbersPhoneNumberDetailedStatus.Deleted,
            "emergency-only"=>NumbersPhoneNumberDetailedStatus.EmergencyOnly,
            "ported-out"=>NumbersPhoneNumberDetailedStatus.PortedOut,
            "port-out-pending"=>NumbersPhoneNumberDetailedStatus.PortOutPending,
            "requirement-info-pending"=>NumbersPhoneNumberDetailedStatus.RequirementInfoPending,
            "requirement-info-under-review"=>NumbersPhoneNumberDetailedStatus.RequirementInfoUnderReview,
            "requirement-info-exception"=>NumbersPhoneNumberDetailedStatus.RequirementInfoException,
            "provision-pending"=>NumbersPhoneNumberDetailedStatus.ProvisionPending,
            _ =>(NumbersPhoneNumberDetailedStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NumbersPhoneNumberDetailedStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NumbersPhoneNumberDetailedStatus.PurchasePending=>"purchase-pending",
            NumbersPhoneNumberDetailedStatus.PurchaseFailed=>"purchase-failed",
            NumbersPhoneNumberDetailedStatus.PortPending=>"port-pending",
            NumbersPhoneNumberDetailedStatus.PortFailed=>"port-failed",
            NumbersPhoneNumberDetailedStatus.Active=>"active",
            NumbersPhoneNumberDetailedStatus.Deleted=>"deleted",
            NumbersPhoneNumberDetailedStatus.EmergencyOnly=>"emergency-only",
            NumbersPhoneNumberDetailedStatus.PortedOut=>"ported-out",
            NumbersPhoneNumberDetailedStatus.PortOutPending=>"port-out-pending",
            NumbersPhoneNumberDetailedStatus.RequirementInfoPending=>"requirement-info-pending",
            NumbersPhoneNumberDetailedStatus.RequirementInfoUnderReview=>"requirement-info-under-review",
            NumbersPhoneNumberDetailedStatus.RequirementInfoException=>"requirement-info-exception",
            NumbersPhoneNumberDetailedStatus.ProvisionPending=>"provision-pending",
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
[JsonConverter(typeof(EmergencyStatusConverter))]
public enum EmergencyStatus
{
    Active, Deprovisioning, Disabled, Provisioning, ProvisioningFailed
}sealed class EmergencyStatusConverter : JsonConverter<EmergencyStatus>
{
    public override EmergencyStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active"=>EmergencyStatus.Active,
            "deprovisioning"=>EmergencyStatus.Deprovisioning,
            "disabled"=>EmergencyStatus.Disabled,
            "provisioning"=>EmergencyStatus.Provisioning,
            "provisioning-failed"=>EmergencyStatus.ProvisioningFailed,
            _ =>(EmergencyStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmergencyStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmergencyStatus.Active=>"active",
            EmergencyStatus.Deprovisioning=>"deprovisioning",
            EmergencyStatus.Disabled=>"disabled",
            EmergencyStatus.Provisioning=>"provisioning",
            EmergencyStatus.ProvisioningFailed=>"provisioning-failed",
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
[JsonConverter(typeof(InboundCallScreeningConverter))]
public enum InboundCallScreening
{
    Disabled, RejectCalls, FlagCalls
}sealed class InboundCallScreeningConverter : JsonConverter<InboundCallScreening>
{
    public override InboundCallScreening Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>InboundCallScreening.Disabled,
            "reject_calls"=>InboundCallScreening.RejectCalls,
            "flag_calls"=>InboundCallScreening.FlagCalls,
            _ =>(InboundCallScreening)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundCallScreening value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InboundCallScreening.Disabled=>"disabled",
            InboundCallScreening.RejectCalls=>"reject_calls",
            InboundCallScreening.FlagCalls=>"flag_calls",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Indicates if the phone number was purchased or ported in. For some numbers this
/// information may not be available.
/// </summary>
[JsonConverter(typeof(SourceTypeConverter))]
public enum SourceType
{
    NumberOrder, PortRequest
}sealed class SourceTypeConverter : JsonConverter<SourceType>
{
    public override SourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "number_order"=>SourceType.NumberOrder,
            "port_request"=>SourceType.PortRequest,
            _ =>(SourceType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, SourceType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SourceType.NumberOrder=>"number_order",
            SourceType.PortRequest=>"port_request",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}