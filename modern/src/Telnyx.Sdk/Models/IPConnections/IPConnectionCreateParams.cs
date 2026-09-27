using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.CredentialConnections;

namespace Telnyx.Sdk.Models.IPConnections;

/// <summary>
/// Creates a new IP-based SIP connection, which authenticates traffic by source IP address.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class IPConnectionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Defaults to true
    /// </summary>
    public bool? Active {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("active", value);
        }
    }

    /// <summary>
    /// `Latency` directs Telnyx to route media through the site with the lowest
    /// round-trip time to the user's connection. Telnyx calculates this time using
    /// ICMP ping messages. This can be disabled by specifying a site to handle all media.
    /// </summary>
    public ApiEnum<string, AnchorsiteOverride>? AnchorsiteOverride {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AnchorsiteOverride>>(
                "anchorsite_override"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("anchorsite_override", value);
        }
    }

    /// <summary>
    /// The uuid of the push credential for Android
    /// </summary>
    public string? AndroidPushCredentialID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "android_push_credential_id"
            );
        }
        init { this._rawBodyData.Set("android_push_credential_id", value); }
    }

    /// <summary>
    /// Specifies if call cost webhooks should be sent for this connection.
    /// </summary>
    public bool? CallCostInWebhooks {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "call_cost_in_webhooks"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("call_cost_in_webhooks", value);
        }
    }

    public string? ConnectionName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "connection_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("connection_name", value);
        }
    }

    /// <summary>
    /// When enabled, Telnyx will generate comfort noise when you place the call
    /// on hold. If disabled, you will need to generate comfort noise or on hold
    /// music to avoid RTP timeout.
    /// </summary>
    public bool? DefaultOnHoldComfortNoiseEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "default_on_hold_comfort_noise_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("default_on_hold_comfort_noise_enabled", value);
        }
    }

    /// <summary>
    /// Sets the type of DTMF digits sent from Telnyx to this Connection. Note that
    /// DTMF digits sent to Telnyx will be accepted in all formats.
    /// </summary>
    public ApiEnum<string, DtmfType>? DtmfType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, DtmfType>>(
                "dtmf_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("dtmf_type", value);
        }
    }

    /// <summary>
    /// Encode the SIP contact header sent by Telnyx to avoid issues for NAT or ALG scenarios.
    /// </summary>
    public bool? EncodeContactHeaderEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "encode_contact_header_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("encode_contact_header_enabled", value);
        }
    }

    /// <summary>
    /// Enable use of SRTP for encryption. Cannot be set if the transport_portocol
    /// is TLS.
    /// </summary>
    public ApiEnum<string, EncryptedMedia>? EncryptedMedia {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, EncryptedMedia>>(
                "encrypted_media"
            );
        }
        init { this._rawBodyData.Set("encrypted_media", value); }
    }

    public Inbound? Inbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Inbound>(
                "inbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("inbound", value);
        }
    }

    /// <summary>
    /// The uuid of the push credential for Ios
    /// </summary>
    public string? IosPushCredentialID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "ios_push_credential_id"
            );
        }
        init { this._rawBodyData.Set("ios_push_credential_id", value); }
    }

    /// <summary>
    /// Configuration options for Jitter Buffer. Enables Jitter Buffer for RTP streams
    /// of SIP Trunking calls. The feature is off unless enabled. You may define
    /// min and max values in msec for customized buffering behaviors. Larger values
    /// add latency but tolerate more jitter, while smaller values reduce latency
    /// but are more sensitive to jitter and reordering.
    /// </summary>
    public ConnectionJitterBuffer? JitterBuffer {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ConnectionJitterBuffer>(
                "jitter_buffer"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("jitter_buffer", value);
        }
    }

    /// <summary>
    /// Controls when noise suppression is applied to calls. When set to 'inbound',
    /// noise suppression is applied to incoming audio. When set to 'outbound', it's
    /// applied to outgoing audio. When set to 'both', it's applied in both directions.
    /// When set to 'disabled', noise suppression is turned off.
    /// </summary>
    public ApiEnum<string, ConnectionNoiseSuppression>? NoiseSuppression {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConnectionNoiseSuppression>>(
                "noise_suppression"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("noise_suppression", value);
        }
    }

    /// <summary>
    /// Configuration options for noise suppression. These settings are stored regardless
    /// of the noise_suppression value, but only take effect when noise_suppression
    /// is not 'disabled'. If you disable noise suppression and later re-enable it,
    /// the previously configured settings will be used.
    /// </summary>
    public ConnectionNoiseSuppressionDetails? NoiseSuppressionDetails {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ConnectionNoiseSuppressionDetails>(
                "noise_suppression_details"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("noise_suppression_details", value);
        }
    }

    /// <summary>
    /// Enable on-net T38 if you prefer the sender and receiver negotiating T38 directly
    /// if both are on the Telnyx network. If this is disabled, Telnyx will be able
    /// to use T38 on just one leg of the call depending on each leg's settings.
    /// </summary>
    public bool? OnnetT38PassthroughEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "onnet_t38_passthrough_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("onnet_t38_passthrough_enabled", value);
        }
    }

    public OutboundIP? Outbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<OutboundIP>(
                "outbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("outbound", value);
        }
    }

    public ConnectionRtcpSettings? RtcpSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ConnectionRtcpSettings>(
                "rtcp_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("rtcp_settings", value);
        }
    }

    /// <summary>
    /// Tags associated with the connection.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// One of UDP, TLS, or TCP. Applies only to connections with IP authentication
    /// or FQDN authentication.
    /// </summary>
    public ApiEnum<string, TransportProtocol>? TransportProtocol {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TransportProtocol>>(
                "transport_protocol"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transport_protocol", value);
        }
    }

    /// <summary>
    /// Determines which webhook format will be used, Telnyx API v1 or v2.
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.IPConnections.WebhookApiVersion>? WebhookApiVersion {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.IPConnections.WebhookApiVersion>>(
                "webhook_api_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_api_version", value);
        }
    }

    /// <summary>
    /// The failover URL where webhooks related to this connection will be sent if
    /// sending to the primary URL fails. Must include a scheme, such as 'https'.
    /// </summary>
    public string? WebhookEventFailoverUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_event_failover_url"
            );
        }
        init { this._rawBodyData.Set("webhook_event_failover_url", value); }
    }

    /// <summary>
    /// The URL where webhooks related to this connection will be sent. Must include
    /// a scheme, such as 'https'.
    /// </summary>
    public string? WebhookEventUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_event_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_event_url", value);
        }
    }

    /// <summary>
    /// Specifies how many seconds to wait before timing out a webhook.
    /// </summary>
    public long? WebhookTimeoutSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "webhook_timeout_secs"
            );
        }
        init { this._rawBodyData.Set("webhook_timeout_secs", value); }
    }

    public IPConnectionCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IPConnectionCreateParams (
        IPConnectionCreateParams ipConnectionCreateParams
    ) : base(ipConnectionCreateParams)
    { this._rawBodyData = new(ipConnectionCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public IPConnectionCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IPConnectionCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static IPConnectionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(IPConnectionCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/ip_connections"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

[JsonConverter(typeof(JsonModelConverter<Inbound, InboundFromRaw>))]
public sealed record class Inbound : JsonModel
{
    /// <summary>
    /// This setting allows you to set the format with which the caller's number (ANI)
    /// is sent for inbound phone calls.
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat>? AniNumberFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat>>(
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
    public ApiEnum<string, global::Telnyx.Sdk.Models.IPConnections.DefaultRoutingMethod>? DefaultRoutingMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.IPConnections.DefaultRoutingMethod>>(
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

    public ApiEnum<string, global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat>? DnisNumberFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat>>(
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
        _ = this.SipCompactHeadersEnabled;
        this.SipRegion?.Validate();
        _ = this.SipSubdomain;
        this.SipSubdomainReceiveSettings?.Validate();
        _ = this.Timeout1xxSecs;
        _ = this.Timeout2xxSecs;
    }

    public Inbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Inbound (Inbound inbound) : base(inbound)
    {  }
    #pragma warning restore CS8618

    public Inbound (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Inbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundFromRaw.FromRawUnchecked"/>
    public static Inbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InboundFromRaw : IFromRawJson<Inbound>
{
    /// <inheritdoc/>
    public Inbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Inbound.FromRawUnchecked(rawData);
}

/// <summary>
/// This setting allows you to set the format with which the caller's number (ANI)
/// is sent for inbound phone calls.
/// </summary>
[JsonConverter(typeof(global::Telnyx.Sdk.Models.IPConnections.AniNumberFormatConverter))]
public enum AniNumberFormat
{
    PlusE164, E164, PlusE164National, E164National
}

sealed class AniNumberFormatConverter : JsonConverter<global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat>
{
    public override global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "+E.164"=>global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat.PlusE164,
            "E.164"=>global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat.E164,
            "+E.164-national"=>global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat.PlusE164National,
            "E.164-national"=>global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat.E164National,
            _ =>(global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat.PlusE164=>"+E.164",
            global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat.E164=>"E.164",
            global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat.PlusE164National=>"+E.164-national",
            global::Telnyx.Sdk.Models.IPConnections.AniNumberFormat.E164National=>"E.164-national",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Default routing method to be used when a number is associated with the connection.
/// Must be one of the routing method types or left blank, other values are not allowed.
/// </summary>
[JsonConverter(typeof(global::Telnyx.Sdk.Models.IPConnections.DefaultRoutingMethodConverter))]
public enum DefaultRoutingMethod
{
    Sequential, RoundRobin
}

sealed class DefaultRoutingMethodConverter : JsonConverter<global::Telnyx.Sdk.Models.IPConnections.DefaultRoutingMethod>
{
    public override global::Telnyx.Sdk.Models.IPConnections.DefaultRoutingMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sequential"=>global::Telnyx.Sdk.Models.IPConnections.DefaultRoutingMethod.Sequential,
            "round-robin"=>global::Telnyx.Sdk.Models.IPConnections.DefaultRoutingMethod.RoundRobin,
            _ =>(global::Telnyx.Sdk.Models.IPConnections.DefaultRoutingMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.IPConnections.DefaultRoutingMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.IPConnections.DefaultRoutingMethod.Sequential=>"sequential",
            global::Telnyx.Sdk.Models.IPConnections.DefaultRoutingMethod.RoundRobin=>"round-robin",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormatConverter))]
public enum DnisNumberFormat
{
    PlusE164, E164, National, SipUsername
}

sealed class DnisNumberFormatConverter : JsonConverter<global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat>
{
    public override global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "+e164"=>global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat.PlusE164,
            "e164"=>global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat.E164,
            "national"=>global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat.National,
            "sip_username"=>global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat.SipUsername,
            _ =>(global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat.PlusE164=>"+e164",
            global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat.E164=>"e164",
            global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat.National=>"national",
            global::Telnyx.Sdk.Models.IPConnections.DnisNumberFormat.SipUsername=>"sip_username",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Selects which `sip_region` to receive inbound calls from. If null, the default
/// region (US) will be used.
/// </summary>
[JsonConverter(typeof(SipRegionConverter))]
public enum SipRegion
{
    Us, Europe, Australia
}

sealed class SipRegionConverter : JsonConverter<SipRegion>
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
}

/// <summary>
/// This option can be enabled to receive calls from: "Anyone" (any SIP endpoint in
/// the public Internet) or "Only my connections" (any connection assigned to the
/// same Telnyx user).
/// </summary>
[JsonConverter(typeof(SipSubdomainReceiveSettingsConverter))]
public enum SipSubdomainReceiveSettings
{
    OnlyMyConnections, FromAnyone
}

sealed class SipSubdomainReceiveSettingsConverter : JsonConverter<SipSubdomainReceiveSettings>
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

/// <summary>
/// One of UDP, TLS, or TCP. Applies only to connections with IP authentication or
/// FQDN authentication.
/// </summary>
[JsonConverter(typeof(TransportProtocolConverter))]
public enum TransportProtocol
{
    Udp, Tcp, Tls
}

sealed class TransportProtocolConverter : JsonConverter<TransportProtocol>
{
    public override TransportProtocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UDP"=>TransportProtocol.Udp,
            "TCP"=>TransportProtocol.Tcp,
            "TLS"=>TransportProtocol.Tls,
            _ =>(TransportProtocol)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransportProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TransportProtocol.Udp=>"UDP",
            TransportProtocol.Tcp=>"TCP",
            TransportProtocol.Tls=>"TLS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Determines which webhook format will be used, Telnyx API v1 or v2.
/// </summary>
[JsonConverter(typeof(global::Telnyx.Sdk.Models.IPConnections.WebhookApiVersionConverter))]
public enum WebhookApiVersion
{
    V1, V2
}

sealed class WebhookApiVersionConverter : JsonConverter<global::Telnyx.Sdk.Models.IPConnections.WebhookApiVersion>
{
    public override global::Telnyx.Sdk.Models.IPConnections.WebhookApiVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1"=>global::Telnyx.Sdk.Models.IPConnections.WebhookApiVersion.V1,
            "2"=>global::Telnyx.Sdk.Models.IPConnections.WebhookApiVersion.V2,
            _ =>(global::Telnyx.Sdk.Models.IPConnections.WebhookApiVersion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.IPConnections.WebhookApiVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.IPConnections.WebhookApiVersion.V1=>"1",
            global::Telnyx.Sdk.Models.IPConnections.WebhookApiVersion.V2=>"2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}