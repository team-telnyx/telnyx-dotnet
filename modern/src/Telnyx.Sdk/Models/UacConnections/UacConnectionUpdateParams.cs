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

namespace Telnyx.Sdk.Models.UacConnections;

/// <summary>
/// Updates settings of an existing UAC connection.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UacConnectionUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

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
    /// A user-assigned name to help manage the connection.
    /// </summary>
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

    /// <summary>
    /// External SIP peer settings used by Telnyx when registering to your PBX and
    /// routing outbound calls.
    /// </summary>
    public UacExternalSettings? ExternalUacSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<UacExternalSettings>(
                "external_uac_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("external_uac_settings", value);
        }
    }

    /// <summary>
    /// Inbound settings that can be supplied when creating or updating a UAC connection.
    /// The SIP subdomain fields returned in UAC connection responses are generated
    /// by Telnyx and are not accepted as request parameters.
    /// </summary>
    public UacInboundRequest? Inbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<UacInboundRequest>(
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
    /// Internal Telnyx-side settings for a UAC connection.
    /// </summary>
    public UacInternalSettings? InternalUacSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<UacInternalSettings>(
                "internal_uac_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("internal_uac_settings", value);
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

    public UacOutbound? Outbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<UacOutbound>(
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

    /// <summary>
    /// The password to be used as part of the credentials. Must be 8 to 128 characters long.
    /// </summary>
    public string? Password {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "password"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("password", value);
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
    public ApiEnum<string, UacConnectionUpdateParamsSipUriCallingPreference>? SipUriCallingPreference {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, UacConnectionUpdateParamsSipUriCallingPreference>>(
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
    /// The user name to be used as part of the credentials. Must be 4-32 characters
    /// long and alphanumeric values only (no spaces or special characters).
    /// </summary>
    public string? UserName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "user_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("user_name", value);
        }
    }

    /// <summary>
    /// Determines which webhook format will be used, Telnyx API v1 or v2.
    /// </summary>
    public ApiEnum<string, UacConnectionUpdateParamsWebhookApiVersion>? WebhookApiVersion {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, UacConnectionUpdateParamsWebhookApiVersion>>(
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

    public UacConnectionUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UacConnectionUpdateParams (
        UacConnectionUpdateParams uacConnectionUpdateParams
    ) : base(uacConnectionUpdateParams)
    {
        this.ID = uacConnectionUpdateParams.ID;

        this._rawBodyData = new(uacConnectionUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public UacConnectionUpdateParams (
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
    UacConnectionUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UacConnectionUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(UacConnectionUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/uac_connections/{0}",
            this.ID)
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
[JsonConverter(typeof(UacConnectionUpdateParamsSipUriCallingPreferenceConverter))]
public enum UacConnectionUpdateParamsSipUriCallingPreference
{
    Disabled, Unrestricted, Internal
}

sealed class UacConnectionUpdateParamsSipUriCallingPreferenceConverter : JsonConverter<UacConnectionUpdateParamsSipUriCallingPreference>
{
    public override UacConnectionUpdateParamsSipUriCallingPreference Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>UacConnectionUpdateParamsSipUriCallingPreference.Disabled,
            "unrestricted"=>UacConnectionUpdateParamsSipUriCallingPreference.Unrestricted,
            "internal"=>UacConnectionUpdateParamsSipUriCallingPreference.Internal,
            _ =>(UacConnectionUpdateParamsSipUriCallingPreference)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UacConnectionUpdateParamsSipUriCallingPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UacConnectionUpdateParamsSipUriCallingPreference.Disabled=>"disabled",
            UacConnectionUpdateParamsSipUriCallingPreference.Unrestricted=>"unrestricted",
            UacConnectionUpdateParamsSipUriCallingPreference.Internal=>"internal",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Determines which webhook format will be used, Telnyx API v1 or v2.
/// </summary>
[JsonConverter(typeof(UacConnectionUpdateParamsWebhookApiVersionConverter))]
public enum UacConnectionUpdateParamsWebhookApiVersion
{
    V1, V2
}

sealed class UacConnectionUpdateParamsWebhookApiVersionConverter : JsonConverter<UacConnectionUpdateParamsWebhookApiVersion>
{
    public override UacConnectionUpdateParamsWebhookApiVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1"=>UacConnectionUpdateParamsWebhookApiVersion.V1,
            "2"=>UacConnectionUpdateParamsWebhookApiVersion.V2,
            _ =>(UacConnectionUpdateParamsWebhookApiVersion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UacConnectionUpdateParamsWebhookApiVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UacConnectionUpdateParamsWebhookApiVersion.V1=>"1",
            UacConnectionUpdateParamsWebhookApiVersion.V2=>"2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}