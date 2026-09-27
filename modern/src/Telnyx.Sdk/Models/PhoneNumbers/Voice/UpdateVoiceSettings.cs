using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voice;

[JsonConverter(typeof(JsonModelConverter<UpdateVoiceSettings, UpdateVoiceSettingsFromRaw>))]
public sealed record class UpdateVoiceSettings : JsonModel
{
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
    /// Controls whether the caller ID name is enabled for this phone number.
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
    /// The inbound_call_screening setting is a phone number configuration option
    /// variable that allows users to configure their settings to block or flag fraudulent
    /// calls. It can be set to disabled, reject_calls, or flag_calls. This feature
    /// has an additional per-number monthly cost associated with it.
    /// </summary>
    public ApiEnum<string, UpdateVoiceSettingsInboundCallScreening>? InboundCallScreening {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UpdateVoiceSettingsInboundCallScreening>>(
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
    public ApiEnum<string, UpdateVoiceSettingsUsagePaymentMethod>? UsagePaymentMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UpdateVoiceSettingsUsagePaymentMethod>>(
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
        this.CallForwarding?.Validate();
        this.CallRecording?.Validate();
        _ = this.CallerIDNameEnabled;
        this.CnamListing?.Validate();
        this.InboundCallScreening?.Validate();
        this.MediaFeatures?.Validate();
        _ = this.TechPrefixEnabled;
        _ = this.TranslatedNumber;
        this.UsagePaymentMethod?.Validate();
    }

    public UpdateVoiceSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateVoiceSettings (UpdateVoiceSettings updateVoiceSettings) : base(
        updateVoiceSettings
    )
    {  }
    #pragma warning restore CS8618

    public UpdateVoiceSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateVoiceSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UpdateVoiceSettingsFromRaw.FromRawUnchecked"/>
    public static UpdateVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UpdateVoiceSettingsFromRaw : IFromRawJson<UpdateVoiceSettings>
{
    /// <inheritdoc/>
    public UpdateVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UpdateVoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// The inbound_call_screening setting is a phone number configuration option variable
/// that allows users to configure their settings to block or flag fraudulent calls.
/// It can be set to disabled, reject_calls, or flag_calls. This feature has an additional
/// per-number monthly cost associated with it.
/// </summary>
[JsonConverter(typeof(UpdateVoiceSettingsInboundCallScreeningConverter))]
public enum UpdateVoiceSettingsInboundCallScreening
{
    Disabled, RejectCalls, FlagCalls
}sealed class UpdateVoiceSettingsInboundCallScreeningConverter : JsonConverter<UpdateVoiceSettingsInboundCallScreening>
{
    public override UpdateVoiceSettingsInboundCallScreening Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>UpdateVoiceSettingsInboundCallScreening.Disabled,
            "reject_calls"=>UpdateVoiceSettingsInboundCallScreening.RejectCalls,
            "flag_calls"=>UpdateVoiceSettingsInboundCallScreening.FlagCalls,
            _ =>(UpdateVoiceSettingsInboundCallScreening)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateVoiceSettingsInboundCallScreening value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UpdateVoiceSettingsInboundCallScreening.Disabled=>"disabled",
            UpdateVoiceSettingsInboundCallScreening.RejectCalls=>"reject_calls",
            UpdateVoiceSettingsInboundCallScreening.FlagCalls=>"flag_calls",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Controls whether a number is billed per minute or uses your concurrent channels.
/// </summary>
[JsonConverter(typeof(UpdateVoiceSettingsUsagePaymentMethodConverter))]
public enum UpdateVoiceSettingsUsagePaymentMethod
{
    PayPerMinute, Channel
}sealed class UpdateVoiceSettingsUsagePaymentMethodConverter : JsonConverter<UpdateVoiceSettingsUsagePaymentMethod>
{
    public override UpdateVoiceSettingsUsagePaymentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pay-per-minute"=>UpdateVoiceSettingsUsagePaymentMethod.PayPerMinute,
            "channel"=>UpdateVoiceSettingsUsagePaymentMethod.Channel,
            _ =>(UpdateVoiceSettingsUsagePaymentMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateVoiceSettingsUsagePaymentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UpdateVoiceSettingsUsagePaymentMethod.PayPerMinute=>"pay-per-minute",
            UpdateVoiceSettingsUsagePaymentMethod.Channel=>"channel",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}