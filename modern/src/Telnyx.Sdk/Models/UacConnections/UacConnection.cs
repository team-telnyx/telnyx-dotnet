using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.CredentialConnections;
using Telnyx.Sdk.Models.Fqdns;

namespace Telnyx.Sdk.Models.UacConnections;

/// <summary>
/// A UAC (User Agent Client) Connection registers Telnyx to your PBX — the opposite
/// of a standard SIP trunk, where the PBX registers to Telnyx. Use UAC when your
/// PBX doesn’t support outbound SIP registration or you need Telnyx to maintain the registration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UacConnection, UacConnectionFromRaw>))]
public sealed record class UacConnection : JsonModel
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
    /// Defaults to true
    /// </summary>
    public bool? Active {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <summary>
    /// `Latency` directs Telnyx to route media through the site with the lowest
    /// round-trip time to the user's connection. Telnyx calculates this time using
    /// ICMP ping messages. This can be disabled by specifying a site to handle all media.
    /// </summary>
    public ApiEnum<string, AnchorsiteOverride>? AnchorsiteOverride {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AnchorsiteOverride>>(
                "anchorsite_override"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("anchorsite_override", value);
        }
    }

    /// <summary>
    /// The uuid of the push credential for Android
    /// </summary>
    public string? AndroidPushCredentialID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "android_push_credential_id"
            );
        }
        init { this._rawData.Set("android_push_credential_id", value); }
    }

    /// <summary>
    /// The authentication strategy used by this connection.
    /// </summary>
    public ApiEnum<string, Authentication>? Authentication {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Authentication>>(
                "authentication"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("authentication", value);
        }
    }

    /// <summary>
    /// Specifies if call cost webhooks should be sent for this connection.
    /// </summary>
    public bool? CallCostInWebhooks {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "call_cost_in_webhooks"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_cost_in_webhooks", value);
        }
    }

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
    /// ISO-8601 formatted date indicating when the resource was created.
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
    /// When enabled, Telnyx will generate comfort noise when you place the call
    /// on hold. If disabled, you will need to generate comfort noise or on hold
    /// music to avoid RTP timeout.
    /// </summary>
    public bool? DefaultOnHoldComfortNoiseEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "default_on_hold_comfort_noise_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default_on_hold_comfort_noise_enabled", value);
        }
    }

    /// <summary>
    /// Sets the type of DTMF digits sent from Telnyx to this Connection. Note that
    /// DTMF digits sent to Telnyx will be accepted in all formats.
    /// </summary>
    public ApiEnum<string, DtmfType>? DtmfType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DtmfType>>(
                "dtmf_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("dtmf_type", value);
        }
    }

    /// <summary>
    /// Encode the SIP contact header sent by Telnyx to avoid issues for NAT or ALG scenarios.
    /// </summary>
    public bool? EncodeContactHeaderEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "encode_contact_header_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("encode_contact_header_enabled", value);
        }
    }

    /// <summary>
    /// Enable use of SRTP for encryption. Cannot be set if the transport_portocol
    /// is TLS.
    /// </summary>
    public ApiEnum<string, EncryptedMedia>? EncryptedMedia {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EncryptedMedia>>(
                "encrypted_media"
            );
        }
        init { this._rawData.Set("encrypted_media", value); }
    }

    /// <summary>
    /// External SIP peer settings used by Telnyx when registering to your PBX and
    /// routing outbound calls.
    /// </summary>
    public UacExternalSettings? ExternalUacSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UacExternalSettings>(
                "external_uac_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("external_uac_settings", value);
        }
    }

    /// <summary>
    /// The Telnyx-managed FQDN generated for the UAC connection.
    /// </summary>
    public string? Fqdn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "fqdn"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fqdn", value);
        }
    }

    /// <summary>
    /// The fixed outbound authentication mode used by UAC FQDN records.
    /// </summary>
    public ApiEnum<string, FqdnOutboundAuthentication>? FqdnOutboundAuthentication {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FqdnOutboundAuthentication>>(
                "fqdn_outbound_authentication"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fqdn_outbound_authentication", value);
        }
    }

    /// <summary>
    /// FQDN records managed automatically by the UAC connection lifecycle.
    /// </summary>
    public IReadOnlyList<Fqdn>? Fqdns {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Fqdn>>(
                "fqdns"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Fqdn>?>(
                "fqdns",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public UacInbound? Inbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UacInbound>(
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
    /// Internal Telnyx-side settings for a UAC connection.
    /// </summary>
    public UacInternalSettings? InternalUacSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UacInternalSettings>(
                "internal_uac_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("internal_uac_settings", value);
        }
    }

    /// <summary>
    /// The uuid of the push credential for Ios
    /// </summary>
    public string? IosPushCredentialID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ios_push_credential_id"
            );
        }
        init { this._rawData.Set("ios_push_credential_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConnectionJitterBuffer>(
                "jitter_buffer"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("jitter_buffer", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConnectionNoiseSuppression>>(
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

    /// <summary>
    /// Configuration options for noise suppression. These settings are stored regardless
    /// of the noise_suppression value, but only take effect when noise_suppression
    /// is not 'disabled'. If you disable noise suppression and later re-enable it,
    /// the previously configured settings will be used.
    /// </summary>
    public ConnectionNoiseSuppressionDetails? NoiseSuppressionDetails {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConnectionNoiseSuppressionDetails>(
                "noise_suppression_details"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("noise_suppression_details", value);
        }
    }

    /// <summary>
    /// Enable on-net T38 if you prefer the sender and receiver negotiating T38 directly
    /// if both are on the Telnyx network. If this is disabled, Telnyx will be able
    /// to use T38 on just one leg of the call depending on each leg's settings.
    /// </summary>
    public bool? OnnetT38PassthroughEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "onnet_t38_passthrough_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("onnet_t38_passthrough_enabled", value);
        }
    }

    public UacOutbound? Outbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UacOutbound>(
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
    /// The password to be used as part of the credentials. Must be 8 to 128 characters
    /// long. For primary accounts created on or after September 8, 2026, this password
    /// is returned as `********`. The password is returned in full on create, and
    /// on update only when that update changed the password. Accounts created before
    /// September 8, 2026 are unaffected.
    /// </summary>
    public string? Password {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "password"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("password", value);
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
    /// The most recently known SIP registration status for this UAC connection.
    /// </summary>
    public string? RegistrationStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "registration_status"
            );
        }
        init { this._rawData.Set("registration_status", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the registration status was last updated.
    /// </summary>
    public string? RegistrationStatusUpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "registration_status_updated_at"
            );
        }
        init { this._rawData.Set("registration_status_updated_at", value); }
    }

    public ConnectionRtcpSettings? RtcpSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConnectionRtcpSettings>(
                "rtcp_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rtcp_settings", value);
        }
    }

    /// <summary>
    /// This feature enables inbound SIP URI calls to your Credential Auth Connection.
    /// If enabled for all (unrestricted) then anyone who calls the SIP URI &lt;your-username&gt;@telnyx.com
    /// will be connected to your Connection. You can also choose to allow only calls
    /// that are originated on any Connections under your account (internal).
    /// </summary>
    public ApiEnum<string, UacConnectionSipUriCallingPreference>? SipUriCallingPreference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UacConnectionSipUriCallingPreference>>(
                "sip_uri_calling_preference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_uri_calling_preference", value);
        }
    }

    /// <summary>
    /// Tags associated with the connection.
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
    /// ISO-8601 formatted date indicating when the resource was updated.
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

    /// <summary>
    /// The user name to be used as part of the credentials. Must be 4-32 characters
    /// long and alphanumeric values only (no spaces or special characters). At least
    /// one of the first 5 characters must be a letter.
    /// </summary>
    public string? UserName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_name", value);
        }
    }

    /// <summary>
    /// Determines which webhook format will be used, Telnyx API v1 or v2.
    /// </summary>
    public ApiEnum<string, UacConnectionWebhookApiVersion>? WebhookApiVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UacConnectionWebhookApiVersion>>(
                "webhook_api_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_api_version", value);
        }
    }

    /// <summary>
    /// The failover URL where webhooks related to this connection will be sent if
    /// sending to the primary URL fails. Must include a scheme, such as 'https'.
    /// </summary>
    public string? WebhookEventFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_event_failover_url"
            );
        }
        init { this._rawData.Set("webhook_event_failover_url", value); }
    }

    /// <summary>
    /// The URL where webhooks related to this connection will be sent. Must include
    /// a scheme, such as 'https'.
    /// </summary>
    public string? WebhookEventUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_event_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_event_url", value);
        }
    }

    /// <summary>
    /// Specifies how many seconds to wait before timing out a webhook.
    /// </summary>
    public long? WebhookTimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "webhook_timeout_secs"
            );
        }
        init { this._rawData.Set("webhook_timeout_secs", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Active;
        this.AnchorsiteOverride?.Validate();
        _ = this.AndroidPushCredentialID;
        this.Authentication?.Validate();
        _ = this.CallCostInWebhooks;
        _ = this.ConnectionName;
        _ = this.CreatedAt;
        _ = this.DefaultOnHoldComfortNoiseEnabled;
        this.DtmfType?.Validate();
        _ = this.EncodeContactHeaderEnabled;
        this.EncryptedMedia?.Validate();
        this.ExternalUacSettings?.Validate();
        _ = this.Fqdn;
        this.FqdnOutboundAuthentication?.Validate();
        foreach (var item in this.Fqdns ?? [])
        {
            item.Validate();
        }
        this.Inbound?.Validate();
        this.InternalUacSettings?.Validate();
        _ = this.IosPushCredentialID;
        this.JitterBuffer?.Validate();
        this.NoiseSuppression?.Validate();
        this.NoiseSuppressionDetails?.Validate();
        _ = this.OnnetT38PassthroughEnabled;
        this.Outbound?.Validate();
        _ = this.Password;
        _ = this.RecordType;
        _ = this.RegistrationStatus;
        _ = this.RegistrationStatusUpdatedAt;
        this.RtcpSettings?.Validate();
        this.SipUriCallingPreference?.Validate();
        _ = this.Tags;
        _ = this.UpdatedAt;
        _ = this.UserName;
        this.WebhookApiVersion?.Validate();
        _ = this.WebhookEventFailoverUrl;
        _ = this.WebhookEventUrl;
        _ = this.WebhookTimeoutSecs;
    }

    public UacConnection ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UacConnection (UacConnection uacConnection) : base(uacConnection)
    {  }
    #pragma warning restore CS8618

    public UacConnection (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UacConnection (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UacConnectionFromRaw.FromRawUnchecked"/>
    public static UacConnection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UacConnectionFromRaw : IFromRawJson<UacConnection>
{
    /// <inheritdoc/>
    public UacConnection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UacConnection.FromRawUnchecked(rawData);
}

/// <summary>
/// The authentication strategy used by this connection.
/// </summary>
[JsonConverter(typeof(AuthenticationConverter))]
public enum Authentication
{
    UacAuthentication
}sealed class AuthenticationConverter : JsonConverter<Authentication>
{
    public override Authentication Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "uac-authentication"=>Authentication.UacAuthentication,
            _ =>(Authentication)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Authentication value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Authentication.UacAuthentication=>"uac-authentication",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The fixed outbound authentication mode used by UAC FQDN records.
/// </summary>
[JsonConverter(typeof(FqdnOutboundAuthenticationConverter))]
public enum FqdnOutboundAuthentication
{
    CredentialAuthentication
}sealed class FqdnOutboundAuthenticationConverter : JsonConverter<FqdnOutboundAuthentication>
{
    public override FqdnOutboundAuthentication Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credential-authentication"=>FqdnOutboundAuthentication.CredentialAuthentication,
            _ =>(FqdnOutboundAuthentication)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FqdnOutboundAuthentication value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FqdnOutboundAuthentication.CredentialAuthentication=>"credential-authentication",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// This feature enables inbound SIP URI calls to your Credential Auth Connection.
/// If enabled for all (unrestricted) then anyone who calls the SIP URI &lt;your-username&gt;@telnyx.com
/// will be connected to your Connection. You can also choose to allow only calls
/// that are originated on any Connections under your account (internal).
/// </summary>
[JsonConverter(typeof(UacConnectionSipUriCallingPreferenceConverter))]
public enum UacConnectionSipUriCallingPreference
{
    Disabled, Unrestricted, Internal
}sealed class UacConnectionSipUriCallingPreferenceConverter : JsonConverter<UacConnectionSipUriCallingPreference>
{
    public override UacConnectionSipUriCallingPreference Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>UacConnectionSipUriCallingPreference.Disabled,
            "unrestricted"=>UacConnectionSipUriCallingPreference.Unrestricted,
            "internal"=>UacConnectionSipUriCallingPreference.Internal,
            _ =>(UacConnectionSipUriCallingPreference)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UacConnectionSipUriCallingPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UacConnectionSipUriCallingPreference.Disabled=>"disabled",
            UacConnectionSipUriCallingPreference.Unrestricted=>"unrestricted",
            UacConnectionSipUriCallingPreference.Internal=>"internal",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Determines which webhook format will be used, Telnyx API v1 or v2.
/// </summary>
[JsonConverter(typeof(UacConnectionWebhookApiVersionConverter))]
public enum UacConnectionWebhookApiVersion
{
    V1, V2
}sealed class UacConnectionWebhookApiVersionConverter : JsonConverter<UacConnectionWebhookApiVersion>
{
    public override UacConnectionWebhookApiVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1"=>UacConnectionWebhookApiVersion.V1,
            "2"=>UacConnectionWebhookApiVersion.V2,
            _ =>(UacConnectionWebhookApiVersion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UacConnectionWebhookApiVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UacConnectionWebhookApiVersion.V1=>"1",
            UacConnectionWebhookApiVersion.V2=>"2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}