using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.IPConnections;

[JsonConverter(typeof(JsonModelConverter<InboundIP, InboundIPFromRaw>))]
public sealed record class InboundIP : JsonModel
{
    /// <summary>
    /// This setting allows you to set the format with which the caller's number (ANI)
    /// is sent for inbound phone calls.
    /// </summary>
    public ApiEnum<string, InboundIPAniNumberFormat>? AniNumberFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InboundIPAniNumberFormat>>(
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
    /// The default primary IP to use for the number. Only settable if the connection
    /// is               of IP authentication type. Value must be the ID of an authorized
    /// IP set on the connection.
    /// </summary>
    public string? DefaultPrimaryIPID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "default_primary_ip_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default_primary_ip_id", value);
        }
    }

    /// <summary>
    /// Default routing method to be used when a number is associated with the connection.
    /// Must be one of the routing method types or left blank, other values are not allowed.
    /// </summary>
    public ApiEnum<string, InboundIPDefaultRoutingMethod>? DefaultRoutingMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InboundIPDefaultRoutingMethod>>(
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

    /// <summary>
    /// The default secondary IP to use for the number. Only settable if the connection
    /// is               of IP authentication type. Value must be the ID of an authorized
    /// IP set on the connection.
    /// </summary>
    public string? DefaultSecondaryIPID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "default_secondary_ip_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default_secondary_ip_id", value);
        }
    }

    /// <summary>
    /// The default tertiary IP to use for the number. Only settable if the connection
    /// is               of IP authentication type. Value must be the ID of an authorized
    /// IP set on the connection.
    /// </summary>
    public string? DefaultTertiaryIPID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "default_tertiary_ip_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default_tertiary_ip_id", value);
        }
    }

    public ApiEnum<string, InboundIPDnisNumberFormat>? DnisNumberFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InboundIPDnisNumberFormat>>(
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
    public ApiEnum<string, InboundIPSipRegion>? SipRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InboundIPSipRegion>>(
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
    /// Specifies a subdomain that can be used to receive Inbound calls to a Connection,
    /// in the same way a phone number is used, from a SIP endpoint. Example: the
    /// subdomain "example.sip.telnyx.com" can be called from any SIP endpoint by
    /// using the SIP URI "sip:@example.sip.telnyx.com" where the user part can be
    /// any alphanumeric value. Please note TLS encrypted calls are not allowed for
    /// subdomain calls.
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
    /// This option can be enabled to receive calls from: "Anyone" (any SIP endpoint
    /// in the public Internet) or "Only my connections" (any connection assigned
    /// to the same Telnyx user).
    /// </summary>
    public ApiEnum<string, InboundIPSipSubdomainReceiveSettings>? SipSubdomainReceiveSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InboundIPSipSubdomainReceiveSettings>>(
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
        _ = this.DefaultPrimaryIPID;
        this.DefaultRoutingMethod?.Validate();
        _ = this.DefaultSecondaryIPID;
        _ = this.DefaultTertiaryIPID;
        this.DnisNumberFormat?.Validate();
        _ = this.GenerateRingbackTone;
        _ = this.IsupHeadersEnabled;
        _ = this.PrackEnabled;
        _ = this.ShakenStirEnabled;
        _ = this.SipCompactHeadersEnabled;
        this.SipRegion?.Validate();
        _ = this.SipSubdomain;
        this.SipSubdomainReceiveSettings?.Validate();
        _ = this.Timeout1xxSecs;
        _ = this.Timeout2xxSecs;
    }

    public InboundIP ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundIP (InboundIP inboundIP) : base(inboundIP)
    {  }
    #pragma warning restore CS8618

    public InboundIP (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundIP (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundIPFromRaw.FromRawUnchecked"/>
    public static InboundIP FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InboundIPFromRaw : IFromRawJson<InboundIP>
{
    /// <inheritdoc/>
    public InboundIP FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboundIP.FromRawUnchecked(rawData);
}

/// <summary>
/// This setting allows you to set the format with which the caller's number (ANI)
/// is sent for inbound phone calls.
/// </summary>
[JsonConverter(typeof(InboundIPAniNumberFormatConverter))]
public enum InboundIPAniNumberFormat
{
    PlusE164, E164, PlusE164National, E164National
}sealed class InboundIPAniNumberFormatConverter : JsonConverter<InboundIPAniNumberFormat>
{
    public override InboundIPAniNumberFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "+E.164"=>InboundIPAniNumberFormat.PlusE164,
            "E.164"=>InboundIPAniNumberFormat.E164,
            "+E.164-national"=>InboundIPAniNumberFormat.PlusE164National,
            "E.164-national"=>InboundIPAniNumberFormat.E164National,
            _ =>(InboundIPAniNumberFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundIPAniNumberFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InboundIPAniNumberFormat.PlusE164=>"+E.164",
            InboundIPAniNumberFormat.E164=>"E.164",
            InboundIPAniNumberFormat.PlusE164National=>"+E.164-national",
            InboundIPAniNumberFormat.E164National=>"E.164-national",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Default routing method to be used when a number is associated with the connection.
/// Must be one of the routing method types or left blank, other values are not allowed.
/// </summary>
[JsonConverter(typeof(InboundIPDefaultRoutingMethodConverter))]
public enum InboundIPDefaultRoutingMethod
{
    Sequential, RoundRobin
}sealed class InboundIPDefaultRoutingMethodConverter : JsonConverter<InboundIPDefaultRoutingMethod>
{
    public override InboundIPDefaultRoutingMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sequential"=>InboundIPDefaultRoutingMethod.Sequential,
            "round-robin"=>InboundIPDefaultRoutingMethod.RoundRobin,
            _ =>(InboundIPDefaultRoutingMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundIPDefaultRoutingMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InboundIPDefaultRoutingMethod.Sequential=>"sequential",
            InboundIPDefaultRoutingMethod.RoundRobin=>"round-robin",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(InboundIPDnisNumberFormatConverter))]
public enum InboundIPDnisNumberFormat
{
    PlusE164, E164, National, SipUsername
}sealed class InboundIPDnisNumberFormatConverter : JsonConverter<InboundIPDnisNumberFormat>
{
    public override InboundIPDnisNumberFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "+e164"=>InboundIPDnisNumberFormat.PlusE164,
            "e164"=>InboundIPDnisNumberFormat.E164,
            "national"=>InboundIPDnisNumberFormat.National,
            "sip_username"=>InboundIPDnisNumberFormat.SipUsername,
            _ =>(InboundIPDnisNumberFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundIPDnisNumberFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InboundIPDnisNumberFormat.PlusE164=>"+e164",
            InboundIPDnisNumberFormat.E164=>"e164",
            InboundIPDnisNumberFormat.National=>"national",
            InboundIPDnisNumberFormat.SipUsername=>"sip_username",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Selects which `sip_region` to receive inbound calls from. If null, the default
/// region (US) will be used.
/// </summary>
[JsonConverter(typeof(InboundIPSipRegionConverter))]
public enum InboundIPSipRegion
{
    Us, Europe, Australia
}sealed class InboundIPSipRegionConverter : JsonConverter<InboundIPSipRegion>
{
    public override InboundIPSipRegion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "US"=>InboundIPSipRegion.Us,
            "Europe"=>InboundIPSipRegion.Europe,
            "Australia"=>InboundIPSipRegion.Australia,
            _ =>(InboundIPSipRegion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundIPSipRegion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InboundIPSipRegion.Us=>"US",
            InboundIPSipRegion.Europe=>"Europe",
            InboundIPSipRegion.Australia=>"Australia",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// This option can be enabled to receive calls from: "Anyone" (any SIP endpoint in
/// the public Internet) or "Only my connections" (any connection assigned to the
/// same Telnyx user).
/// </summary>
[JsonConverter(typeof(InboundIPSipSubdomainReceiveSettingsConverter))]
public enum InboundIPSipSubdomainReceiveSettings
{
    OnlyMyConnections, FromAnyone
}sealed class InboundIPSipSubdomainReceiveSettingsConverter : JsonConverter<InboundIPSipSubdomainReceiveSettings>
{
    public override InboundIPSipSubdomainReceiveSettings Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "only_my_connections"=>InboundIPSipSubdomainReceiveSettings.OnlyMyConnections,
            "from_anyone"=>InboundIPSipSubdomainReceiveSettings.FromAnyone,
            _ =>(InboundIPSipSubdomainReceiveSettings)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundIPSipSubdomainReceiveSettings value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InboundIPSipSubdomainReceiveSettings.OnlyMyConnections=>"only_my_connections",
            InboundIPSipSubdomainReceiveSettings.FromAnyone=>"from_anyone",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}