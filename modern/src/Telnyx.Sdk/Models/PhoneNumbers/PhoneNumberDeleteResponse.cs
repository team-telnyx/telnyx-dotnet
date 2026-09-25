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

[JsonConverter(typeof(JsonModelConverter<PhoneNumberDeleteResponse, PhoneNumberDeleteResponseFromRaw>))]
public sealed record class PhoneNumberDeleteResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public PhoneNumberDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberDeleteResponse (
        PhoneNumberDeleteResponse phoneNumberDeleteResponse
    ) : base(phoneNumberDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberDeleteResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberDeleteResponseFromRaw : IFromRawJson<PhoneNumberDeleteResponse>
{
    /// <inheritdoc/>
    public PhoneNumberDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberDeleteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    /// The user-assigned name of the connection to be associated with this phone number.
    /// </summary>
    public string? ConnectionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_name", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the time it took to activate after
    /// the purchase.
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
    /// Indicates whether deletion lock is enabled for this number. When enabled,
    /// this prevents the phone number from being deleted via the API or Telnyx portal.
    /// </summary>
    public bool? DeletionLockEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "deletion_lock_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("deletion_lock_enabled", value);
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
    /// Identifies the messaging profile associated with the phone number.
    /// </summary>
    public string? MessagingProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_profile_id", value);
        }
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
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_profile_name", value);
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
    /// The phone number's type.
    /// </summary>
    public ApiEnum<string, DataPhoneNumberType>? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataPhoneNumberType>>(
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
    /// ISO 8601 formatted date indicating the time the request was made to purchase
    /// the number.
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
    public ApiEnum<string, DataStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataStatus>>(
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
    /// A list of user-assigned tags to help manage the phone number.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        _ = this.ConnectionName;
        _ = this.CreatedAt;
        _ = this.CustomerReference;
        _ = this.DeletionLockEnabled;
        _ = this.EmergencyAddressID;
        _ = this.EmergencyEnabled;
        _ = this.ExternalPin;
        _ = this.HDVoiceEnabled;
        _ = this.MessagingProfileID;
        _ = this.MessagingProfileName;
        _ = this.PhoneNumber;
        this.PhoneNumberType?.Validate();
        _ = this.PurchasedAt;
        _ = this.RecordType;
        this.Status?.Validate();
        _ = this.T38FaxGatewayEnabled;
        _ = this.Tags;
        _ = this.UpdatedAt;
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
}/// <summary>
/// The phone number's type.
/// </summary>
[JsonConverter(typeof(DataPhoneNumberTypeConverter))]
public enum DataPhoneNumberType
{
    Local, TollFree, Mobile, National, SharedCost, Landline
}sealed class DataPhoneNumberTypeConverter : JsonConverter<DataPhoneNumberType>
{
    public override DataPhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>DataPhoneNumberType.Local,
            "toll_free"=>DataPhoneNumberType.TollFree,
            "mobile"=>DataPhoneNumberType.Mobile,
            "national"=>DataPhoneNumberType.National,
            "shared_cost"=>DataPhoneNumberType.SharedCost,
            "landline"=>DataPhoneNumberType.Landline,
            _ =>(DataPhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataPhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataPhoneNumberType.Local=>"local",
            DataPhoneNumberType.TollFree=>"toll_free",
            DataPhoneNumberType.Mobile=>"mobile",
            DataPhoneNumberType.National=>"national",
            DataPhoneNumberType.SharedCost=>"shared_cost",
            DataPhoneNumberType.Landline=>"landline",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The phone number's current status.
/// </summary>
[JsonConverter(typeof(DataStatusConverter))]
public enum DataStatus
{
    PurchasePending,
    PurchaseFailed,
    PortPending,
    PortFailed,
    Active,
    Deleted,
    EmergencyOnly,
    PortedOut,
    PortOutPending
}sealed class DataStatusConverter : JsonConverter<DataStatus>
{
    public override DataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "purchase-pending"=>DataStatus.PurchasePending,
            "purchase-failed"=>DataStatus.PurchaseFailed,
            "port-pending"=>DataStatus.PortPending,
            "port-failed"=>DataStatus.PortFailed,
            "active"=>DataStatus.Active,
            "deleted"=>DataStatus.Deleted,
            "emergency-only"=>DataStatus.EmergencyOnly,
            "ported-out"=>DataStatus.PortedOut,
            "port-out-pending"=>DataStatus.PortOutPending,
            _ =>(DataStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, DataStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataStatus.PurchasePending=>"purchase-pending",
            DataStatus.PurchaseFailed=>"purchase-failed",
            DataStatus.PortPending=>"port-pending",
            DataStatus.PortFailed=>"port-failed",
            DataStatus.Active=>"active",
            DataStatus.Deleted=>"deleted",
            DataStatus.EmergencyOnly=>"emergency-only",
            DataStatus.PortedOut=>"ported-out",
            DataStatus.PortOutPending=>"port-out-pending",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}