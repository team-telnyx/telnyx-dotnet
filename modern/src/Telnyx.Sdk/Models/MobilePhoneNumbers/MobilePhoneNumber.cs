using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MobilePhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<MobilePhoneNumber, MobilePhoneNumberFromRaw>))]
public sealed record class MobilePhoneNumber : JsonModel
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

    public MobilePhoneNumberCallForwarding? CallForwarding {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MobilePhoneNumberCallForwarding>(
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

    public MobilePhoneNumberCallRecording? CallRecording {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MobilePhoneNumberCallRecording>(
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
    /// Indicates if caller ID name is enabled.
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

    public MobilePhoneNumberCnamListing? CnamListing {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MobilePhoneNumberCnamListing>(
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
    /// The ID of the connection associated with this number.
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
    /// The name of the connection.
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
    /// The type of the connection.
    /// </summary>
    public string? ConnectionType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_type"
            );
        }
        init { this._rawData.Set("connection_type", value); }
    }

    /// <summary>
    /// The ISO 3166-1 alpha-2 country code of the number.
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
    /// A customer reference string.
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

    public MobilePhoneNumberInbound? Inbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MobilePhoneNumberInbound>(
                "inbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound", value);
        }
    }

    /// <summary>
    /// The inbound call screening setting.
    /// </summary>
    public ApiEnum<string, MobilePhoneNumberInboundCallScreening>? InboundCallScreening {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MobilePhoneNumberInboundCallScreening>>(
                "inbound_call_screening"
            );
        }
        init { this._rawData.Set("inbound_call_screening", value); }
    }

    /// <summary>
    /// Indicates if mobile voice is enabled.
    /// </summary>
    public bool? MobileVoiceEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "mobile_voice_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mobile_voice_enabled", value);
        }
    }

    /// <summary>
    /// The noise suppression setting.
    /// </summary>
    public ApiEnum<string, NoiseSuppression>? NoiseSuppression {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NoiseSuppression>>(
                "noise_suppression"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("noise_suppression", value);
        }
    }

    public MobilePhoneNumberOutbound? Outbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MobilePhoneNumberOutbound>(
                "outbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("outbound", value);
        }
    }

    /// <summary>
    /// The +E.164-formatted phone number.
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
    /// The ID of the SIM card associated with this number.
    /// </summary>
    public string? SimCardID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_card_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_card_id", value);
        }
    }

    /// <summary>
    /// The status of the phone number.
    /// </summary>
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

    /// <summary>
    /// A list of tags associated with the number.
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
    /// ISO 8601 formatted date indicating when the resource was last updated.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.CallForwarding?.Validate();
        this.CallRecording?.Validate();
        _ = this.CallerIDNameEnabled;
        this.CnamListing?.Validate();
        _ = this.ConnectionID;
        _ = this.ConnectionName;
        _ = this.ConnectionType;
        _ = this.CountryIsoAlpha2;
        _ = this.CreatedAt;
        _ = this.CustomerReference;
        this.Inbound?.Validate();
        this.InboundCallScreening?.Validate();
        _ = this.MobileVoiceEnabled;
        this.NoiseSuppression?.Validate();
        this.Outbound?.Validate();
        _ = this.PhoneNumber;
        _ = this.RecordType;
        _ = this.SimCardID;
        _ = this.Status;
        _ = this.Tags;
        _ = this.UpdatedAt;
    }

    public MobilePhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobilePhoneNumber (MobilePhoneNumber mobilePhoneNumber) : base(
        mobilePhoneNumber
    )
    {  }
    #pragma warning restore CS8618

    public MobilePhoneNumber (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobilePhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobilePhoneNumberFromRaw.FromRawUnchecked"/>
    public static MobilePhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobilePhoneNumberFromRaw : IFromRawJson<MobilePhoneNumber>
{
    /// <inheritdoc/>
    public MobilePhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobilePhoneNumber.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MobilePhoneNumberCallForwarding, MobilePhoneNumberCallForwardingFromRaw>))]
public sealed record class MobilePhoneNumberCallForwarding : JsonModel
{
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

    public ApiEnum<string, MobilePhoneNumberCallForwardingForwardingType>? ForwardingType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MobilePhoneNumberCallForwardingForwardingType>>(
                "forwarding_type"
            );
        }
        init { this._rawData.Set("forwarding_type", value); }
    }

    public string? ForwardsTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "forwards_to"
            );
        }
        init { this._rawData.Set("forwards_to", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallForwardingEnabled;
        this.ForwardingType?.Validate();
        _ = this.ForwardsTo;
    }

    public MobilePhoneNumberCallForwarding ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobilePhoneNumberCallForwarding (
        MobilePhoneNumberCallForwarding mobilePhoneNumberCallForwarding
    ) : base(mobilePhoneNumberCallForwarding)
    {  }
    #pragma warning restore CS8618

    public MobilePhoneNumberCallForwarding (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobilePhoneNumberCallForwarding (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobilePhoneNumberCallForwardingFromRaw.FromRawUnchecked"/>
    public static MobilePhoneNumberCallForwarding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MobilePhoneNumberCallForwardingFromRaw : IFromRawJson<MobilePhoneNumberCallForwarding>
{
    /// <inheritdoc/>
    public MobilePhoneNumberCallForwarding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobilePhoneNumberCallForwarding.FromRawUnchecked(rawData);
}[JsonConverter(typeof(MobilePhoneNumberCallForwardingForwardingTypeConverter))]
public enum MobilePhoneNumberCallForwardingForwardingType
{
    Always, OnFailure
}sealed class MobilePhoneNumberCallForwardingForwardingTypeConverter : JsonConverter<MobilePhoneNumberCallForwardingForwardingType>
{
    public override MobilePhoneNumberCallForwardingForwardingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "always"=>MobilePhoneNumberCallForwardingForwardingType.Always,
            "on-failure"=>MobilePhoneNumberCallForwardingForwardingType.OnFailure,
            _ =>(MobilePhoneNumberCallForwardingForwardingType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MobilePhoneNumberCallForwardingForwardingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MobilePhoneNumberCallForwardingForwardingType.Always=>"always",
            MobilePhoneNumberCallForwardingForwardingType.OnFailure=>"on-failure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MobilePhoneNumberCallRecording, MobilePhoneNumberCallRecordingFromRaw>))]
public sealed record class MobilePhoneNumberCallRecording : JsonModel
{
    public ApiEnum<string, MobilePhoneNumberCallRecordingInboundCallRecordingChannels>? InboundCallRecordingChannels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MobilePhoneNumberCallRecordingInboundCallRecordingChannels>>(
                "inbound_call_recording_channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound_call_recording_channels", value);
        }
    }

    public bool? InboundCallRecordingEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "inbound_call_recording_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound_call_recording_enabled", value);
        }
    }

    public ApiEnum<string, MobilePhoneNumberCallRecordingInboundCallRecordingFormat>? InboundCallRecordingFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MobilePhoneNumberCallRecordingInboundCallRecordingFormat>>(
                "inbound_call_recording_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound_call_recording_format", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.InboundCallRecordingChannels?.Validate();
        _ = this.InboundCallRecordingEnabled;
        this.InboundCallRecordingFormat?.Validate();
    }

    public MobilePhoneNumberCallRecording ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobilePhoneNumberCallRecording (
        MobilePhoneNumberCallRecording mobilePhoneNumberCallRecording
    ) : base(mobilePhoneNumberCallRecording)
    {  }
    #pragma warning restore CS8618

    public MobilePhoneNumberCallRecording (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobilePhoneNumberCallRecording (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobilePhoneNumberCallRecordingFromRaw.FromRawUnchecked"/>
    public static MobilePhoneNumberCallRecording FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MobilePhoneNumberCallRecordingFromRaw : IFromRawJson<MobilePhoneNumberCallRecording>
{
    /// <inheritdoc/>
    public MobilePhoneNumberCallRecording FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobilePhoneNumberCallRecording.FromRawUnchecked(rawData);
}[JsonConverter(typeof(MobilePhoneNumberCallRecordingInboundCallRecordingChannelsConverter))]
public enum MobilePhoneNumberCallRecordingInboundCallRecordingChannels
{
    Single, Dual
}sealed class MobilePhoneNumberCallRecordingInboundCallRecordingChannelsConverter : JsonConverter<MobilePhoneNumberCallRecordingInboundCallRecordingChannels>
{
    public override MobilePhoneNumberCallRecordingInboundCallRecordingChannels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "single"=>MobilePhoneNumberCallRecordingInboundCallRecordingChannels.Single,
            "dual"=>MobilePhoneNumberCallRecordingInboundCallRecordingChannels.Dual,
            _ =>(MobilePhoneNumberCallRecordingInboundCallRecordingChannels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MobilePhoneNumberCallRecordingInboundCallRecordingChannels value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MobilePhoneNumberCallRecordingInboundCallRecordingChannels.Single=>"single",
            MobilePhoneNumberCallRecordingInboundCallRecordingChannels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(MobilePhoneNumberCallRecordingInboundCallRecordingFormatConverter))]
public enum MobilePhoneNumberCallRecordingInboundCallRecordingFormat
{
    Wav, Mp3
}sealed class MobilePhoneNumberCallRecordingInboundCallRecordingFormatConverter : JsonConverter<MobilePhoneNumberCallRecordingInboundCallRecordingFormat>
{
    public override MobilePhoneNumberCallRecordingInboundCallRecordingFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wav"=>MobilePhoneNumberCallRecordingInboundCallRecordingFormat.Wav,
            "mp3"=>MobilePhoneNumberCallRecordingInboundCallRecordingFormat.Mp3,
            _ =>(MobilePhoneNumberCallRecordingInboundCallRecordingFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MobilePhoneNumberCallRecordingInboundCallRecordingFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MobilePhoneNumberCallRecordingInboundCallRecordingFormat.Wav=>"wav",
            MobilePhoneNumberCallRecordingInboundCallRecordingFormat.Mp3=>"mp3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MobilePhoneNumberCnamListing, MobilePhoneNumberCnamListingFromRaw>))]
public sealed record class MobilePhoneNumberCnamListing : JsonModel
{
    public string? CnamListingDetails {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cnam_listing_details"
            );
        }
        init { this._rawData.Set("cnam_listing_details", value); }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CnamListingDetails;
        _ = this.CnamListingEnabled;
    }

    public MobilePhoneNumberCnamListing ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobilePhoneNumberCnamListing (
        MobilePhoneNumberCnamListing mobilePhoneNumberCnamListing
    ) : base(mobilePhoneNumberCnamListing)
    {  }
    #pragma warning restore CS8618

    public MobilePhoneNumberCnamListing (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobilePhoneNumberCnamListing (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobilePhoneNumberCnamListingFromRaw.FromRawUnchecked"/>
    public static MobilePhoneNumberCnamListing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MobilePhoneNumberCnamListingFromRaw : IFromRawJson<MobilePhoneNumberCnamListing>
{
    /// <inheritdoc/>
    public MobilePhoneNumberCnamListing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobilePhoneNumberCnamListing.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<MobilePhoneNumberInbound, MobilePhoneNumberInboundFromRaw>))]
public sealed record class MobilePhoneNumberInbound : JsonModel
{
    /// <summary>
    /// The ID of the app that will intercept inbound calls.
    /// </summary>
    public string? InterceptionAppID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "interception_app_id"
            );
        }
        init { this._rawData.Set("interception_app_id", value); }
    }

    /// <summary>
    /// The name of the app that will intercept inbound calls.
    /// </summary>
    public string? InterceptionAppName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "interception_app_name"
            );
        }
        init { this._rawData.Set("interception_app_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InterceptionAppID;
        _ = this.InterceptionAppName;
    }

    public MobilePhoneNumberInbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobilePhoneNumberInbound (
        MobilePhoneNumberInbound mobilePhoneNumberInbound
    ) : base(mobilePhoneNumberInbound)
    {  }
    #pragma warning restore CS8618

    public MobilePhoneNumberInbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobilePhoneNumberInbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobilePhoneNumberInboundFromRaw.FromRawUnchecked"/>
    public static MobilePhoneNumberInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MobilePhoneNumberInboundFromRaw : IFromRawJson<MobilePhoneNumberInbound>
{
    /// <inheritdoc/>
    public MobilePhoneNumberInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobilePhoneNumberInbound.FromRawUnchecked(rawData);
}/// <summary>
/// The inbound call screening setting.
/// </summary>
[JsonConverter(typeof(MobilePhoneNumberInboundCallScreeningConverter))]
public enum MobilePhoneNumberInboundCallScreening
{
    Disabled, RejectCalls, FlagCalls
}sealed class MobilePhoneNumberInboundCallScreeningConverter : JsonConverter<MobilePhoneNumberInboundCallScreening>
{
    public override MobilePhoneNumberInboundCallScreening Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>MobilePhoneNumberInboundCallScreening.Disabled,
            "reject_calls"=>MobilePhoneNumberInboundCallScreening.RejectCalls,
            "flag_calls"=>MobilePhoneNumberInboundCallScreening.FlagCalls,
            _ =>(MobilePhoneNumberInboundCallScreening)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MobilePhoneNumberInboundCallScreening value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MobilePhoneNumberInboundCallScreening.Disabled=>"disabled",
            MobilePhoneNumberInboundCallScreening.RejectCalls=>"reject_calls",
            MobilePhoneNumberInboundCallScreening.FlagCalls=>"flag_calls",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The noise suppression setting.
/// </summary>
[JsonConverter(typeof(NoiseSuppressionConverter))]
public enum NoiseSuppression
{
    Inbound, Outbound, Both, Disabled
}sealed class NoiseSuppressionConverter : JsonConverter<NoiseSuppression>
{
    public override NoiseSuppression Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>NoiseSuppression.Inbound,
            "outbound"=>NoiseSuppression.Outbound,
            "both"=>NoiseSuppression.Both,
            "disabled"=>NoiseSuppression.Disabled,
            _ =>(NoiseSuppression)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NoiseSuppression value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NoiseSuppression.Inbound=>"inbound",
            NoiseSuppression.Outbound=>"outbound",
            NoiseSuppression.Both=>"both",
            NoiseSuppression.Disabled=>"disabled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MobilePhoneNumberOutbound, MobilePhoneNumberOutboundFromRaw>))]
public sealed record class MobilePhoneNumberOutbound : JsonModel
{
    /// <summary>
    /// The ID of the app that will intercept outbound calls.
    /// </summary>
    public string? InterceptionAppID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "interception_app_id"
            );
        }
        init { this._rawData.Set("interception_app_id", value); }
    }

    /// <summary>
    /// The name of the app that will intercept outbound calls.
    /// </summary>
    public string? InterceptionAppName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "interception_app_name"
            );
        }
        init { this._rawData.Set("interception_app_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InterceptionAppID;
        _ = this.InterceptionAppName;
    }

    public MobilePhoneNumberOutbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobilePhoneNumberOutbound (
        MobilePhoneNumberOutbound mobilePhoneNumberOutbound
    ) : base(mobilePhoneNumberOutbound)
    {  }
    #pragma warning restore CS8618

    public MobilePhoneNumberOutbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobilePhoneNumberOutbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobilePhoneNumberOutboundFromRaw.FromRawUnchecked"/>
    public static MobilePhoneNumberOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MobilePhoneNumberOutboundFromRaw : IFromRawJson<MobilePhoneNumberOutbound>
{
    /// <inheritdoc/>
    public MobilePhoneNumberOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobilePhoneNumberOutbound.FromRawUnchecked(rawData);
}