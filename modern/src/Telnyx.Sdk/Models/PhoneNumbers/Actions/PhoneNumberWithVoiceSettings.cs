using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PhoneNumbers.Voice;

namespace Telnyx.Sdk.Models.PhoneNumbers.Actions;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberWithVoiceSettings, PhoneNumberWithVoiceSettingsFromRaw>))]
public sealed record class PhoneNumberWithVoiceSettings : JsonModel
{
    /// <summary>
    /// Identifies the type of resource.
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
    /// The call forwarding settings for a phone number.
    /// </summary>
    public CallForwarding? CallForwarding {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallForwarding>(
                "call_forwarding"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_forwarding", value);
        }
    }

    /// <summary>
    /// The call recording settings for a phone number.
    /// </summary>
    public CallRecording? CallRecording {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallRecording>(
                "call_recording"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_recording", value);
        }
    }

    /// <summary>
    /// The CNAM listing settings for a phone number.
    /// </summary>
    public CnamListing? CnamListing {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CnamListing>(
                "cnam_listing"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cnam_listing", value);
        }
    }

    /// <summary>
    /// Identifies the connection associated with this phone number.
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
    /// The emergency services settings for a phone number.
    /// </summary>
    public Emergency? Emergency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Emergency>(
                "emergency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("emergency", value);
        }
    }

    /// <summary>
    /// The inbound_call_screening setting is a phone number configuration option
    /// variable that allows users to configure their settings to block or flag fraudulent
    /// calls. It can be set to disabled, reject_calls, or flag_calls. This feature
    /// has an additional per-number monthly cost associated with it.
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.PhoneNumbers.Actions.InboundCallScreening>? InboundCallScreening {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.PhoneNumbers.Actions.InboundCallScreening>>(
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
    /// The media features settings for a phone number.
    /// </summary>
    public MediaFeatures? MediaFeatures {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MediaFeatures>(
                "media_features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("media_features", value);
        }
    }

    /// <summary>
    /// The phone number in +E164 format.
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
    /// Controls whether a tech prefix is enabled for this phone number.
    /// </summary>
    public bool? TechPrefixEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "tech_prefix_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tech_prefix_enabled", value);
        }
    }

    /// <summary>
    /// This field allows you to rewrite the destination number of an inbound call
    /// before the call is routed to you. The value of this field may be any alphanumeric
    /// value, and the value will replace the number originally dialed.
    /// </summary>
    public string? TranslatedNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "translated_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("translated_number", value);
        }
    }

    /// <summary>
    /// Controls whether a number is billed per minute or uses your concurrent channels.
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.PhoneNumbers.Actions.UsagePaymentMethod>? UsagePaymentMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.PhoneNumbers.Actions.UsagePaymentMethod>>(
                "usage_payment_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("usage_payment_method", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.CallForwarding?.Validate();
        this.CallRecording?.Validate();
        this.CnamListing?.Validate();
        _ = this.ConnectionID;
        _ = this.CustomerReference;
        this.Emergency?.Validate();
        this.InboundCallScreening?.Validate();
        this.MediaFeatures?.Validate();
        _ = this.PhoneNumber;
        _ = this.RecordType;
        _ = this.TechPrefixEnabled;
        _ = this.TranslatedNumber;
        this.UsagePaymentMethod?.Validate();
    }

    public PhoneNumberWithVoiceSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberWithVoiceSettings (
        PhoneNumberWithVoiceSettings phoneNumberWithVoiceSettings
    ) : base(phoneNumberWithVoiceSettings)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberWithVoiceSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberWithVoiceSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberWithVoiceSettingsFromRaw.FromRawUnchecked"/>
    public static PhoneNumberWithVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberWithVoiceSettingsFromRaw : IFromRawJson<PhoneNumberWithVoiceSettings>
{
    /// <inheritdoc/>
    public PhoneNumberWithVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberWithVoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// The emergency services settings for a phone number.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Emergency, EmergencyFromRaw>))]
public sealed record class Emergency : JsonModel
{
    /// <summary>
    /// Identifies the address to be used with emergency services.
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
    /// Allows you to enable or disable emergency services on the phone number. In
    /// order to enable emergency services, you must also set an emergency_address_id.
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
    /// Represents the state of the number regarding emergency activation.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EmergencyAddressID;
        _ = this.EmergencyEnabled;
        this.EmergencyStatus?.Validate();
    }

    public Emergency ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Emergency (Emergency emergency) : base(emergency)
    {  }
    #pragma warning restore CS8618

    public Emergency (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Emergency (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmergencyFromRaw.FromRawUnchecked"/>
    public static Emergency FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EmergencyFromRaw : IFromRawJson<Emergency>
{
    /// <inheritdoc/>
    public Emergency FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Emergency.FromRawUnchecked(rawData);
}/// <summary>
/// Represents the state of the number regarding emergency activation.
/// </summary>
[JsonConverter(typeof(EmergencyStatusConverter))]
public enum EmergencyStatus
{
    Disabled, Active, Provisioning, Deprovisioning, ProvisioningFailed
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
            "disabled"=>EmergencyStatus.Disabled,
            "active"=>EmergencyStatus.Active,
            "provisioning"=>EmergencyStatus.Provisioning,
            "deprovisioning"=>EmergencyStatus.Deprovisioning,
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
            EmergencyStatus.Disabled=>"disabled",
            EmergencyStatus.Active=>"active",
            EmergencyStatus.Provisioning=>"provisioning",
            EmergencyStatus.Deprovisioning=>"deprovisioning",
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
[JsonConverter(typeof(global::Telnyx.Sdk.Models.PhoneNumbers.Actions.InboundCallScreeningConverter))]
public enum InboundCallScreening
{
    Disabled, RejectCalls, FlagCalls
}sealed class InboundCallScreeningConverter : JsonConverter<global::Telnyx.Sdk.Models.PhoneNumbers.Actions.InboundCallScreening>
{
    public override global::Telnyx.Sdk.Models.PhoneNumbers.Actions.InboundCallScreening Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>global::Telnyx.Sdk.Models.PhoneNumbers.Actions.InboundCallScreening.Disabled,
            "reject_calls"=>global::Telnyx.Sdk.Models.PhoneNumbers.Actions.InboundCallScreening.RejectCalls,
            "flag_calls"=>global::Telnyx.Sdk.Models.PhoneNumbers.Actions.InboundCallScreening.FlagCalls,
            _ =>(global::Telnyx.Sdk.Models.PhoneNumbers.Actions.InboundCallScreening)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.PhoneNumbers.Actions.InboundCallScreening value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.PhoneNumbers.Actions.InboundCallScreening.Disabled=>"disabled",
            global::Telnyx.Sdk.Models.PhoneNumbers.Actions.InboundCallScreening.RejectCalls=>"reject_calls",
            global::Telnyx.Sdk.Models.PhoneNumbers.Actions.InboundCallScreening.FlagCalls=>"flag_calls",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Controls whether a number is billed per minute or uses your concurrent channels.
/// </summary>
[JsonConverter(typeof(global::Telnyx.Sdk.Models.PhoneNumbers.Actions.UsagePaymentMethodConverter))]
public enum UsagePaymentMethod
{
    PayPerMinute, Channel
}sealed class UsagePaymentMethodConverter : JsonConverter<global::Telnyx.Sdk.Models.PhoneNumbers.Actions.UsagePaymentMethod>
{
    public override global::Telnyx.Sdk.Models.PhoneNumbers.Actions.UsagePaymentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pay-per-minute"=>global::Telnyx.Sdk.Models.PhoneNumbers.Actions.UsagePaymentMethod.PayPerMinute,
            "channel"=>global::Telnyx.Sdk.Models.PhoneNumbers.Actions.UsagePaymentMethod.Channel,
            _ =>(global::Telnyx.Sdk.Models.PhoneNumbers.Actions.UsagePaymentMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.PhoneNumbers.Actions.UsagePaymentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.PhoneNumbers.Actions.UsagePaymentMethod.PayPerMinute=>"pay-per-minute",
            global::Telnyx.Sdk.Models.PhoneNumbers.Actions.UsagePaymentMethod.Channel=>"channel",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}