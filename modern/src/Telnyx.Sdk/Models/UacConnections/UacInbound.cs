using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.UacConnections;

[JsonConverter(typeof(JsonModelConverter<UacInbound, UacInboundFromRaw>))]
public sealed record class UacInbound : JsonModel
{
    /// <summary>
    /// This setting allows you to set the format with which the caller's number (ANI)
    /// is sent for inbound phone calls.
    /// </summary>
    public ApiEnum<string, AniNumberFormat>? AniNumberFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AniNumberFormat>>(
                "ani_number_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ani_number_format", value);
        }
    }

    /// <summary>
    /// When set, this will limit the total number of inbound calls to phone numbers
    /// associated with this connection.
    /// </summary>
    public long? ChannelLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "channel_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channel_limit", value);
        }
    }

    /// <summary>
    /// Defines the list of codecs that Telnyx will send for inbound calls to a specific
    /// number on your portal account, in priority order. This only works when the
    /// Connection the number is assigned to uses Media Handling mode: default. OPUS
    /// and H.264 codecs are available only when using TCP or TLS transport for SIP.
    /// </summary>
    public IReadOnlyList<string>? Codecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "codecs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "codecs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Default routing method to be used when a number is associated with the connection.
    /// Must be one of the routing method types or left blank, other values are not allowed.
    /// </summary>
    public ApiEnum<string, DefaultRoutingMethod>? DefaultRoutingMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DefaultRoutingMethod>>(
                "default_routing_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default_routing_method", value);
        }
    }

    public ApiEnum<string, DnisNumberFormat>? DnisNumberFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DnisNumberFormat>>(
                "dnis_number_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("dnis_number_format", value);
        }
    }

    /// <summary>
    /// Generate ringback tone through 183 session progress message with early media.
    /// </summary>
    public bool? GenerateRingbackTone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "generate_ringback_tone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("generate_ringback_tone", value);
        }
    }

    /// <summary>
    /// When set, inbound phone calls will receive ISUP parameters via SIP headers.
    /// (Only when available and only when using TCP or TLS transport.)
    /// </summary>
    public bool? IsupHeadersEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "isup_headers_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("isup_headers_enabled", value);
        }
    }

    /// <summary>
    /// Enable PRACK messages as defined in RFC3262.
    /// </summary>
    public bool? PrackEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "prack_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("prack_enabled", value);
        }
    }

    /// <summary>
    /// When enabled the SIP Connection will receive the Identity header with Shaken/Stir
    /// data in the SIP INVITE message of inbound calls, even when using UDP transport.
    /// </summary>
    public bool? ShakenStirEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shaken_stir_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shaken_stir_enabled", value);
        }
    }

    /// <summary>
    /// When enabled, allows multiple devices to ring simultaneously on incoming calls.
    /// </summary>
    public ApiEnum<string, SimultaneousRinging>? SimultaneousRinging {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SimultaneousRinging>>(
                "simultaneous_ringing"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("simultaneous_ringing", value);
        }
    }

    /// <summary>
    /// Defaults to true.
    /// </summary>
    public bool? SipCompactHeadersEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "sip_compact_headers_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_compact_headers_enabled", value);
        }
    }

    /// <summary>
    /// Selects which `sip_region` to receive inbound calls from. If null, the default
    /// region (US) will be used.
    /// </summary>
    public ApiEnum<string, SipRegion>? SipRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SipRegion>>(
                "sip_region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_region", value);
        }
    }

    /// <summary>
    /// The Telnyx-generated SIP subdomain for this UAC connection.
    /// </summary>
    public string? SipSubdomain {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_subdomain"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_subdomain", value);
        }
    }

    /// <summary>
    /// Controls which SIP URI callers may reach this connection.
    /// </summary>
    public ApiEnum<string, SipSubdomainReceiveSettings>? SipSubdomainReceiveSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SipSubdomainReceiveSettings>>(
                "sip_subdomain_receive_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_subdomain_receive_settings", value);
        }
    }

    /// <summary>
    /// Time(sec) before aborting if connection is not made.
    /// </summary>
    public long? Timeout1xxSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "timeout_1xx_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timeout_1xx_secs", value);
        }
    }

    /// <summary>
    /// Time(sec) before aborting if call is unanswered (min: 1, max: 600).
    /// </summary>
    public long? Timeout2xxSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "timeout_2xx_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timeout_2xx_secs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AniNumberFormat?.Validate();
        _ = this.ChannelLimit;
        _ = this.Codecs;
        this.DefaultRoutingMethod?.Validate();
        this.DnisNumberFormat?.Validate();
        _ = this.GenerateRingbackTone;
        _ = this.IsupHeadersEnabled;
        _ = this.PrackEnabled;
        _ = this.ShakenStirEnabled;
        this.SimultaneousRinging?.Validate();
        _ = this.SipCompactHeadersEnabled;
        this.SipRegion?.Validate();
        _ = this.SipSubdomain;
        this.SipSubdomainReceiveSettings?.Validate();
        _ = this.Timeout1xxSecs;
        _ = this.Timeout2xxSecs;
    }

    public UacInbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UacInbound (UacInbound uacInbound) : base(uacInbound)
    {  }
    #pragma warning restore CS8618

    public UacInbound (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UacInbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UacInboundFromRaw.FromRawUnchecked"/>
    public static UacInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UacInboundFromRaw : IFromRawJson<UacInbound>
{
    /// <inheritdoc/>
    public UacInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UacInbound.FromRawUnchecked(rawData);
}

/// <summary>
/// This setting allows you to set the format with which the caller's number (ANI)
/// is sent for inbound phone calls.
/// </summary>
[JsonConverter(typeof(AniNumberFormatConverter))]
public enum AniNumberFormat
{
    PlusE164, E164, PlusE164National, E164National
}sealed class AniNumberFormatConverter : JsonConverter<AniNumberFormat>
{
    public override AniNumberFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "+E.164"=>AniNumberFormat.PlusE164,
            "E.164"=>AniNumberFormat.E164,
            "+E.164-national"=>AniNumberFormat.PlusE164National,
            "E.164-national"=>AniNumberFormat.E164National,
            _ =>(AniNumberFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AniNumberFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AniNumberFormat.PlusE164=>"+E.164",
            AniNumberFormat.E164=>"E.164",
            AniNumberFormat.PlusE164National=>"+E.164-national",
            AniNumberFormat.E164National=>"E.164-national",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Default routing method to be used when a number is associated with the connection.
/// Must be one of the routing method types or left blank, other values are not allowed.
/// </summary>
[JsonConverter(typeof(DefaultRoutingMethodConverter))]
public enum DefaultRoutingMethod
{
    Sequential, RoundRobin
}sealed class DefaultRoutingMethodConverter : JsonConverter<DefaultRoutingMethod>
{
    public override DefaultRoutingMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sequential"=>DefaultRoutingMethod.Sequential,
            "round-robin"=>DefaultRoutingMethod.RoundRobin,
            _ =>(DefaultRoutingMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DefaultRoutingMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DefaultRoutingMethod.Sequential=>"sequential",
            DefaultRoutingMethod.RoundRobin=>"round-robin",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(DnisNumberFormatConverter))]
public enum DnisNumberFormat
{
    PlusE164, E164, National, SipUsername
}sealed class DnisNumberFormatConverter : JsonConverter<DnisNumberFormat>
{
    public override DnisNumberFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "+e164"=>DnisNumberFormat.PlusE164,
            "e164"=>DnisNumberFormat.E164,
            "national"=>DnisNumberFormat.National,
            "sip_username"=>DnisNumberFormat.SipUsername,
            _ =>(DnisNumberFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DnisNumberFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DnisNumberFormat.PlusE164=>"+e164",
            DnisNumberFormat.E164=>"e164",
            DnisNumberFormat.National=>"national",
            DnisNumberFormat.SipUsername=>"sip_username",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// When enabled, allows multiple devices to ring simultaneously on incoming calls.
/// </summary>
[JsonConverter(typeof(SimultaneousRingingConverter))]
public enum SimultaneousRinging
{
    Disabled, Enabled
}sealed class SimultaneousRingingConverter : JsonConverter<SimultaneousRinging>
{
    public override SimultaneousRinging Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>SimultaneousRinging.Disabled,
            "enabled"=>SimultaneousRinging.Enabled,
            _ =>(SimultaneousRinging)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SimultaneousRinging value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SimultaneousRinging.Disabled=>"disabled",
            SimultaneousRinging.Enabled=>"enabled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Selects which `sip_region` to receive inbound calls from. If null, the default
/// region (US) will be used.
/// </summary>
[JsonConverter(typeof(SipRegionConverter))]
public enum SipRegion
{
    Us, Europe, Australia
}sealed class SipRegionConverter : JsonConverter<SipRegion>
{
    public override SipRegion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "US"=>SipRegion.Us,
            "Europe"=>SipRegion.Europe,
            "Australia"=>SipRegion.Australia,
            _ =>(SipRegion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, SipRegion value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SipRegion.Us=>"US",
            SipRegion.Europe=>"Europe",
            SipRegion.Australia=>"Australia",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Controls which SIP URI callers may reach this connection.
/// </summary>
[JsonConverter(typeof(SipSubdomainReceiveSettingsConverter))]
public enum SipSubdomainReceiveSettings
{
    OnlyMyConnections, FromAnyone
}sealed class SipSubdomainReceiveSettingsConverter : JsonConverter<SipSubdomainReceiveSettings>
{
    public override SipSubdomainReceiveSettings Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "only_my_connections"=>SipSubdomainReceiveSettings.OnlyMyConnections,
            "from_anyone"=>SipSubdomainReceiveSettings.FromAnyone,
            _ =>(SipSubdomainReceiveSettings)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SipSubdomainReceiveSettings value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SipSubdomainReceiveSettings.OnlyMyConnections=>"only_my_connections",
            SipSubdomainReceiveSettings.FromAnyone=>"from_anyone",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}