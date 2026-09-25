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

namespace Telnyx.Sdk.Models.CredentialConnections;

/// <summary>
/// Creates a new credential-based SIP connection. Credential connections authenticate
/// with a username and password rather than by IP address.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CredentialConnectionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// A user-assigned name to help manage the connection.
    /// </summary>
    public required string ConnectionName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "connection_name"
            );
        }
        init { this._rawBodyData.Set("connection_name", value); }
    }

    /// <summary>
    /// The password to be used as part of the credentials. Must be 8 to 128 characters long.
    /// </summary>
    public required string Password {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "password"
            );
        }
        init { this._rawBodyData.Set("password", value); }
    }

    /// <summary>
    /// The user name to be used as part of the credentials. Must be 4-32 characters
    /// long and alphanumeric values only (no spaces or special characters).
    /// </summary>
    public required string UserName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "user_name"
            );
        }
        init { this._rawBodyData.Set("user_name", value); }
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

    public CredentialInbound? Inbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CredentialInbound>(
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

    public CredentialOutbound? Outbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CredentialOutbound>(
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
    /// This feature enables inbound SIP URI calls to your Credential Auth Connection.
    /// If enabled for all (unrestricted) then anyone who calls the SIP URI &lt;your-username&gt;@telnyx.com
    /// will be connected to your Connection. You can also choose to allow only calls
    /// that are originated on any Connections under your account (internal).
    /// </summary>
    public ApiEnum<string, SipUriCallingPreference>? SipUriCallingPreference {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, SipUriCallingPreference>>(
                "sip_uri_calling_preference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sip_uri_calling_preference", value);
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
    /// Determines which webhook format will be used, Telnyx API v1, v2 or texml.
    /// Note - texml can only be set when the outbound object parameter call_parking_enabled
    /// is included and set to true.
    /// </summary>
    public ApiEnum<string, WebhookApiVersion>? WebhookApiVersion {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, WebhookApiVersion>>(
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

    public CredentialConnectionCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CredentialConnectionCreateParams (
        CredentialConnectionCreateParams credentialConnectionCreateParams
    ) : base(credentialConnectionCreateParams)
    { this._rawBodyData = new(credentialConnectionCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public CredentialConnectionCreateParams (
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
    CredentialConnectionCreateParams (
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
    public static CredentialConnectionCreateParams FromRawUnchecked(
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

    public virtual bool Equals(CredentialConnectionCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/credential_connections"
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

/// <summary>
/// This feature enables inbound SIP URI calls to your Credential Auth Connection.
/// If enabled for all (unrestricted) then anyone who calls the SIP URI &lt;your-username&gt;@telnyx.com
/// will be connected to your Connection. You can also choose to allow only calls
/// that are originated on any Connections under your account (internal).
/// </summary>
[JsonConverter(typeof(SipUriCallingPreferenceConverter))]
public enum SipUriCallingPreference
{
    Disabled, Unrestricted, Internal
}

sealed class SipUriCallingPreferenceConverter : JsonConverter<SipUriCallingPreference>
{
    public override SipUriCallingPreference Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>SipUriCallingPreference.Disabled,
            "unrestricted"=>SipUriCallingPreference.Unrestricted,
            "internal"=>SipUriCallingPreference.Internal,
            _ =>(SipUriCallingPreference)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SipUriCallingPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SipUriCallingPreference.Disabled=>"disabled",
            SipUriCallingPreference.Unrestricted=>"unrestricted",
            SipUriCallingPreference.Internal=>"internal",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Determines which webhook format will be used, Telnyx API v1, v2 or texml. Note
/// - texml can only be set when the outbound object parameter call_parking_enabled
/// is included and set to true.
/// </summary>
[JsonConverter(typeof(WebhookApiVersionConverter))]
public enum WebhookApiVersion
{
    V1, V2, Texml
}

sealed class WebhookApiVersionConverter : JsonConverter<WebhookApiVersion>
{
    public override WebhookApiVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1"=>WebhookApiVersion.V1,
            "2"=>WebhookApiVersion.V2,
            "texml"=>WebhookApiVersion.Texml,
            _ =>(WebhookApiVersion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookApiVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookApiVersion.V1=>"1",
            WebhookApiVersion.V2=>"2",
            WebhookApiVersion.Texml=>"texml",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}