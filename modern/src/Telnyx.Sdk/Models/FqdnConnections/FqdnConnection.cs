using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.CredentialConnections;

namespace Telnyx.Sdk.Models.FqdnConnections;

[JsonConverter(typeof(JsonModelConverter<FqdnConnection, FqdnConnectionFromRaw>))]
public sealed record class FqdnConnection : JsonModel
{
    /// <summary>
    /// A user-assigned name to help manage the connection.
    /// </summary>
    public required string ConnectionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "connection_name"
            );
        }
        init { this._rawData.Set("connection_name", value); }
    }

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
    /// Indicates whether DTMF timestamp adjustment is enabled.
    /// </summary>
    public bool? AdjustDtmfTimestamp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "adjust_dtmf_timestamp"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("adjust_dtmf_timestamp", value);
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
    /// Indicates whether call cost calculation is enabled.
    /// </summary>
    public bool? CallCostEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "call_cost_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_cost_enabled", value);
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

    /// <summary>
    /// Whether conversation persistence is enabled for this connection. When enabled,
    /// calls handled by the connection are transcribed, stored, and indexed. Defaults
    /// to false.
    /// </summary>
    public bool? ConversationPersistence {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "conversation_persistence"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conversation_persistence", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
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
    /// Indicates whether DTMF duration should be ignored.
    /// </summary>
    public bool? IgnoreDtmfDuration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "ignore_dtmf_duration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ignore_dtmf_duration", value);
        }
    }

    /// <summary>
    /// Indicates whether the mark bit should be ignored.
    /// </summary>
    public bool? IgnoreMarkBit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "ignore_mark_bit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ignore_mark_bit", value);
        }
    }

    public InboundFqdn? Inbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundFqdn>(
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
    /// The connection is enabled for Microsoft Teams Direct Routing.
    /// </summary>
    public bool? MicrosoftTeamsSbc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "microsoft_teams_sbc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("microsoft_teams_sbc", value);
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
    /// Enable on-net T38 if you prefer that the sender and receiver negotiate T38
    /// directly when both are on the Telnyx network. If this is disabled, Telnyx
    /// will be able to use T38 on just one leg of the call according to each leg's settings.
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

    public OutboundFqdn? Outbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutboundFqdn>(
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
    /// The password for the FQDN connection. For primary accounts created on or
    /// after September 8, 2026, this password is returned as `********`. The password
    /// is returned in full on create, and on update only when that update changed
    /// the password. Accounts created before September 8, 2026 are unaffected.
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
    /// Defines if codecs should be passed on stream change.
    /// </summary>
    public bool? RtpPassCodecsOnStreamChange {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "rtp_pass_codecs_on_stream_change"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rtp_pass_codecs_on_stream_change", value);
        }
    }

    /// <summary>
    /// Indicates whether normalized timestamps should be sent.
    /// </summary>
    public bool? SendNormalizedTimestamps {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "send_normalized_timestamps"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("send_normalized_timestamps", value);
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
    /// Indicates whether third-party control is enabled.
    /// </summary>
    public bool? ThirdPartyControlEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "third_party_control_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("third_party_control_enabled", value);
        }
    }

    /// <summary>
    /// One of UDP, TLS, or TCP. Applies only to connections with IP authentication
    /// or FQDN authentication.
    /// </summary>
    public ApiEnum<string, TransportProtocol>? TransportProtocol {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TransportProtocol>>(
                "transport_protocol"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transport_protocol", value);
        }
    }

    /// <summary>
    /// The name for the TXT record associated with the FQDN connection.
    /// </summary>
    public string? TxtName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "txt_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("txt_name", value);
        }
    }

    /// <summary>
    /// The time to live for the TXT record associated with the FQDN connection.
    /// </summary>
    public long? TxtTtl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "txt_ttl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("txt_ttl", value);
        }
    }

    /// <summary>
    /// The value for the TXT record associated with the FQDN connection.
    /// </summary>
    public string? TxtValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "txt_value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("txt_value", value);
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

    /// <summary>
    /// The username for the FQDN connection.
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
    public ApiEnum<string, global::Telnyx.Sdk.Models.FqdnConnections.WebhookApiVersion>? WebhookApiVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.FqdnConnections.WebhookApiVersion>>(
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
        _ = this.ConnectionName;
        _ = this.ID;
        _ = this.Active;
        _ = this.AdjustDtmfTimestamp;
        this.AnchorsiteOverride?.Validate();
        _ = this.AndroidPushCredentialID;
        _ = this.CallCostEnabled;
        _ = this.CallCostInWebhooks;
        _ = this.ConversationPersistence;
        _ = this.CreatedAt;
        _ = this.DefaultOnHoldComfortNoiseEnabled;
        this.DtmfType?.Validate();
        _ = this.EncodeContactHeaderEnabled;
        this.EncryptedMedia?.Validate();
        _ = this.IgnoreDtmfDuration;
        _ = this.IgnoreMarkBit;
        this.Inbound?.Validate();
        _ = this.IosPushCredentialID;
        this.JitterBuffer?.Validate();
        _ = this.MicrosoftTeamsSbc;
        this.NoiseSuppression?.Validate();
        this.NoiseSuppressionDetails?.Validate();
        _ = this.OnnetT38PassthroughEnabled;
        this.Outbound?.Validate();
        _ = this.Password;
        _ = this.RecordType;
        this.RtcpSettings?.Validate();
        _ = this.RtpPassCodecsOnStreamChange;
        _ = this.SendNormalizedTimestamps;
        _ = this.Tags;
        _ = this.ThirdPartyControlEnabled;
        this.TransportProtocol?.Validate();
        _ = this.TxtName;
        _ = this.TxtTtl;
        _ = this.TxtValue;
        _ = this.UpdatedAt;
        _ = this.UserName;
        this.WebhookApiVersion?.Validate();
        _ = this.WebhookEventFailoverUrl;
        _ = this.WebhookEventUrl;
        _ = this.WebhookTimeoutSecs;
    }

    public FqdnConnection ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnConnection (FqdnConnection fqdnConnection) : base(fqdnConnection)
    {  }
    #pragma warning restore CS8618

    public FqdnConnection (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FqdnConnection (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnConnectionFromRaw.FromRawUnchecked"/>
    public static FqdnConnection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public FqdnConnection (string connectionName) : this()
    { this.ConnectionName = connectionName; }
}

class FqdnConnectionFromRaw : IFromRawJson<FqdnConnection>
{
    /// <inheritdoc/>
    public FqdnConnection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FqdnConnection.FromRawUnchecked(rawData);
}